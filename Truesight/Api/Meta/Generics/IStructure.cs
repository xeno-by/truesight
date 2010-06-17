using System;
using System.Collections.Generic;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Generics
{
    // needs implicit casts to/from T and corresponding Reflection types
    // also needs explicit means of conversion: Structure and Entity properties

    public interface IStructure<T> : IHaveParent<T>, IEnumerable<IStructure<T>>
        where T : ICanBeGeneric<T>
    {
        // this class uses paths to analyze the structure of T
        // for examples of valid paths see 
        // http://code.google.com/p/xenogears/source/browse/trunk/XenoGears/Reflection/#Reflection/StructuralTrees?r118

        IStructure<T> this[int position] { get; }
        IType this[String path] { get; }

        Dictionary<String, String> TypeArgsMap(); // for self
        Dictionary<String, String> TypeArgsMap(IType type); // for inner type, not valid if T ain't IType
        Dictionary<String, String> TypeArgsMap(IField field); // not valid if T ain't IType
        Dictionary<String, String> TypeArgsMap(IProperty property); // not valid if T ain't IType
        Dictionary<String, String> TypeArgsMap(IMethod method);
        Dictionary<String, String> TypeArgsMap(IParam paramOrReturn); // also valid if T is IType!
        // the methods above also introduce extensions that invert the control:
        // i.e. t.Fields["_field"].TypeArgsMap() and like

        IStructure<T> Infer(String path, IType type);
        // extension method: IStructure<T> Infer(IEnumerable<KeyValuePair<string, Type>> batch);

        // ToString will redirect processing to its Entity
        // we need awesome equality members: GetHashCode, Equals, IEquatable<this>, operator ==
    }
}