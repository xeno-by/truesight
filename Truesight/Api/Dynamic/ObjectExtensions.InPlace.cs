using System;
using System.Collections.Generic;

namespace Truesight.Api.Dynamic
{
    // we don't need Slots2 and CallSites2 here, because they're very much redundant:
    // * o.Get("_x") vs o.Slots2()["_x"]
    // * o.Set("_x", 1) vs o.Slots2()["_x"] = 1
    // * o.Invoke("Add", 1, 2) vs o.CallSites2()["Add"].Invoke(1, 2)
    
    // I wish I could just add an extension indexer to "this object"
    // It would be overriden by actual instance methods if they exist, so no conflicts.

    // we don't need strong typing here because when performing in-place invocations
    // one only cares about doing it without extra typing

    // we purposely don't support providing generic arguments for invocations
    // since they spawn really a lot of overloads that just don't justify their presence
    // because they pollute intellisense and don't provide the only way to do something

    public static partial class ObjectExtensions
    {
        public static Object Get(this Object target, String name)
        {
            throw new NotImplementedException();
        }

        public static T Set<T>(this T target, String name, Object value)
        {
            throw new NotImplementedException();
        }

        public static Object Invoke(this Object target, String name, params Object[] args)
        {
            throw new NotImplementedException();
        }

        public static Object Invoke(this Object target, String name, IEnumerable<Object> args)
        {
            throw new NotImplementedException();
        }
    }
}
