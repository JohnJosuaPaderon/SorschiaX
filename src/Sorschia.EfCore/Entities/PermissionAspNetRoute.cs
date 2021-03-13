namespace Sorschia.Entities
{
    public class PermissionAspNetRoute : EntityBase
    {
        public long Id { get; set; }
        public string AspNetArea { get; set; }
        public string AspNetController { get; set; }
        public string AspNetAction { get; set; }
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }
    }
}
