using Truesight.Api.Dynamic.Core;
using Truesight.Core;

namespace Truesight.Api.Dynamic.Collections
{
    public interface IBoundSlots : ISlots, IBoundSlotsEnumerable, IUpdatable<IBoundSlot>
    {
    }
}