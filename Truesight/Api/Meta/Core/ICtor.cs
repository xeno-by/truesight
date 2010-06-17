using Truesight.Api.Dynamic.Core;
using Truesight.Api.Meta.Attrs;
using Truesight.Api.Meta.Generics;
using Truesight.Api.Meta.Hierarchy;
using Truesight.Api.Meta.Access;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface ICtor : ICallSite, IHaveParent<IType>, IHierarchy<ICtor>, ICanBeGeneric<ICtor>, IHaveAttrs, IHaveVisibility
    {
    }

    // see comments for IMethod.cs => they are fully applicable to ctors
}