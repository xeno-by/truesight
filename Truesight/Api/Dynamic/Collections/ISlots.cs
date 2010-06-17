using System;
using Truesight.Api.Dynamic.Core;
using Truesight.Api.Meta.Core;
using Truesight.Core;

namespace Truesight.Api.Dynamic.Collections
{
    // points of extension:
    // 1. different overloads that capture different values of XenoGears' FA+PropA+MA enumeration
    //    that's really important since in real life use we 100% of time specify those
    // 2. overloads that allow to specify whether we create a field or a property
    // solution: IJustCreatedSlot that has fluent properties: Field.Public, or Property.NewSlot
    // also think about other things we can fluentize here
    // when adding props factories detect overrides and by default set them automatically

    public interface ISlots : ISlotsEnumerable, IUpdatable<ISlot>
    {
        ISlot Add(String name);
        ISlot Add(String name, IType type);
        ISlot<T> Add<T>(String name);
    }
}