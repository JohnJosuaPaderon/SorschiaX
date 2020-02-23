using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SaveUserPermissionParameterProvider
    {
        public string Id { get; } = "@Id";
        public string UserId { get; } = "@UserId";
        public string PermissionId { get; } = "@PermissionId";
        public string IsApproved { get; } = "@IsApproved";
        public string SavedBy { get; } = "@SavedBy";
        public SqlDbType Id_Type { get; } = SqlDbType.BigInt;
    }
}
