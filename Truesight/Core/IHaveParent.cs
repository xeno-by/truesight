namespace Truesight.Core
{
    // see the following link for implementation details
    // onenote:///%NOTEBOOK LOCATION%\Infusion\Философия%20и%20концепции.one#IUpdatable%20-%202&section-id={3EB74ACB-EBFE-4C6B-9C44-7E5E44900BDB}&page-id={7F1B2381-7285-453C-95F6-F14CD85AA6ED}&end

    public interface IHaveParent<T>
    {
        T Parent { get; set; }
    }
}