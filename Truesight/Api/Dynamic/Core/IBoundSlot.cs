using System;

namespace Truesight.Api.Dynamic.Core
{
    public interface IBoundSlot : ISlot
    {
        // IsStatic (is inherited from ISlot)
        Object Target { get; set; }
        // Bind (is inherited from ISlot)
        ISlot Unbind();

        // CanRead (is inherited from ISlot)
        // CanWrite (is inherited from ISlot)
        new Object Value { get; }

        ISlot Original { get; }
        new IBoundSlot<T> Cast<T>();
    }

    public interface IBoundSlot<T> : IBoundSlot, ISlot<T>
    {
        // IsStatic (is inherited from ISlot)
        // Target (is inherited from IBoundSlot)
        // Bind (is inherited from ISlot<T>)
        new ISlot<T> Unbind();

        // CanRead (is inherited from ISlot)
        // CanWrite (is inherited from ISlot)
        new T Value { get; set; }

        // Original (is inherited from IBoundSlot)
        // Cast (is inherited from IBoundSlot)
    }
}