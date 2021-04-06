using System;

namespace Sorschia.Teams.Entities
{
    public abstract class TeamAssignmentBase
    {
        public long Id { get; set; }
        public int TeamId { get; set; }
        public long AssignmentId { get; set; }
        public DateTimeOffset? AssignedOn { get; set; }
    }
}
