namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class DeleteApplicationPlatformParameterProvider
    {
        public string Id { get; } = "@Id";
        public string IsCascaded { get; } = "@IsCascaded";
        public string DeletedBy { get; } = "@DeletedBy";
    }
}
