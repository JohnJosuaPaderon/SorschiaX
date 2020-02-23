namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class DeleteUserPermissionParameterProvider
    {
        public string Id { get; } = "@Id";
        public string DeletedBy { get; } = "@DeletedBy";
    }
}
