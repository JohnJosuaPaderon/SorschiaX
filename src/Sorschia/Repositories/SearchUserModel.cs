namespace Sorschia.Repositories
{
    public class SearchUserModel : PaginationModel
    {
        public string FullNameFilter { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPasswordChangeRequired { get; set; }
        public bool? IsEmailAddressVerified { get; set; }
        public bool? IsMobileNumberVerified { get; set; }

        public bool IncludeActiveCount { get; set; }
        public bool IncludeRequiredPasswordChangeCount { get; set; }
        public bool IncludeVerifiedEmailAddressCount { get; set; }
        public bool IncludeVerifiedMobileNumberCount { get; set; }
    }
}
