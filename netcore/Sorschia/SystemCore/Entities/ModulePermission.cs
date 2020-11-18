namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Relational representation of a Module-Permission
    /// </summary>
    public class ModulePermission
    {
        public long Id { get; set; }
        public int ModuleId { get; set; }
        public int PermissionId { get; set; }

        public Module Module { get; set; }
        public Permission Permission { get; set; }
    }
}
