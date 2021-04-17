using System;

namespace Sorschia.Teams.Entities
{
    public abstract class MemberAssignmentBase
    {
        public long Id { get; set; }
        public int MemberId { get; set; }
        public long AssignmentId { get; set; }
        public DateTimeOffset? AssignedOn { get; set; }
    }
}
