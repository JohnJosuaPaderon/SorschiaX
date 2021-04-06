namespace Sorschia.Identity.Entities
{
    public abstract class UserRoleBase
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
