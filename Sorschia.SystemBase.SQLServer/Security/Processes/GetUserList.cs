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
    internal sealed class GetUserList : SQLProcessBase, IGetUserList
    {
        public GetUserList(
            IConnectionStringProvider connectionStringProvider,
            GetUserListCommandProvider getUserListCommandProvider,
            GetUserListFieldProvider getUserListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getUserListCommandProvider = getUserListCommandProvider;
            _getUserListFieldProvider = getUserListFieldProvider;
        }

        private readonly GetUserListCommandProvider _getUserListCommandProvider;
        private readonly GetUserListFieldProvider _getUserListFieldProvider;

        public GetUserListModel Model { get; set; }

        private void ReadUser(SqlDataReader reader, GetUserListResult result) =>
            result.UserList.Add(new SystemUser
            {
                Id = reader.GetInt32(_getUserListFieldProvider.Id),
                FirstName = reader.GetString(_getUserListFieldProvider.FirstName),
                MiddleName = reader.GetString(_getUserListFieldProvider.MiddleName),
                LastName = reader.GetString(_getUserListFieldProvider.LastName),
                Username = reader.GetString(_getUserListFieldProvider.Username),
                IsActive = reader.GetBoolean(_getUserListFieldProvider.IsActive),
                IsPasswordChangeRequired = reader.GetBoolean(_getUserListFieldProvider.IsPasswordChangeRequired)
            });

        private void ReadTotalCount(SqlDataReader reader, GetUserListResult result) =>
            result.TotalCount = reader.GetInt32(_getUserListFieldProvider.TotalCount);

        private async Task ExecuteGetUserListAsync(GetUserListModel model, GetUserListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getUserListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadUser(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetUserListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetUserListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetUserListAsync(model, result, connection, cancellationToken);
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
