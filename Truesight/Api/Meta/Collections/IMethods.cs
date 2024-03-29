using Truesight.Api.Dynamic.Collections;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    public interface IMethods : ICallSites, IHaveParent<IType>, IUpdatable<IMethod>
    {
        // we need to overload a lot of methods here to return IMethod, but not ICallSite
        // tho luckily it can be done automatically and won't poison intellisense

        // differences in behavior:
        // 1. [Name + signature] is a unique key => but we need to check it in a deferred manner
        // 2. Methods are created as instance ones by default (i.e. accept this, and can be bound)
    }
}