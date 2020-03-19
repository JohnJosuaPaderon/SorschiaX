namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class DeleteApplicationParameterProvider
    {
        public string Id { get; } = "@Id";
        public string IsCascaded { get; } = "@IsCascaded";
    }
}
