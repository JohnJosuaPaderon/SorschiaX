namespace Sorschia.Entities
{
    public interface IPermission
    {
        int Id { get; set; }
        string Name { get; set; }
        string? Description { get; set; }
        string? LookupKey { get; set; }
        int? ApplicationId { get; set; }
        int? RoleId { get; set; }
    }
}
