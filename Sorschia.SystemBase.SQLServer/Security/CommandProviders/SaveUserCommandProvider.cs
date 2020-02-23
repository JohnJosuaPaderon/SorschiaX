using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class SaveUserCommandProvider
    {
        public SaveUserCommandProvider(
            ICurrentUserProvider currrentUserProvider,
            IUserPasswordCryptoHash passwordCryptoHash,
            SaveUserParameterProvider parameterProvider)
        {
            _currentUserProvider = currrentUserProvider;
            _passwordCryptoHash = passwordCryptoHash;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IUserPasswordCryptoHash _passwordCryptoHash;
        private readonly SaveUserParameterProvider _parameterProvider;

        public SqlCommand Get(SystemUser user, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.SaveUser, transaction)
            .AddInOutParameter(_parameterProvider.Id, user.Id, _parameterProvider.Id_Type)
            .AddInParameter(_parameterProvider.FirstName, user.FirstName)
            .AddInParameter(_parameterProvider.MiddleName, user.MiddleName)
            .AddInParameter(_parameterProvider.LastName, user.LastName)
            .AddInParameter(_parameterProvider.Username, user.Username)
            .AddInParameter(_parameterProvider.HashedPassword, _passwordCryptoHash.Compute(user.Password))
            .AddInParameter(_parameterProvider.IsActive, user.IsActive)
            .AddInParameter(_parameterProvider.IsPasswordChangeRequired, user.IsPasswordChangeRequired)
            .AddInParameter(_parameterProvider.SavedBy, _currentUserProvider.GetUsername());
    }
}
