using Truesight.Api.Meta.Collections;

namespace Truesight.Api.Meta.Core
{
    public interface IAppDomain
    {
        IAsms Asms { get; }

        IDynamicMethods DynamicMethods { get; }
        // dynamic methods won't be persisted => it's an unhidable implementation detail
        // to be persisted they need to be inserted into some dynamic class (yeh, as easy as that)
        // then after reloading they can be just inserted back into asm.DynamicMethods collection
        // quite natural approach to codegen, ain't it?
    }
}
