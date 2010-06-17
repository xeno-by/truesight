using System;
using System.Collections.Generic;
using Truesight.Api.Dynamic.Core;

namespace Truesight.Api.Dynamic.Collections
{
    public interface IBoundCallSitesEnumerable : ICallSitesEnumerable, IEnumerable<IBoundCallSite>
    {
        Object Target { get; }
    }
}