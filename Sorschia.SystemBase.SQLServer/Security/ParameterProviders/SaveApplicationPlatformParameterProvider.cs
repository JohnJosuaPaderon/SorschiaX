using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SaveApplicationPlatformParameterProvider
    {
        public string Id { get; } = "@Id";
        public string Name { get; } = "@Name";
        public string SavedBy { get; } = "@SavedBy";
        public SqlDbType Id_Type { get; } = SqlDbType.Int;
    }
}
