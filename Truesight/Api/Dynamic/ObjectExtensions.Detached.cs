using System;
using Truesight.Api.Dynamic.Collections;
using Truesight.Core;

namespace Truesight.Api.Dynamic
{
    // even in c# 4.0 this feature will remain useful
    // in fact, it's quite a common scenario to split reflection and invocation

    public static partial class ObjectExtensions
    {
        public static IBoundSlotsEnumerable Slots(this Object target)
        {
            throw new NotImplementedException();
        }

        public static IBoundCallSitesEnumerable CallSites(this Object target)
        {
            throw new NotImplementedException();
        }

        public static IBoundSlots Slots(this IDynamicMetaObjectProvider target)
        {
            throw new NotImplementedException();
        }

        public static IBoundCallSites CallSites(this IDynamicMetaObjectProvider target)
        {
            throw new NotImplementedException();
        }
    }
}
