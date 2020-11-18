namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Representation of a Permission in the system
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsApiPermission { get; set; }
        public string ApiDomain { get; set; }
        public string ApiController { get; set; }
        public string ApiAction { get; set; }
        public bool IsDatabasePermission { get; set; }
        public string DatabaseSchema { get; set; }
        public string DatabaseProcedure { get; set; }
    }
}
