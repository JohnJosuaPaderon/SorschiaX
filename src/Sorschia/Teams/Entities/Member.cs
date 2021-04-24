using System.Collections.Generic;
using SystemBase.Entities;

namespace Sorschia.Teams.Entities
{
    public class Member : MemberBase, IFullNameHolder
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }
        public IEnumerable<MemberAssignment> MemberAssignments { get; set; }
    }
}
