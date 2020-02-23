using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SaveUserApplicationParameterProvider
    {
        public string Id { get; } = "@Id";
        public string UserId { get; } = "@UserId";
        public string ApplicationId { get; } = "@ApplicationId";
        public string IsApproved { get; } = "@IsApproved";
        public string SavedBy { get; } = "@SavedBy";
        public SqlDbType Id_Type { get; } = SqlDbType.BigInt;
    }
}
