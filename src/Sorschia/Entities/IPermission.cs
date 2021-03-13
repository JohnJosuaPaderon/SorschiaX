namespace Sorschia.Entities
{
    public interface IPermission
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string LookupKey { get; set; }
        public short? ApplicationId { get; set; }
        public int? RoleId { get; set; }
    }
}
