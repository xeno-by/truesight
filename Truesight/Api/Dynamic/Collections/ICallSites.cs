using System;
using Truesight.Api.Dynamic.Core;
using Truesight.Core;

namespace Truesight.Api.Dynamic.Collections
{
    // points of extension:
    // 1. different overloads that capture different values of XenoGears' MA enumeration
    //    that's really important since in real life use we 100% of time specify those
    // solution: IJustCreatedMethod that has fluent properties: 
    // Protected.Sealed, or Private.Ctor, or Static, or Operator.Add
    // also think about other things we can fluentize here

    public interface ICallSites : ICallSitesEnumerable, IUpdatable<ICallSite>
    {
        ICallSite Add(Type signature); // for declaring ctors and operators
        ICallSite Add(String name, Type signature);
        ICallSite Add(ICallSite callsite);
        ICallSite Add(String name, ICallSite callsite);
        // also add shitloads of overloads for typed callsites
        // also add shitloads of overloads for lambdas (implicit casts ala λ -> callsite won't help!)
        // 1. those overloads will also examine body and emit it if it ain't empty or default(TResult)
        // 2. factories detect overrides and by default set them automatically
        // 3. one can also use special types: Mk, to denote method's own generic parameters,
        //    and Tk or Uk (since Tk might be in use) to denote declaring type generic parameters
        // also we need to process special names like "+" and translate them into canonical equivalents
    }
}