using Sorschia.Entities;

namespace Sorschia.Processes.Extensions
{
    public static class UpdateUserExtensions
    {
        public static void FromRequest(this User instance, UpdateUser? request, string fullName, bool includeId = false)
        {
            if (request is null) return;

            if (includeId)
                instance.Id = request.Id;

            instance.FirstName = request.FirstName;
            instance.MiddleName = request.MiddleName;
            instance.LastName = request.LastName;
            instance.NameSuffix = request.NameSuffix;
            instance.FullName = fullName;
            instance.Username = request.Username;
            instance.EmailAddress = request.EmailAddress;
            instance.MobileNumber = request.MobileNumber;
            instance.IsActive = request.IsActive;
            instance.IsPasswordChangeRequired = request.IsPasswordChangeRequired;
            instance.IsEmailAddressVerified = request.IsEmailAddressVerified;
            instance.IsMobileNumberVerified = request.IsMobileNumberVerified;
        }

        public static bool HasChanges(this User instance, UpdateUser? request, string fullName)
        {
            if (request is null) return false;

            return
                instance.FirstName != request.FirstName ||
                instance.MiddleName != request.MiddleName ||
                instance.LastName != request.LastName ||
                instance.NameSuffix != request.NameSuffix ||
                instance.FullName != fullName ||
                instance.Username != request.Username ||
                instance.EmailAddress != request.EmailAddress ||
                instance.MobileNumber != request.MobileNumber ||
                instance.IsActive != request.IsActive ||
                instance.IsPasswordChangeRequired != request.IsPasswordChangeRequired ||
                instance.IsEmailAddressVerified != request.IsEmailAddressVerified ||
                instance.IsMobileNumberVerified != request.IsMobileNumberVerified;
        }
    }
}
