using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class LoginUser : ProcessBase, ILoginUser
    {
        private readonly GetUserByCredentialsQuery _getUserByCredentialsQuery;
        private readonly StartSessionQuery _startSessionQuery;
        private readonly SaveAccessTokenQuery _saveAccessTokenQuery;
        private readonly SaveRefreshTokenQuery _saveRefreshTokenQuery;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public LoginUserModel Model { get; set; }

        public LoginUser(IConnectionStringProvider connectionStringProvider,
            GetUserByCredentialsQuery getUserByCredentialsQuery,
            StartSessionQuery startSessionQuery,
            SaveAccessTokenQuery saveAccessTokenQuery,
            SaveRefreshTokenQuery saveRefreshTokenQuery,
            IAccessTokenGenerator accessTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator) : base(connectionStringProvider)
        {
            _getUserByCredentialsQuery = getUserByCredentialsQuery;
            _startSessionQuery = startSessionQuery;
            _saveAccessTokenQuery = saveAccessTokenQuery;
            _saveRefreshTokenQuery = saveRefreshTokenQuery;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<LoginUserResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new LoginUserResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await StartSessionAsync(model, result, connection, transaction, cancellationToken);
                await GenerateAccessTokenAsync(result, connection, transaction, cancellationToken);
                await GenerateRefreshTokenAsync(result, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }

        private async Task StartSessionAsync(LoginUserModel model, LoginUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var user = await _getUserByCredentialsQuery.ExecuteAsync(model, connection, transaction, cancellationToken);

            if (user is null)
                throw SorschiaException.VariableIsNull<User>(nameof(user));

            var session = new Session
            {
                UserId = user.Id,
                ApplicationId = model.ApplicationId
            };

            var _session = await _startSessionQuery.ExecuteAsync(session, connection, transaction, cancellationToken);

            if (_session is null)
                throw SorschiaException.VariableIsNull<Session>(nameof(_session));

            result.Session = session;

        }

        private async Task GenerateAccessTokenAsync(LoginUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var accessToken = _accessTokenGenerator.Generate(result.Session);
            var _accessToken = await _saveAccessTokenQuery.ExecuteAsync(accessToken, connection, transaction, cancellationToken);

            if (_accessToken is null)
                throw SorschiaException.VariableIsNull<AccessToken>(nameof(_accessToken));

            result.AccessToken = _accessToken;
        }

        private async Task GenerateRefreshTokenAsync(LoginUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var refreshToken = _refreshTokenGenerator.Generate(result.AccessToken);
            var _refreshToken = await _saveRefreshTokenQuery.ExecuteAsync(refreshToken, connection, transaction, cancellationToken);

            if (_refreshToken is null)
                throw SorschiaException.VariableIsNull<RefreshToken>(nameof(_refreshToken));

            result.RefreshToken = _refreshToken;
        }
    }
}
