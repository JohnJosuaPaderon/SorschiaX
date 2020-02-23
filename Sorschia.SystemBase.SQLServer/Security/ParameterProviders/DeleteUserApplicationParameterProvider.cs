namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class DeleteUserApplicationParameterProvider
    {
        public string Id { get; } = "@Id";
        public string DeletedBy { get; } = "@DeletedBy";
    }
}
