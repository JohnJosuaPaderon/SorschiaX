using System.Collections.Generic;

namespace Sorschia.Entities
{
    /// <summary>
    /// Repesents a module of an <see cref="Entities.Application"/>
    /// </summary>
    public class Module : EntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ApplicationId { get; set; }

        public virtual Application? Application { get; set; }

        public virtual IList<User>? Users { get; set; }

        // Configuration
        internal const int Name_MaxLength = 50;
        internal const int Description_MaxLength = 500;
    }
}
