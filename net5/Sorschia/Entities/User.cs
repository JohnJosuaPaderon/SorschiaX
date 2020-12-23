using System.Collections.Generic;

namespace Sorschia.Entities
{
    /// <summary>
    /// Represents a user of an application
    /// </summary>
    public class User : EntityBase
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? NameExtension { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? EmailAddress { get; set; }
        public string CipherPassword { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsPasswordChangeRequired { get; set; }

        public virtual IList<Role> Roles { get; set; } = new List<Role>();
        public virtual IList<Module> Modules { get; set; } = new List<Module>();

        // Configuration
        internal const int FirstName_MaxLength = 30;
        internal const int MiddleName_MaxLength = 30;
        internal const int LastName_MaxLength = 30;
        internal const int NameExtesion_MaxLength = 5;
        internal const int FullName_MaxLength = 100;
        internal const int Username_MaxLength = 30;
    }
}
