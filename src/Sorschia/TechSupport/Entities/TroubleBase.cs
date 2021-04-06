using System;

namespace Sorschia.TechSupport.Entities
{
    public abstract class TroubleBase
    {
        public long Id { get; set; }
        public string TicketNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TroubleStatus Status { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? StartedOn { get; set; }
        public DateTimeOffset? FinishedOn { get; set; }
        public DateTimeOffset? CancelledOn { get; set; }
        public string CancellationRemarks { get; set; }
    }
}
