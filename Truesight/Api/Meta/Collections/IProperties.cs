using Truesight.Api.Dynamic.Collections;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    public interface IProperties : ISlots, IHaveParent<ITypes>, IUpdatable<IProperty>
    {
        // we need to overload a lot of methods here to return IProperty, but not ISlot
        // tho luckily it can be done automatically and won't poison intellisense
    }
}