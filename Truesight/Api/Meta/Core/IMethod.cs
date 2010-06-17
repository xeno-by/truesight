using Truesight.Api.Meta.Attrs;
using Truesight.Api.Meta.Generics;
using Truesight.Api.Dynamic.Core;
using Truesight.Api.Meta.Hierarchy;
using Truesight.Api.Meta.Access;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface IMethod : ICallSite, IHaveParent<IType>, IHierarchy<IMethod>, ICanBeGeneric<IMethod>, IHaveAttrs, IHaveVisibility
    {
    }

    // here we need to add shitloads of different IMethod<...> classes for Action<...> and Func<...>
    // one declaration of IMethod<T> where T : Delegate won't be enought since we need to 
    // strongly type arguments of the invoke method of the callsite
    // see ICallSite.cs file for some implementation tips
    // important: we need to reimplement IHierarchy<T>, ICanBeGeneric<T>
}