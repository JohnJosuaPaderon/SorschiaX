using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetPermission : ProcessBase, IGetPermission
    {
        private readonly GetPermissionQuery _query;

        public int Id { get; set; }

        public GetPermission(IConnectionStringProvider connectionStringProvider, GetPermissionQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<Permission> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await _query.ExecuteAsync(id, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
