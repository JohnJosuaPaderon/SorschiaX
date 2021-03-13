namespace Sorschia.Entities
{
    public interface IPermission
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string LookupKey { get; set; }
        IApplication Application { get; set; }
        IRole Role { get; set; }
    }
}
