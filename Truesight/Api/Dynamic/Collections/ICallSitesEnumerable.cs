using System;
using System.Collections.Generic;
using Truesight.Api.Dynamic.Core;

namespace Truesight.Api.Dynamic.Collections
{
    public interface ICallSitesEnumerable : IEnumerable<ICallSite>
    {
        ICallSite this[String name] { get; }
        ICallSite this[String name, Type signature] { get; }
        // 1. the "this[String]" signature should be late bound 
        // and perform second step of resolution when called Cast<T> or one of Invoke methods
        // otherwise - if we call its methods or properties - it will crash if ambiguous
        // upd. we shouldn't also crash when asked for Name and Parent
        // upd2. we could also successfully return a prop if it has the same value for the entire method group
        // upd3. late binding itself can be implemented via Microsoft.CSharp
        // 2. [name + signature] is not a unique key since this is just a bag of callsites
        //    however, most of type you'll be lucky and indexers will just work
        // 3. you cannot add generic properties, so no way you can use sigs here
    }
}