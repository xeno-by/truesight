using Truesight.Api.Dynamic.Collections;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    public interface ICtors : ICallSites, IHaveParent<IType>, IUpdatable<ICtor>
    {
        // we need to overload a lot of methods here to return ICtor, but not ICallSite
        // tho luckily it can be done automatically and won't poison intellisense

        // differences in behavior:
        // 1. Name cannot be specified => it'll crash otherwise
        // 2. Signature is a unique key => but we need to check it in a deferred manner
        // 3. Ctors cannot be set Instance/Static, cannot be generic
        // 4. Ctors behave as static factory methods, but their implementation can contain @this
    }
}