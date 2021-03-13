namespace Sorschia.Entities
{
    public interface IUserPermission
    {
        long Id { get; set; }
        int UserId { get; set; }
        int PermissionId { get; set; }
    }
}
