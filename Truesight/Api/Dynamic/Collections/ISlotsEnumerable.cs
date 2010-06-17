using System;
using System.Collections.Generic;
using Truesight.Api.Dynamic.Core;

namespace Truesight.Api.Dynamic.Collections
{
    public interface ISlotsEnumerable : IEnumerable<ISlot>
    {
        ISlot this[String name] { get; }
        // name is a unique key here, unlike in ICallSites that doesn't have any unique key
    }
}