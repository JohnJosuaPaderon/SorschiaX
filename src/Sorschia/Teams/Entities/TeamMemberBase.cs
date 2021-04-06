using System;

namespace Sorschia.Teams.Entities
{
    public abstract class TeamMemberBase
    {
        public long Id { get; set; }
        public int TeamId { get; set; }
        public int MemberId { get; set; }
        public bool IsActive { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
