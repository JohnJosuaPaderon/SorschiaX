using System.Collections.Generic;

namespace Sorschia.Repositories
{
    public class EditUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string Username { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }

        public IList<int> ApplicationIds { get; set; } = new List<int>();
        public IList<int> PermissionIds { get; set; } = new List<int>();
        public IList<long> DeletedUserApplicationIds { get; set; } = new List<long>();
        public IList<long> DeletedUserPermissionIds { get; set; } = new List<long>();
    }
}
