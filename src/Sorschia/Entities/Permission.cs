namespace Sorschia.Entities
{
    public class Permission : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ApplicationId { get; set; }
        public int? RoleId { get; set; }

        public Application Application { get; set; }
        public Role Role { get; set; }
    }
}
