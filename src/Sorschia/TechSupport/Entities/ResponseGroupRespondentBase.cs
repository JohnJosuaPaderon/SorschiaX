using System;

namespace Sorschia.TechSupport.Entities
{
    public abstract class ResponseGroupRespondentBase
    {
        public long Id { get; set; }
        public int ResponseGroupId { get; set; }
        public int RespondentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
