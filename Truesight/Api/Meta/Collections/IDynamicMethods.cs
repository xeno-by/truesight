using Truesight.Api.Dynamic.Collections;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    // needs to be implemented via weak references

    public interface IDynamicMethods : ICallSites, IHaveParent<IAsm>, IUpdatable<IMethod>
    {
        // we need to overload a lot of methods here to return IDynamicMethod, but not ICallSite
        // tho luckily it can be done automatically and won't poison intellisense

        // behavior quirks:
        // 1. Methods are created static by default (i.e. accept no this, and cannot be bound)
    }
}