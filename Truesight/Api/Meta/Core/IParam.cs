using System;
using Truesight.Api.Meta.Attrs;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface IParam : IHaveParent<IMethod>, IHaveAttrs
    {
        int Position { get; }

        String Name { get; set; }
        IType Type { get; set; }
    }
}