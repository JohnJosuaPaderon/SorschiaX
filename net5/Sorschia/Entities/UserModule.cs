namespace Sorschia.Entities
{
    /// <summary>
    /// Represents a relation between <see cref="Entities.User"/> and <see cref="Entities.Module"/>
    /// </summary>
    public class UserModule : EntityBase
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        
        public virtual User? User { get; set; }
        public virtual Module? Module { get; set; }
    }
}
