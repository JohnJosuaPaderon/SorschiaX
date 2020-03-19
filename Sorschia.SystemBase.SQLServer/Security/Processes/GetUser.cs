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
    internal sealed class GetUser : SqlProcessBase, IGetUser
    {
        public GetUser(
            IConnectionStringProvider connectionStringProvider,
            GetUserCommandProvider getUserCommandProvider,
            GetUserFieldProvider getUserFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getUserCommandProvider = getUserCommandProvider;
            _getUserFieldProvider = getUserFieldProvider;
        }

        private readonly GetUserCommandProvider _getUserCommandProvider;
        private readonly GetUserFieldProvider _getUserFieldProvider;

        public int Id { get; set; }

        private SystemUser ReadUser(SqlDataReader reader) =>
            new SystemUser
            {
                Id = reader.GetInt32(_getUserFieldProvider.Id),
                FirstName = reader.GetString(_getUserFieldProvider.FirstName),
                MiddleName = reader.GetString(_getUserFieldProvider.MiddleName),
                LastName = reader.GetString(_getUserFieldProvider.LastName),
                Username = reader.GetString(_getUserFieldProvider.Username),
                IsActive = reader.GetBoolean(_getUserFieldProvider.IsActive),
                IsPasswordChangeRequired = reader.GetBoolean(_getUserFieldProvider.IsPasswordChangeRequired)
            };

        private async Task<SystemUser> ExecuteGetUserAsync(int id, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getUserCommandProvider.Get(id, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            return (reader.HasRows && await reader.ReadAsync(cancellationToken)) ? ReadUser(reader) : default;
        }

        public async Task<SystemUser> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await ExecuteGetUserAsync(id, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
