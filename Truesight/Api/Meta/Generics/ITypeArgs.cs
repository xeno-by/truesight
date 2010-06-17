using System;
using System.Collections.Generic;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Generics
{
    public interface ITypeArgs<T> : IHaveParent<T>, IEnumerable<T>
        where T : ICanBeGeneric<T>
    {
        IParam this[int position] { get; }
        IParam this[String name] { get; }

        // we use IEnumerable<IParam> here, so the collection is read-only
        // this is reasonable since we use gargs of factory methods to create generic types/methods
        // so making targs collection to be mutable is YAGNI - after all
        // why should anyone want to change targs collection after the type has been created?
    }
}