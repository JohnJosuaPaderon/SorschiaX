using Sorschia.Entities;

namespace Sorschia.TaskManagement.Entities
{
    public class GroupMember : EntityBase
    {
        public long Id { get; set; }
        public int GroupId { get; set; }
        public int MemberId { get; set; }

        public virtual Group Group { get; set; } = default!;
        public virtual Member Member { get; set; } = default!;
    }
}
