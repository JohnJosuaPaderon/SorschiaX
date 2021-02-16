namespace Sorschia.Entities
{
    public class UserPermission : EntityBase, IIdInt64
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
