using System;
using System.Collections.Generic;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    public interface IParams : IHaveParent<IMethod>, IEnumerable<IParam>
    {
        IParam this[int position] { get; }
        IParam this[String name] { get; }

        // we use IEnumerable<IParam> here, so the collection is read-only
        // this is reasonable since we use signatures to define methods
        // so making params collection to be mutable is YAGNI - after all
        // why should anyone want to change params collection after the method has been created?
    }
}