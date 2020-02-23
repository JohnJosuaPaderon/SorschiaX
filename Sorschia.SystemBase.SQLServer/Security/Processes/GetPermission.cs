using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.FieldProviders;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class GetPermission : SQLProcessBase, IGetPermission
    {
        public GetPermission(
            IConnectionStringProvider connectionStringProvider,
            GetPermissionCommandProvider getPermissionCommandProvider,
            GetPermissionFieldProvider getPermissionFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getPermissionCommandProvider = getPermissionCommandProvider;
            _getPermissionFieldProvider = getPermissionFieldProvider;
        }

        private readonly GetPermissionCommandProvider _getPermissionCommandProvider;
        private readonly GetPermissionFieldProvider _getPermissionFieldProvider;

        public int Id { get; set; }

        private SystemPermission ReadPermission(SqlDataReader reader) =>
            new SystemPermission
            {
                Id = reader.GetInt32(_getPermissionFieldProvider.Id),
                Name = reader.GetString(_getPermissionFieldProvider.Name),
                Code = reader.GetString(_getPermissionFieldProvider.Code)
            };

        private async Task<SystemPermission> ExecuteGetPermissionAsync(int id, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getPermissionCommandProvider.Get(id, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            return (reader.HasRows && await reader.ReadAsync(cancellationToken)) ? ReadPermission(reader) : default;
        }

        public async Task<SystemPermission> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await ExecuteGetPermissionAsync(id, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
