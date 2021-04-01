using Dapper;
using MediatR;
using Sorschia.Data;
using Sorschia.Processes.Results;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class GetUserHandler : IRequestHandler<GetUser, GetUserResult>
    {
        private readonly SqlConnectionProvider _connectionProvider;

        private static readonly Type[] _userApplicationTypes = new[]
        {
            typeof(GetUserResult.UserApplicationObj),
            typeof(GetUserResult.ApplicationObj)
        };
        private static readonly Type[] _userRoleTypes = new[]
        {
            typeof(GetUserResult.UserRoleObj),
            typeof(GetUserResult.RoleObj)
        };
        private static readonly Type[] _userPermissionTypes = new[]
        {
            typeof(GetUserResult.UserPermissionObj),
            typeof(GetUserResult.PermissionObj)
        };

        public GetUserHandler(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<GetUserResult> Handle(GetUser request, CancellationToken cancellationToken)
        {
            using var connection = await _connectionProvider.OpenAsync(cancellationToken);
            using var reader = await connection.QueryMultipleAsync("dbo.GetUser", request.AsParams(), commandType: CommandType.StoredProcedure);

            var result = await reader.ReadSingleOrDefaultAsync<GetUserResult>();
            
            if (request.IncludeUserApplications)
            {
                result.UserApplications = reader.Read(_userApplicationTypes, MapToUserApplication);
                result.UserApplicationsTotalCount = await reader.ReadSingleAsync<TotalCountInt64>();
            }

            if (request.IncludeUserRoles)
            {
                result.UserRoles = reader.Read(_userRoleTypes, MapToUserRole);
                result.UserRolesTotalCount = await reader.ReadSingleAsync<TotalCountInt64>();
            }

            if (request.IncludeUserPermissions)
            {
                result.UserPermissions = reader.Read(_userRoleTypes, MapToUserPermission);
                result.UserPermissionsTotalCount = await reader.ReadSingleAsync<TotalCountInt64>();
            }

            return result;
        }

        private static GetUserResult.UserApplicationObj MapToUserApplication(object[] readerObjects)
        {
            if (readerObjects[0] is GetUserResult.UserApplicationObj userApplication)
            {
                if (readerObjects[1] is GetUserResult.ApplicationObj application)
                    userApplication.Application = application;

                return userApplication;
            }

            return null;
        }

        private static GetUserResult.UserRoleObj MapToUserRole(object[] readerObjects)
        {
            if (readerObjects[0] is GetUserResult.UserRoleObj userRole)
            {
                if (readerObjects[1] is GetUserResult.RoleObj role)
                    userRole.Role = role;
            }

            return null;
        }

        private static GetUserResult.UserPermissionObj MapToUserPermission(object[] readerObjects)
        {
            if (readerObjects[0] is GetUserResult.UserPermissionObj userPermission)
            {
                if (readerObjects[1] is GetUserResult.PermissionObj permission)
                    userPermission.Permission = permission;
            }

            return null;
        }
    }
}
