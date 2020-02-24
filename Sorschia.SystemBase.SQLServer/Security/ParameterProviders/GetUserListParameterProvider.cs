namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class GetUserListParameterProvider
    {
        public string Skip { get; } = "@Skip";
        public string Take { get; } = "@Take";
        public string FilterText { get; } = "@FilterText";
        public string FilterByActive { get; } = "@FilterByActive";
        public string IsActive { get; } = "@IsActive";
        public string FilterByPasswordChangeRequired { get; } = "@FilterByPasswordChangeRequired";
        public string IsPasswordChangeRequired { get; } = "@IsPasswordChangeRequired";
        public string SkippedIdList { get; set; } = "@SkippedIdList";
    }
}
