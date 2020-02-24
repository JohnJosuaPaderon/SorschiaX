namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class GetUserApplicationListParameterProvider
    {
        public string FilterByApproved { get; } = "@FilterByApproved";
        public string IsApproved { get; } = "@IsApproved";
        public string FilterByUser { get; } = "@FilterByUser";
        public string UserIdList { get; } = "@UserIdList";
        public string FilterByApplication { get; } = "@FilterByApplication";
        public string ApplicationIdList { get; } = "@ApplicationIdList";
    }
}
