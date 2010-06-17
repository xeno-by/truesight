using System;
using Truesight.Api.Meta.Attrs;
using Truesight.Api.Meta.Core;

namespace Truesight.Api.Dynamic.Core
{
    public interface ISlot : IHaveAttrs
    {
        String Name { get; set; }
        IType Type { get; set; }

        bool IsStatic { get; set; }
        // Target (not present in ISlot)
        IBoundSlot Bind(Object target);
        // Unbind (not present in ISlot)

        bool CanRead { get; set; }
        bool CanWrite { get; set; }
        ISlotValue Value { get; }

        // Original (not present in ISlot)
        ISlot<T> Cast<T>();
    }

    public interface ISlot<T> : ISlot
    {
        // IsStatic (is inherited from ISlot)
        // Target (not present in ISlot<T>)
        new IBoundSlot<T> Bind(Object target);
        // Unbind (not present in ISlot<T>)

        // CanRead (is inherited from ISlot)
        // CanWrite (is inherited from ISlot)
        new ISlotValue<T> Value { get; }

        ISlot Original { get; }
        // Cast (is inherited from ISlot)
    }
}