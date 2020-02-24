namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class GetUserModuleListParameterProvider
    {
        public string FilterByApproved { get; } = "@FilterByApproved";
        public string IsApproved { get; } = "@IsApproved";
        public string FilterByUser { get; } = "@FilterByUser";
        public string UserIdList { get; } = "@UserIdList";
        public string FilterByModule { get; } = "@FilterByModule";
        public string ModuleIdList { get; } = "@ModuleIdList";
    }
}
