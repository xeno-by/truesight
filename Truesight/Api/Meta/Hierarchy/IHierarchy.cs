using System.Collections.Generic;
using Truesight.Core;

namespace Truesight.Api.Meta.Hierarchy
{
    public interface IHierarchy<T>
        where T : IHierarchy<T>
    {
        bool IsAbstract { get; set; }

        T Base { get; set; }
        IUpdatable<T> Bases { get; }
        IEnumerable<T> Hierarchy { get; }
    }
}