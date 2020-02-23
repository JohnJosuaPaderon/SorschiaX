namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class RemoveApplicationFromPlatformParameterProvider
    {
        public string ApplicationId { get; } = "@ApplicationId";
        public string UpdatedBy { get; } = "@UpdatedBy";
    }
}
