using System.Collections.Generic;

namespace Sorschia.Entities
{
    /// <summary>
    /// Represents a role of a <see cref="User"/>
    /// </summary>
    public class Role : EntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual IList<User>? Users { get; set; }

        // Configuration
        internal const int Name_MaxLength = 50;
        internal const int Description_MaxLength = 500;
    }
}
