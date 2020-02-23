namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class DeleteUserParameterProvider
    {
        public string Id { get; } = "@Id";
        public string DeletedBy { get; } = "@DeletedBy";
    }
}
