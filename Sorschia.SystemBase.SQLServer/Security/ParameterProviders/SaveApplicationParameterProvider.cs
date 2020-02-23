using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SaveApplicationParameterProvider
    {
        public string Id { get; } = "@Id";
        public string Name { get; } = "@Name";
        public string PlatformId { get; } = "@PlatformId";
        public string SavedBy { get; } = "@SavedBy";
        public SqlDbType Id_Type { get; } = SqlDbType.Int;
    }
}
