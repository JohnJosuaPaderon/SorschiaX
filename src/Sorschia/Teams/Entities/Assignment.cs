using System.Collections.Generic;

namespace Sorschia.Teams.Entities
{
    public class Assignment : AssignmentBase
    {
        public IEnumerable<AssignmentStep> Steps { get; set; }
        public IEnumerable<TeamAssignment> TeamAssignments { get; set; }
        public IEnumerable<MemberAssignment> MemberAssignments { get; set; }
    }
}
