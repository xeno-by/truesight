using Truesight.Api.Dynamic.Core;
using Truesight.Api.Meta.Hierarchy;
using Truesight.Api.Meta.Access;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface IProperty : ISlot, IHaveParent<IType>, IHierarchy<IProperty>, IHaveVisibility
    {
        IMethod Getter { get; set; }
        IMethod Setter { get; set; }
        // also add an extension for IMethod: EnclosingProperty
    }

    public interface IProperty<T> : IProperty, ISlot<T>, IHierarchy<IProperty<T>>
    {
    }
}