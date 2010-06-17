using System;
using System.Collections.Generic;
using Truesight.Api.Meta.Generics;

namespace Truesight.Api.Dynamic.Core
{
    public interface IBoundCallSite : ICallSite, ICanBeGeneric<IBoundCallSite>
    {
        // IsStatic (is inherited from ICallSite)
        Object Target { get; set; }
        // Bind (is inherited from ICallSite)
        ICallSite Unbind();

        Object Invoke(params Object[] args);
        Object Invoke(IEnumerable<Object> args);
        // 1. callsites cannot be abstract - tho their implementations for "target" can be
        // 2. sometimes we ain't need to call Derive even if the callsite is a surrogate generic
        // Microsoft.CSharp is so awesome that it'll infer typeargs correctly if it can be done

        ICallSite Original { get; }
        // shitloads of various casts (jeez...)
    }

    // here we need to add shitloads of different IBoundCallSite<...> classes for Action<...> and Func<...>
    // and all of those need personal bound/unbound signatures as well, omg...
    // also those need personal implementations of ICanBeGeneric<IBoundCallSite<...>>
    // see ICallSite.cs file for some implementation tips
}