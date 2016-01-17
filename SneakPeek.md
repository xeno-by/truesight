Code samples for this article are taken from my [real-life codegen tasks](http://code.google.com/p/elf4b/source/browse/trunk/Tiller/Esath.Eval/Ver3/VaultCompiler.cs). They use standard Reflection and Reflection.Emit APIs though enhanced with [fluent extensions](http://code.google.com/p/xenogears/source/browse/trunk/XenoGears/Reflection/#Reflection/Emit). Truesight versions are design sketches, so don't treat them as working code - rather as illustration of possibilities. Example 3 is the most impressive =)

Note: Truesight is not confined to enhancing codegen experience. It also provides object models for reflection, decompilation and dynamic invocations. See the [PlannedFeatures](PlannedFeatures.md) wiki page for more information.

### Example 1 (Reflection.Emit) ###
```
// type definition
var t_parent = ctx.PrevSuccessfulType("scenario") ?? typeof(CompiledScenario);
(t_parent == typeof(CompiledScenario) ^ ctx.CumulativeCompilation).AssertTrue();
var t = _mod.DefineType(ctx.RequestName(Vault.GetClassName()), TA.Public, t_parent);

// constructors
var ctorDesignMode = t.DefineConstructor(MA.PublicCtor, CallingConventions.Standard,
    new[] { typeof(IVault) });
ctorDesignMode.DefineParameter(1, ParmA.None, "scenario");
ctorDesignMode.il().ld_args(2).basector(typeof(CompiledScenario), typeof(IVault)).ret();
var ctorRuntimeMode = t.DefineConstructor(MA.PublicCtor, CallingConventions.Standard,
    new[] { typeof(IVault), typeof(IVault) });
ctorRuntimeMode.DefineParameter(1, ParmA.None, "scenario");
ctorRuntimeMode.DefineParameter(2, ParmA.None, "repository");
ctorRuntimeMode.il().ld_args(3).basector(typeof(CompiledScenario), typeof(IVault), typeof(IVault)).ret();

// the [Version(...)] attribute for reflection-based analysis
t.SetCustomAttribute(new CustomAttributeBuilder(
    typeof(VersionAttribute).GetConstructor(new[] { typeof(String), typeof(ulong) }),
    new object[] { Vault.Id.ToString(), Vault.Revision }));

// the [Seq(...)] attribute for synchronization and namespacing purposes
t.SetCustomAttribute(new CustomAttributeBuilder(
    typeof(SeqAttribute).GetConstructor(new[] { typeof(int) }),
    new object[] { ctx.WorkerSeq }));

// trivial overrides
t.DefineOverrideReadonly(typeof(CompiledScenario).GetProperty("Version"))
    .il()
    .ldstr(Vault.Id.ToString())
    .newobj(typeof(Guid), typeof(String))
    .ldc_i8(Vault.Revision)
    .newobj(typeof(Version), typeof(Guid), typeof(ulong))
    .ret();

t.DefineOverrideReadonly(typeof(CompiledNode).GetProperty("Name"))
    .il()
    .ldstr(Vault.GetClassName() + "_seq" + ctx.WorkerSeq)
    .ret();

t.DefineOverrideReadonly(typeof(CompiledNode).GetProperty("VPath"))
    .il()
    .call(typeof(VPath).GetProperty("Empty").GetGetMethod())
    .ret();

t.DefineOverrideReadonly(typeof(CompiledNode).GetProperty("Revision"))
    .il()
    .ldc_i8(Vault.Revision)
    .ret();

t.DefineOverrideReadonly(typeof(CompiledNode).GetProperty("Seq"))
    .il()
    .ldc_i4(ctx.WorkerSeq)
    .ret();
```

### Example 1 (Truesight) ###
```
// type definition
var t_parent = ctx.PrevSuccessfulType("scenario") ?? typeof(CompiledScenario);
(t_parent == typeof(CompiledScenario) ^ ctx.CumulativeCompilation).AssertTrue();
var t = unit.Types.Add(ctx.RequestName(Vault.GetClassName()), t_parent);
t.Annotate(() => new VersionAtribute(Vault.Id.ToString(), Vault.Revision));
t.Annotate(() => new SeqAttribute(ctx.WorkerSeq));

// constructors
t.Ctors.Add((IVault scenario, Action<IVault> @base) => @base(scenario));
t.Ctors.Add((IVault scenario, IVault repository, Action<IVault, IVault> @base) => @base(scenario, repository));

// trivial overrides
t.Props["Version"].Override().Getter.AppendCode(() => new Version(Vault.Id, Vault.Revision));
t.Props["Name"].Override().Getter.AppendCode(() => Vault.GetClassName() + "_seq" + ctx.WorkerSeq);
t.Props["VPath"].Override().Getter.AppendCode(() => VPath.Empty);
t.Props["Revision"].Override().Getter.AppendCode(() => Vault.Revision);
t.Props["Seq"].Override().Getter.AppendCode(() => ctx.WorkerSeq);
```

### Example 2 (Reflection.Emit) ###
```
var f_child = t.DefineField("_" + b.GetPropertyName().ToLower(), b_type, FA.Private);
var p_child = t.DefineProperty(b.GetPropertyName(), PropA.None, b_type, new Type[0]);
p_child.SetCustomAttribute(new CustomAttributeBuilder(
typeof(VPathAttribute).GetConstructor(typeof(String).MkArray()),
b.VPath.ToString().MkArray()));

var get = t.DefineMethod("get_" + b.GetPropertyName(), MA.PublicProp, b_type, new Type[0]);
p_child.SetGetMethod(get);

Label nodeWasCreatedByTheFactory;
get.il()
.ldarg(0)
.ldfld(f_child)

// here we check whether the factory returned a valid (non-null) node
// if the latter is false, then the node has been deleted during cumulative recompilation
// and we need to crash with the same message as CompiledNode.Child(vpath)
.def_label(out nodeWasCreatedByTheFactory)
.brtrue(nodeWasCreatedByTheFactory)
.ldstr(String.Format("There's no compiled node at VPath '{0}'.", b.VPath))
.@throw(typeof(NotImplementedException), typeof(String))

.label(nodeWasCreatedByTheFactory)
.ldarg(0)
.ldfld(f_child)
.ret();

cc.il()
.ldarg(0)
.ldarg(0)
.callvirt(typeof(CompiledNode).GetProperty("Root", BF.All).GetGetMethod(true))
.ldstr(b.VPath.ToString())
.newobj(typeof(VPath), typeof(String))
.ldarg(0)
.callvirt(typeof(CompiledScenario).GetMethod("CreateNode", BF.All))
.stfld(f_child)
.ldarg(0)
.callvirt(typeof(CompiledNode).GetProperty("Children").GetGetMethod())
.ldarg(0)
.ldfld(f_child)
.callvirt(typeof(CompiledNodeCollection).GetMethod("Add"));
```

### Example 2 (Truesight) ###
```
var f_child = t.Fields.AddPrivate("_" + b.GetPropertyName().ToLower(), b_type);

var p_child = t.Properties.Add(b.GetPropertyName(), b_type);
p_child.Annotate(() => new VPathAttribute(b.VPath.ToString()));
p_child.Getter.AppendCode(() => 
{
    if (f_child == null) throw new NotImplementedException(String.Format("There's no compiled node at VPath '{0}'.", b.VPath));
    return f_child;
});

cc.AppendCode((CompiledScenario @this) =>
{
    f_child = @this.Root.CreateNode(b.VPath, @this);
    @this.Children.Add(f_child);
});
```

### Example 3 (Reflection.Emit) ###
```
Label cacheOk;
LocalBuilder loc_cache, loc_vpath, loc_result;
get.il()
   .ldarg(0)
   .callvirt(typeof(CompiledNode).GetProperty("Root").GetGetMethod())
   .ldfld(typeof(CompiledScenario).GetField("CachedPropertiesRegistry", BF.All))
   .def_local(typeof(HashSet<VPath>), out loc_cache)
   .stloc(loc_cache)
   .ldstr(b.VPath.ToString())
   .newobj(typeof(VPath), typeof(String))
   .def_local(typeof(VPath), out loc_vpath)
   .stloc(loc_vpath)
   .ldloc(loc_cache)
   .ldloc(loc_vpath)
   .callvirt(typeof(HashSet<VPath>).GetMethod("Contains"))
   .def_label(out cacheOk)
   .brtrue(cacheOk)

   // here svd and flae codegen will store the evaluation result
   .def_local(propType, out loc_result);

if (b.IsSvd())
{
    Label isRuntime, stlocRuntime, isDesignTime, stlocDesignTime, coalesce;
    LocalBuilder runtime, designTime;
    get.il()

        // runtime -> value is stored in the repository
       .ldarg(0)
       .callvirt(typeof(CompiledNode).GetProperty("Repository", BF.All).GetGetMethod(true))
       .def_label(out stlocRuntime)
       .def_label(out isRuntime)
       .def_local(typeof(String), out runtime)
       .brtrue_s(isRuntime)
       .ldnull()
       .br_s(stlocRuntime)
       .label(isRuntime)
       .ldarg(0)
       .callvirt(typeof(CompiledNode).GetProperty("Repository", BF.All).GetGetMethod(true))
       .ldarg(0)
       .callvirt(typeof(CompiledNode).GetProperty("Scenario", BF.All).GetGetMethod(true))
       .ldstr(b.VPath.ToString())
       .newobj(typeof(VPath), typeof(String))
       .callvirt(typeof(CachedVault).GetMethod("GetBranch"))
       .ldstr("repositoryValue")
       .newobj(typeof(VPath), typeof(String))
       .callvirt(typeof(IBranch).GetMethod("GetValue"))
       .callvirt(typeof(IValue).GetProperty("ContentString").GetGetMethod())
       .newobj(typeof(VPath), typeof(String))
       .callvirt(typeof(CachedVault).GetMethod("GetValue"))
       .callvirt(typeof(IValue).GetProperty("ContentString").GetGetMethod())
       .label(stlocRuntime)
       .stloc(runtime)

        // design time -> value is stored directly in the scenario next to the node
       .ldarg(0)
       .callvirt(typeof(CompiledNode).GetProperty("Repository", BF.All).GetGetMethod(true))
       .def_label(out stlocDesignTime)
       .def_label(out isDesignTime)
       .def_local(typeof(String), out designTime)
       .brfalse_s(isDesignTime)
       .ldnull()
       .br_s(stlocDesignTime)
       .label(isDesignTime)
       .ldarg(0)
       .callvirt(typeof(CompiledNode).GetProperty("Scenario", BF.All).GetGetMethod(true))
       .ldstr(b.VPath.ToString())
       .newobj(typeof(VPath), typeof(String))
       .callvirt(typeof(CachedVault).GetMethod("GetBranch"))
       .ldstr("valueForTesting")
       .newobj(typeof(VPath), typeof(String))
       .callvirt(typeof(IBranch).GetMethod("GetValue"))
       .callvirt(typeof(IValue).GetProperty("ContentString").GetGetMethod())
       .label(stlocDesignTime)
       .stloc(designTime)

       // prepare for convert
       .ldtoken(propType)
       .callvirt(typeof(Type).GetMethod("GetTypeFromHandle"))
       .callvirt(typeof(Elf.Helpers.ReflectionHelper).GetMethod("ElfDeserializer"))

        // coalesce designtime and runtime values
       .ldloc(designTime)
       .dup()
       .def_label(out coalesce)
       .brtrue_s(coalesce)
       .pop()
       .ldloc(runtime)
       .label(coalesce)

       // convert the string to esath object
       .callvirt(typeof(Func<String, IElfObject>).GetMethod("Invoke"))
       .stloc(loc_result);
}
else
{
    // omitted for brevity
}

get.il()
   // the value is stored in a local after svd or flae codegen
   .ldarg(0)
   .ldloc(loc_result)
   .stfld(f_prop)
   .ldloc(loc_cache)
   .ldloc(loc_vpath)
   .callvirt(typeof(HashSet<VPath>).GetMethod("Add"))
   .pop()

   // if the value is cached, just execute this
   .label(cacheOk)
   .ldarg(0)
   .ldfld(f_prop)
   .ret();
```

### Example 3 (Truesight) ###
```
var lacunas = get.AppendCode((CompiledNode @this) =>
{
    var cache = ((CompiledScenario)@this.Root).CachedPropertiesRegistry;
    if (!cache.Contains(b.VPath)) 
    {
        f_prop = Hints.Lacuna(0);
        cache.Add(b.VPath);
    }
    
    return f_prop;
});

if (b.IsSvd())
{
    lacunas[0].AppendCode((CompiledNode @this) => 
    {
        String s_value = null;
        if (@this.Repository != null)
        {
            var scenarioValue = @this.Scenario.GetValue(b.VPath + "repositoryValue");
            var repositoryValue = @this.Repository.GetValue(scenarioValue.ContentString);
            s_value = repositoryValue.ContentString;
        }
        else
        {
            var scenarioValue = @this.Scenario.GetValue(b.VPath + "valueForTesting");
            s_value = scenarioValue.ContentString;
        }
        
        return propType.ElfDeserializer()(value); 
    });
}
else
{
    // omitted for brevity
}
```