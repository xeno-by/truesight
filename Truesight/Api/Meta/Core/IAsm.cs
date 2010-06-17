using System;
using Truesight.Api.Meta.Attrs;
using Truesight.Api.Meta.Collections;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface IAsm : IHaveParent<IAppDomain>, IHaveAttrs
    {
        bool InUse { get; }
        bool UnderInspection { get; }

        String Name { get; set; }
        Version Version { get; set; }
        String Url { get; }

        IResources Resources { get; }
        ITypes Types { get; }

        void Save(); // saves with with current url or at ".\{Name}" if it's a dynamic assembly
        void Save(String url);
    }
}
