namespace Sorschia.SystemCore.Entities
{
    /// <summary>
    /// Representation of a Module of an <see cref="Entities.Application"/>
    /// </summary>
    public class Module
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AngularRouteUrl { get; set; }

        public Application Application { get; set; }
    }
}
