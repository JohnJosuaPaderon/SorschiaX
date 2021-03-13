namespace Sorschia.Entities
{
    public interface IUserApplication
    {
        long Id { get; set; }
        IUser User { get; set; }
        IApplication Application { get; set; }
    }

    public interface IUserRole
    {
        long Id { get; set; }
        IUser User { get; set; }
        IRole Role { get; set; }
    }
}
