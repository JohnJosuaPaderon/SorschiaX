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
    internal sealed class GetModule : SQLProcessBase, IGetModule
    {
        public GetModule(
            IConnectionStringProvider connectionStringProvider,
            GetModuleCommandProvider getModuleCommandProvider,
            GetModuleFieldProvider getModuleFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getModuleCommandProvider = getModuleCommandProvider;
            _getModuleFieldProvider = getModuleFieldProvider;
        }

        private readonly GetModuleCommandProvider _getModuleCommandProvider;
        private readonly GetModuleFieldProvider _getModuleFieldProvider;

        public int Id { get; set; }

        private SystemModule ReadModule(SqlDataReader reader) =>
            new SystemModule
            {
                Id = reader.GetInt32(_getModuleFieldProvider.Id),
                Name = reader.GetString(_getModuleFieldProvider.Name),
                OrdinalNumber = reader.GetInt32(_getModuleFieldProvider.OrdinalNumber),
                ApplicationId = reader.GetNullableInt32(_getModuleFieldProvider.ApplicationId)
            };

        private async Task<SystemModule> ExecuteGetModuleAsync(int id, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getModuleCommandProvider.Get(id, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            return (reader.HasRows && await reader.ReadAsync(cancellationToken)) ? ReadModule(reader) : default;
        }

        public async Task<SystemModule> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await ExecuteGetModuleAsync(id, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
