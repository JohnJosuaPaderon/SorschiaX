using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class DeletePermissionType : ProcessBase, IDeletePermissionType
    {
        private readonly DeletePermissionTypeQuery _query;

        public DeletePermissionTypeModel Model { get; set; }

        public DeletePermissionType(IConnectionStringProvider connectionStringProvider, DeletePermissionTypeQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                var result = await _query.ExecuteAsync(model, connection, transaction, cancellationToken);
                transaction.Commit();
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
