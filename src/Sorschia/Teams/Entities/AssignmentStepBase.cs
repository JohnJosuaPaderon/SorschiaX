using System;

namespace Sorschia.Teams.Entities
{
    public abstract class AssignmentStepBase
    {
        public long Id { get; set; }
        public long AssignmentId { get; set; }
        public string Description { get; set; }
        public int Ordinal { get; set; }
        public AssignmentStatus Status { get; set; }
        public DateTimeOffset? StartedOn { get; set; }
        public DateTimeOffset? FinishedOn { get; set; }
        public DateTimeOffset? CancelledOn { get; set; }
        public string CancellationRemarks { get; set; }
    }
}
