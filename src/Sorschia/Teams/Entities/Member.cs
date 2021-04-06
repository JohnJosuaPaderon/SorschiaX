using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.Teams.Entities
{
    public class Member : MemberBase, IFullNameHolder
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }
        public IEnumerable<MemberAssignment> MemberAssignments { get; set; }
    }
}
