using System;
using Truesight.Api.Dynamic.Collections;
using Truesight.Api.Meta.Attrs;
using Truesight.Api.Meta.Collections;
using Truesight.Api.Meta.Generics;
using Truesight.Api.Meta.Hierarchy;
using Truesight.Api.Meta.Access;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface IType : IHaveParent<IAsm>, IHierarchy<IType>, ICanBeGeneric<IType>, IHaveAttrs, IHaveVisibility
    {
        String Name { get; set; }
        String FullName { get; set; }
        String Namespace { get; set; }

        ISlots Slots { get; }
        IFields Fields { get; }
        IProperties Properties { get; }
        IMethods Methods { get; }
        ICtors Ctors { get; }

        bool IsInterface { get; set; }
        Object Instantiate(params Object[] args);
        T Instantiate<T>(params Object[] args);
    }
}
