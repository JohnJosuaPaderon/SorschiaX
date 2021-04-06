namespace Sorschia.Teams.Entities
{
    public class TeamMember : TeamMemberBase
    {
        public Team Team { get; set; }
        public Member Member { get; set; }
    }
}
