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
    internal sealed class GetApplicationPlatform : SqlProcessBase, IGetApplicationPlatform
    {
        public GetApplicationPlatform(
            IConnectionStringProvider connectionStringProvider,
            GetApplicationPlatformCommandProvider getApplicationPlatformCommandProvider,
            GetApplicationPlatformFieldProvider getApplicationPlatformFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getApplicationPlatformCommandProvider = getApplicationPlatformCommandProvider;
            _getAppliationPlatformFieldProvider = getApplicationPlatformFieldProvider;
        }

        private readonly GetApplicationPlatformCommandProvider _getApplicationPlatformCommandProvider;
        private readonly GetApplicationPlatformFieldProvider _getAppliationPlatformFieldProvider;

        public int Id { get; set; }

        private SystemApplicationPlatform ReadApplicationPlatform(SqlDataReader reader) =>
            new SystemApplicationPlatform
            {
                Id = reader.GetInt32(_getAppliationPlatformFieldProvider.Id),
                Name = reader.GetString(_getAppliationPlatformFieldProvider.Name)
            };

        private async Task<SystemApplicationPlatform> ExecuteGetApplicationPlatformAsync(int id, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getApplicationPlatformCommandProvider.Get(id, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            return (reader.HasRows && await reader.ReadAsync(cancellationToken)) ? ReadApplicationPlatform(reader) : default;
        }

        public async Task<SystemApplicationPlatform> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await ExecuteGetApplicationPlatformAsync(id, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
