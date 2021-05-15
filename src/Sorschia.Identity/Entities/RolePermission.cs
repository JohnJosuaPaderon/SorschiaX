namespace Sorschia.Identity.Entities
{
    public class RolePermission : RolePermissionBase
    {
        public Role? Role { get; set; }
        public Permission? Permission { get; set; }
    }

    public abstract class RolePermissionBase
    {
        public long Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
