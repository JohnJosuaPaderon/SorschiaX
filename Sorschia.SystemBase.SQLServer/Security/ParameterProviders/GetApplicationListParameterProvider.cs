namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class GetApplicationListParameterProvider
    {
        public string Skip { get; } = "@Skip";
        public string Take { get; } = "@Take";
        public string FilterText { get; } = "@FilterText";
        public string FilterByPlatform { get; } = "@FilterByPlatform";
        public string PlatformIdList { get; } = "@PlatformIdList";
        public string SkippedIdList { get; } = "@SkippedIdList";
    }
}
