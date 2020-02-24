namespace Sorschia.SystemBase.Security.FieldProviders
{
    internal sealed class GetUserListFieldProvider
    {
        public string Id { get; } = "Id";
        public string FirstName { get; } = "FirstName";
        public string MiddleName { get; } = "MiddleName";
        public string LastName { get; } = "LastName";
        public string Username { get; } = "Username";
        public string IsActive { get; } = "IsActive";
        public string IsPasswordChangeRequired { get; } = "IsPasswordChangeRequired";
        public string TotalCount { get; } = "TotalCount";
    }
}
