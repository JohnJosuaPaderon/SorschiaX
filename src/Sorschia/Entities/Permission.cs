namespace Sorschia.Entities
{
    public class Permission : EntityBase, IIdInt32
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ApplicationId { get; set; }
        public int? RoleId { get; set; }
        public string WebController { get; set; }
        public string WebAction { get; set; }

        public Application Application { get; set; }
        public Role Role { get; set; }
    }
}
