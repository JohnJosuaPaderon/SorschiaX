namespace Sorschia.Entities
{
    public interface IPermissionAspNetRoute
    {
        long Id { get; set; }
        IPermission Permission { get; set; }
        string AspNetArea { get; set; }
        string AspNetController { get; set; }
        string AspNetAction { get; set; }
    }
}
