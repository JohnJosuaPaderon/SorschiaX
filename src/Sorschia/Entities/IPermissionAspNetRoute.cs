namespace Sorschia.Entities
{
    public interface IPermissionAspNetRoute
    {
        long Id { get; set; }
        public int PermissionId { get; set; }
        string? AspNetArea { get; set; }
        string AspNetController { get; set; }
        string AspNetAction { get; set; }
    }
}
