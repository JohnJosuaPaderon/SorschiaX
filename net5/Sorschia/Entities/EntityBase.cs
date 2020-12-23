using System;

namespace Sorschia.Entities
{
    /// <summary>
    /// Provides common entity fields
    /// </summary>
    public abstract class EntityBase
    {
        public bool IsDeleted { get; set; }
        public int? InsertedById { get; set; }
        public DateTimeOffset? InsertedOn { get; set; }
        public int? UpdatedById { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public int? DeletedById { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        public virtual User? InsertedBy { get; set; }
        public virtual User? UpdatedBy { get; set; }
        public virtual User? DeletedBy { get; set; }
    }
}
