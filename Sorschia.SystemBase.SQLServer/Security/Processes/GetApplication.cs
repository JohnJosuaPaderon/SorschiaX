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
    internal sealed class GetApplication : SQLProcessBase, IGetApplication
    {
        public GetApplication(
            IConnectionStringProvider connectionStringProvider,
            GetApplicationCommandProvider getApplicationCommandProvider,
            GetApplicationFieldProvider getApplicationFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getApplicationCommandProvider = getApplicationCommandProvider;
            _getApplicationFieldProvider = getApplicationFieldProvider;
        }

        private readonly GetApplicationCommandProvider _getApplicationCommandProvider;
        private readonly GetApplicationFieldProvider _getApplicationFieldProvider;

        public int Id { get; set; }
        
        private SystemApplication ReadApplication(SqlDataReader reader) =>
            new SystemApplication
            {
                Id = reader.GetInt32(_getApplicationFieldProvider.Id),
                Name = reader.GetString(_getApplicationFieldProvider.Name),
                PlatformId = reader.GetNullableInt32(_getApplicationFieldProvider.PlatformId)
            };

        private async Task<SystemApplication> ExecuteGetApplicationAsync(int id, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getApplicationCommandProvider.Get(id, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            return (reader.HasRows && await reader.ReadAsync(cancellationToken)) ? ReadApplication(reader) : default;
        }

        public async Task<SystemApplication> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await ExecuteGetApplicationAsync(id, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
