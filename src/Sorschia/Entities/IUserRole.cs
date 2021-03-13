namespace Sorschia.Entities
{
    public interface IUserRole
    {
        long Id { get; set; }
        int UserId { get; set; }
        int RoleId { get; set; }
    }
}
