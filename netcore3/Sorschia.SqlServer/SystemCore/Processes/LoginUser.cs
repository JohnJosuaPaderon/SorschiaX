using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Data.SqlClient;
using System.Linq;
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
        private readonly SearchModuleQuery _searchModuleQuery;
        private readonly SearchPermissionQuery _searchPermissionQuery;
        private readonly GetApplicationQuery _getApplicationQuery;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public LoginUserModel Model { get; set; }

        public LoginUser(IConnectionStringProvider connectionStringProvider,
            GetUserByCredentialsQuery getUserByCredentialsQuery,
            StartSessionQuery startSessionQuery,
            SaveAccessTokenQuery saveAccessTokenQuery,
            SaveRefreshTokenQuery saveRefreshTokenQuery,
            SearchModuleQuery searchModuleQuery,
            SearchPermissionQuery searchPermissionQuery,
            GetApplicationQuery getApplicationQuery,
            IAccessTokenGenerator accessTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator) : base(connectionStringProvider)
        {
            _getUserByCredentialsQuery = getUserByCredentialsQuery;
            _startSessionQuery = startSessionQuery;
            _saveAccessTokenQuery = saveAccessTokenQuery;
            _saveRefreshTokenQuery = saveRefreshTokenQuery;
            _searchModuleQuery = searchModuleQuery;
            _searchPermissionQuery = searchPermissionQuery;
            _getApplicationQuery = getApplicationQuery;
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
                await GetModulesAsync(result, connection, transaction, cancellationToken);
                await GetPermissionsAsync(result, connection, transaction, cancellationToken);
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
            var application = await _getApplicationQuery.ExecuteAsync(model.ApplicationId, connection, transaction, cancellationToken);

            if (user is null)
                throw new SorschiaException("Username or password are incorrect", true);

            if (application is null)
                throw new SorschiaException("Application is incorrect", true);

            result.User = user;
            result.Application = application;

            var session = new Session
            {
                UserId = user.Id,
                ApplicationId = model.ApplicationId
            };

            var _session = await _startSessionQuery.ExecuteAsync(session, connection, transaction, cancellationToken);

            if (_session is null)
                throw SorschiaException.VariableIsNull<Session>(nameof(_session));

            result.Session = _session;

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

        private async Task GetModulesAsync(LoginUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var searchModel = new SearchModuleModel();
            var searchResult = new SearchModuleResult();

            searchModel.ApplicationIds.Add(result.Session.ApplicationId ?? 0);
            searchModel.UserIds.Add(result.Session.UserId ?? 0);

            await _searchModuleQuery.ExecuteAsync(searchModel, searchResult, connection, transaction, cancellationToken);

            if (searchResult.Modules != null && searchResult.Modules.Any())
                result.Modules = searchResult.Modules;
        }

        private async Task GetPermissionsAsync(LoginUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var searchModel = new SearchPermissionModel();
            var searchResult = new SearchPermissionResult();

            searchModel.UserIds.Add(result.Session.UserId ?? 0);

            await _searchPermissionQuery.ExecuteAsync(searchModel, searchResult, connection, transaction, cancellationToken);

            if (searchResult.Permissions != null && searchResult.Permissions.Any())
                result.Permissions = searchResult.Permissions;
        }
    }
}
