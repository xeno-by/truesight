using System;

namespace Truesight.Api.Dynamic.Core
{
    // once ISlotValue had a property linking to its parent slot
    // but omg it's unnecessary, since who in their right mind
    // would pass around ISlotValue when they can just mess with ISlot

    public interface ISlotValue
    {
        Object this[Object target] { get; set; }
    }

    public interface ISlotValue<TValue> : ISlotValue
    {
        new TValue this[Object target] { get; set; }
    }
}