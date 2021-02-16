using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class User : EntityBase, IName, IIdInt32
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string SecurePassword { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }

        public ICollection<UserApplication> Applications { get; set; } = new List<UserApplication>();
        public ICollection<UserPermission> Permissions { get; set; } = new List<UserPermission>();
        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
