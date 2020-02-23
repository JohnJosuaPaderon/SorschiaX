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
    internal sealed class GetModuleList : SQLProcessBase, IGetModuleList
    {
        public GetModuleList(
            IConnectionStringProvider connectionStringProvider,
            GetModuleListCommandProvider getModuleListCommandProvider,
            GetModuleListFieldProvider getModuleListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getModuleListCommandProvider = getModuleListCommandProvider;
            _getModuleListFieldProvider = getModuleListFieldProvider;
        }

        private readonly GetModuleListCommandProvider _getModuleListCommandProvider;
        private readonly GetModuleListFieldProvider _getModuleListFieldProvider;

        public GetModuleListModel Model { get; set; }

        private void ReadModule(SqlDataReader reader, GetModuleListResult result) =>
            result.ModuleList.Add(new SystemModule
            {
                Id = reader.GetInt32(_getModuleListFieldProvider.Id),
                Name = reader.GetString(_getModuleListFieldProvider.Name),
                OrdinalNumber = reader.GetInt32(_getModuleListFieldProvider.OrdinalNumber),
                ApplicationId = reader.GetNullableInt32(_getModuleListFieldProvider.ApplicationId)
            });

        private void ReadTotalCount(SqlDataReader reader, GetModuleListResult result) =>
            result.TotalCount = reader.GetInt32(_getModuleListFieldProvider.TotalCount);

        private async Task ExecuteGetModuleListAsync(GetModuleListModel model, GetModuleListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getModuleListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadModule(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetModuleListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetModuleListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetModuleListAsync(model, result, connection, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
