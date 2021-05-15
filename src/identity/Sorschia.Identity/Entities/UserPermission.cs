namespace Sorschia.Identity.Entities
{
    public class UserPermission : UserPermissionBase
    {
        public User? User { get; set; }
        public Permission? Permission { get; set; }
    }

    public abstract class UserPermissionBase
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }
}
