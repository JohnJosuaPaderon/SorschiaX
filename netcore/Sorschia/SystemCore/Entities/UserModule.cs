namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Relational representation of User-Module
    /// </summary>
    public class UserModule
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }

        public User User { get; set; }
        public Module Module { get; set; }
    }
}
