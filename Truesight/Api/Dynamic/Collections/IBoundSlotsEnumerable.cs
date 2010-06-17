using System;
using System.Collections.Generic;
using Truesight.Api.Dynamic.Core;

namespace Truesight.Api.Dynamic.Collections
{
    public interface IBoundSlotsEnumerable : ISlotsEnumerable, IEnumerable<IBoundSlot>
    {
        Object Target { get; }
    }
}