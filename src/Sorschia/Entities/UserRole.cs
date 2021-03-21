namespace Sorschia.Entities
{
    public class UserRole
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
