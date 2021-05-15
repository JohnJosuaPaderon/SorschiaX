namespace Sorschia.Core.Entities
{
    public class Domain : DomainBase
    {
    }

    public class DomainBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
