namespace Sorschia.SystemBase.Security.FieldProviders
{
    internal sealed class GetUserApplicationListFieldProvider
    {
        public string Id { get; } = "Id";
        public string UserId { get; } = "UserId";
        public string ApplicationId { get; } = "ApplicationId";
        public string IsApproved { get; } = "IsApproved";
        public string TotalCount { get; } = "TotalCount";
    }
}
