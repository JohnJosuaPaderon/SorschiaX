using Sorschia.Data;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed partial class GetUserByCredentialsQuery
    {
        public sealed class Model
        {
            public string Username { get; set; }
            public string CipherPassword { get; set; }

            public static implicit operator Model(LoginUserModel source)
            {
                if (source is null) return null;

                return new Model
                {
                    Username = source.Username,
                    CipherPassword = source.CipherPassword
                };
            }
        }

        private const string PROCEDURE = "[SystemCore].[GetUserByCredentials]";
        private const string PARAM_USERNAME = "@Useername";
        private const string PARAM_PASSWORDHASH = "@PasswordHash";

        private readonly UserConverter _converter;
        private readonly IUserPasswordCryptoTransformer _passwordCryptoTransformer;

        public GetUserByCredentialsQuery(UserConverter converter, IUserPasswordCryptoTransformer passwordCryptoTransformer)
        {
            _converter = converter;
            _passwordCryptoTransformer = passwordCryptoTransformer;
        }

        public async Task<User> ExecuteAsync(Model model, SqlConnection connection, SqlTransaction transaction = default, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection, transaction);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            if (reader.HasRows && await reader.ReadAsync(cancellationToken))
                return _converter.Convert(reader);
            return default;
        }

        private SqlCommand CreateCommand(Model model, SqlConnection connection, SqlTransaction transaction = default) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInParameter(PARAM_USERNAME, model.Username)
            .AddInParameter(PARAM_PASSWORDHASH, _passwordCryptoTransformer.ComputeHash(model.CipherPassword));
    }
}
