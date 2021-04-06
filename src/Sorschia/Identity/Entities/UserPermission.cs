namespace Sorschia.Identity.Entities
{
    public class UserPermission : UserPermissionBase
    {
        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
