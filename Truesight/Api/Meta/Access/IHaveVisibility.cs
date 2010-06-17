namespace Truesight.Api.Meta.Access
{
    public interface IHaveVisibility
    {
        Visibility Visibility { get; set; }

        bool IsPrivate { get; }
        bool IsProtected { get; }
        bool IsInternal { get; }
        bool IsProtectedAndInternal { get; }
        bool IsProtectedOrInternal { get; }
        bool IsPublic { get; }
    }
}