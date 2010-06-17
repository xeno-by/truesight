using System.Collections.Generic;
using Truesight.Api.Meta.Core;

namespace Truesight.Api.Meta.Generics
{
    public interface ICanBeGeneric<T>
        where T : ICanBeGeneric<T>
    {
        // the following two properties work recursively
        // unlike in System.Reflection/System.Reflection.Emit
        bool IsGenuine { get; }
        bool IsSurrogate { get; }

        T Prototype { get; }
        T Derive(params IType[] typeArgs); // auto-detects mixed ctx and own type args
        T Derive(IEnumerable<IType> typeArgs);
        T Derive(IEnumerable<IType> ctxtypeArgs, IEnumerable<IType> typeArgs);
        // things like Derive<T...>() certainly won't hurt as an alternative for Derive(T...)

        ITypeArgs<T> TypeArgs { get; }
        ITypeArgs<T> CtxTypeArgs { get; }
        IStructure<T> Structure { get; }
    }
}