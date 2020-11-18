namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Relational representation of Role-Permission
    /// </summary>
    public class RolePermission
    {
        public long Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
