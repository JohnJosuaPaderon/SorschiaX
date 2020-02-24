namespace Sorschia.SystemBase.Security.FieldProviders
{
    internal sealed class GetUserModuleListFieldProvider
    {
        public string Id { get; } = "Id";
        public string UserId { get; } = "UserId";
        public string ModuleId { get; } = "ModuleId";
        public string IsApproved { get; } = "IsApproved";
        public string TotalCount { get; } = "TotalCount";
    }
}
