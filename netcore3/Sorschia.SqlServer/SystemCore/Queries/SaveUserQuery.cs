using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveUserQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveUser]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_FIRSTNAME = "@FirstName";
        private const string PARAM_MIDDLENAME = "@MiddleName";
        private const string PARAM_LASTNAME = "@LastName";
        private const string PARAM_NAMEEXTENSION = "@NameExtension";
        private const string PARAM_USERNAME = "@Username";
        private const string PARAM_NEWPASSWORDHASH = "@NewPasswordHash";
        private const string PARAM_OLDPASSWORDHASH = "@OldPasswordHash";
        private const string PARAM_ISACTIVE = "@IsActive";
        private const string PARAM_ISPASSWORDCHANGEREQUIRED = "@IsPasswordChangeRequired";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;
        private readonly IUserPasswordCryptoTransformer _passwordCryptoTransformer;

        public SaveUserQuery(ISessionProvider sessionProvider, IUserPasswordCryptoTransformer passwordCryptoTransformer)
        {
            _sessionProvider = sessionProvider;
            _passwordCryptoTransformer = passwordCryptoTransformer;
        }

        public async Task<User> ExecuteAsync(SaveUserModel.UserObj user, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(user, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            user.Id = command.Parameters.GetInt32(PARAM_ID);
            return user.Id != 0 ? user : null;
        }

        private SqlCommand CreateCommand(SaveUserModel.UserObj user, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, user.Id, SqlDbType.Int)
            .AddInParameter(PARAM_FIRSTNAME, user.FirstName)
            .AddInParameter(PARAM_MIDDLENAME, user.MiddleName)
            .AddInParameter(PARAM_LASTNAME, user.LastName)
            .AddInParameter(PARAM_NAMEEXTENSION, user.NameExtension)
            .AddInParameter(PARAM_USERNAME, user.Username)
            .AddInParameter(PARAM_NEWPASSWORDHASH, _passwordCryptoTransformer.ComputeHash(user.CipherNewPassword))
            .AddInParameter(PARAM_OLDPASSWORDHASH, _passwordCryptoTransformer.ComputeHash(user.CipherOldPassword))
            .AddInParameter(PARAM_ISACTIVE, user.IsActive)
            .AddInParameter(PARAM_ISPASSWORDCHANGEREQUIRED, user.IsPasswordChangeRequired)
            .AddSessionIdParameter(_sessionProvider);
    }
}
