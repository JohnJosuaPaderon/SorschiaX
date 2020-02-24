namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class GetUserPermissionListParameterProvider
    {
        public string FilterByApproved { get; } = "@FilterByApproved";
        public string IsApproved { get; } = "@IsApproved";
        public string FilterByUser { get; } = "@FilterByUser";
        public string UserIdList { get; } = "@UserIdList";
        public string FilterByPermission { get; } = "@FilterByPermission";
        public string PermissionIdList { get; } = "@PermissionIdList";
    }
}
