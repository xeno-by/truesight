namespace Truesight.Core
{
    // plays the same role as in F#: provides semantic unification 
    // and cuts the number of redundant declarations by a factor of two
    //
    // these benefits far overweigh the fact that void-returning methods 
    // in certain contexts will suddenly become unit-returning 
    // (for more detailed example see ICallSite<...> classes)

    public abstract class Unit
    {
    }
}
