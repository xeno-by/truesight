using System;
using System.IO;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    public interface IResources : IHaveParent<IAsm>, IUpdatable<IResource>
    {
        Stream this[String oneOfNames] { get; } // short, full
        IResource Add(String fullName, Stream content);
    }
}