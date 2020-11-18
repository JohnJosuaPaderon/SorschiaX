namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Relational representation of an Application-Permission in the system
    /// </summary>
    public class ApplicationPermission
    {
        public long Id { get; set; }
        public int ApplicationId { get; set; }
        public int PermissionId { get; set; }

        public Application Application { get; set; }
        public Permission Permission { get; set; }
    }
}
