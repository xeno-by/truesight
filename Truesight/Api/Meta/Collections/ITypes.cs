using System;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Meta.Collections
{
    // points of extension:
    // 1. different overloads that capture different values of XenoGears' TA enumeration
    //    that's really important since in real life use we 100% of time specify those
    // 2. overloads that allow to specify base classes/interfaces in-place
    //    that's not so important but would be nice
    // solution: IJustCreatedType that has fluent properties: Public.Static.Base(params IType[])
    // also think about other things we can fluentize here

    public interface ITypes : IHaveParent<IAsm>, IUpdatable<IType>
    {
        IType this[String oneOfNames] { get; } // short, full, assembly qualified
        IType Add(String fullName);
    }
}