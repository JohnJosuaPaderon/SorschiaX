namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class DeletePermissionParameterProvider
    {
        public string Id { get; } = "@Id";
        public string DeletedBy { get; } = "@DeletedBy";
    }
}
