namespace Sorschia.Entities
{
    public interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
        string SecurePassword { get; set; }
        string EmailAddress { get; set; }
        string MobileNumber { get; set; }
        bool IsActive { get; set; }
        bool IsPasswordChangeRequired { get; set; }
        bool IsEmailAddressVerified { get; set; }
        bool IsMobileNumberVerified { get; set; }
    }
}
