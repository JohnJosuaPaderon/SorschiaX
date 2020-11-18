namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Relational representation of User-Permission
    /// </summary>
    public class UserPermission
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
