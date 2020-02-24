namespace Sorschia.SystemBase.Security.FieldProviders
{
    internal sealed class GetUserPermissionListFieldProvider
    {
        public string Id { get; } = "Id";
        public string UserId { get; } = "UserId";
        public string PermissionId { get; } = "PermissionId";
        public string IsApproved { get; } = "IsApproved";
        public string TotalCount { get; } = "TotalCount";
    }
}
