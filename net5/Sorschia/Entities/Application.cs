namespace Sorschia.Entities
{
    /// <summary>
    /// Represents an application of a system
    /// </summary>
    public class Application : EntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Platform Platform { get; set; }

        // Configuration
        internal const int Name_MaxLength = 50;
        internal const int Description_MaxLength = 500;
    }
}
