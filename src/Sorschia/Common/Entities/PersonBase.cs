using System;

namespace Sorschia.Common.Entities
{
    public abstract class PersonBase
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string FullName { get; set; }
        public bool? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsDeceased { get; set; }
    }
}
