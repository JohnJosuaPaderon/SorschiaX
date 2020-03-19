using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SaveUserModuleParameterProvider
    {
        public string Id { get; } = "@Id";
        public string UserId { get; } = "@UserId";
        public string ModuleId { get; } = "@ModuleId";
        public string IsApproved { get; } = "@IsApproved";
        public SqlDbType Id_Type { get; } = SqlDbType.BigInt;
    }
}
