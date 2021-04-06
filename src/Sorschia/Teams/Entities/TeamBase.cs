namespace Sorschia.Teams.Entities
{
    public abstract class TeamBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeaderId { get; set; }
    }
}
