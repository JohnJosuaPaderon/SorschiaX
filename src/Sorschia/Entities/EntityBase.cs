using System;

namespace Sorschia.Entities
{
    public abstract class EntityBase
    {
        public bool IsDeleted { get; set; }
        public int? InsertedById { get; set; }
        public DateTimeOffset? InsertedOn { get; set; }
        public int? UpdatedById { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public int? DeletedById { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        public User InsertedBy { get; set; }
        public User UpdatedBy { get; set; }
        public User DeletedBy { get; set; }
    }
}
