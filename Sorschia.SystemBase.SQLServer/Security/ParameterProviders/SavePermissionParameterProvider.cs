using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SavePermissionParameterProvider
    {
        public string Id { get; } = "@Id";
        public string Name { get; } = "@Name";
        public string Code { get; } = "@Code";
        public string SavedBy { get; } = "@SavedBy";
        public SqlDbType Id_Type { get; } = SqlDbType.Int;
    }
}
