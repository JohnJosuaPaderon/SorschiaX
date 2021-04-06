namespace Sorschia.Teams.Entities
{
    public class TeamAssignment : TeamAssignmentBase
    {
        public Team Team { get; set; }
        public Assignment Assignment { get; set; }
    }
}
