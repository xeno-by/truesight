using System;
using Truesight.Api.Dynamic.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface IDynamicMethod : IHaveParent<IAsm>, ICallSite
    {
    }
}