namespace Sorschia.Identity.Entities
{
    public abstract class UserPermissionBase
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }
}
