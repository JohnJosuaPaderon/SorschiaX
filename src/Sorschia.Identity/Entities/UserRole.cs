namespace Sorschia.Identity.Entities
{
    public class UserRole : UserRoleBase
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }

    public abstract class UserRoleBase
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
