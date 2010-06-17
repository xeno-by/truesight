using System;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    public interface IAsms : IHaveParent<IAppDomain>, IUpdatable<IAsm>
    {
        IAsm this[String nameOrUrl] { get; }

        IAsm Load(String nameOrUrl);
        IAsm Inspect(String nameOrUrl);
        IAsm Define(String nameOrUrl);
        // regular insert won't work - the only way is to Load/Inspect/Define(String)
        // q: what if load/inspect/define receives a name of already loaded asm?
        // a: crashes if anything is passed to Define, crashes if loaded is passed to Inspect,
        //    otherwise gets completed successfully and returns already existing assembly
    }
}