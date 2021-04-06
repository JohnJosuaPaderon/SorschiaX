using System.Collections.Generic;

namespace Sorschia.Teams.Entities
{
    public class Team : TeamBase
    {
        public Member Leader { get; set; }
        public IEnumerable<TeamMember> TeamMembers { get; set; }
    }
}
