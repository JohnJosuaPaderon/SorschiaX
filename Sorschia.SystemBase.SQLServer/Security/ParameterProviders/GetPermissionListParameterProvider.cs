namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class GetPermissionListParameterProvider
    {
        public string Skip { get; } = "@Skip";
        public string Take { get; } = "@Take";
        public string FilterText { get; } = "@FilterText";
        public string SkippedIdList { get; } = "@SkippedIdList";
    }
}
