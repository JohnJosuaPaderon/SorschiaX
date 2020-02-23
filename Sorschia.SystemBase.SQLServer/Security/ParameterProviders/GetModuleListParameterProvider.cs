namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class GetModuleListParameterProvider
    {
        public string Skip { get; } = "@Skip";
        public string Take { get; } = "@Take";
        public string FilterText { get; } = "@FilterText";
        public string FilterByApplication { get; } = "@FilterByApplication";
        public string ApplicationIdList { get; } = "@ApplicationIdList";
        public string SkippedIdList { get; } = "@SkippedIdList";
    }
}
