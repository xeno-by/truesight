using System;
using System.Linq.Expressions;
using Truesight.Core;

namespace Truesight.Api.Meta.Attrs
{
    public interface IAttrs : IUpdatable<Attribute>
    {
        IHaveAttrs Host { get; }

        IAttrs<T> OfType<T>()
            where T : Attribute;

        // when the decompiler is ready we can remove this "Expression" part
        IAttrs Add(Expression<Func<Attribute>> ctor);
    }

    public interface IAttrs<T> : IUpdatable<T>
        where T : Attribute
    {
        IHaveAttrs Host { get; }

        // when the decompiler is ready we can remove this "Expression" part
        IAttrs<T> Add(Expression<Func<T>> ctor);

        // regular insert gets decomposed and transformed into a set of assignments
        // to current values of properties of passed attribute instance (won't always work!)
    }
}