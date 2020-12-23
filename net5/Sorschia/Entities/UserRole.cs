namespace Sorschia.Entities
{
    /// <summary>
    /// Represents a relation between <see cref="Entities.User"/> and <see cref="Entities.Role"/>
    /// </summary>
    public class UserRole : EntityBase
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
