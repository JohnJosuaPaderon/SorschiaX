using System.Data;

namespace Sorschia.SystemBase.Security.ParameterProviders
{
    internal sealed class SaveUserParameterProvider
    {
        public string Id { get; } = "@Id";
        public string FirstName { get; } = "@FirstName";
        public string MiddleName { get; } = "@MiddleName";
        public string LastName { get; } = "@LastName";
        public string Username { get; } = "@Username";
        public string HashedPassword { get; } = "@HashedPassword";
        public string IsActive { get; } = "@IsActive";
        public string IsPasswordChangeRequired { get; } = "@IsPasswordChangeRequired";
        public SqlDbType Id_Type { get; } = SqlDbType.Int;
    }
}
