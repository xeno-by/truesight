using Truesight.Api.Dynamic.Core;
using Truesight.Api.Meta.Access;
using Truesight.Core;

namespace Truesight.Api.Meta.Core
{
    public interface IField : ISlot, IHaveParent<IType>, IHaveVisibility
    {
    }

    public interface IField<T> : IField, ISlot<T>
    {
    }
}