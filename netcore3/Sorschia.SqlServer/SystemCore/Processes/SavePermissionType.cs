using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SavePermissionType : ProcessBase, ISavePermissionType
    {
        private readonly SavePermissionTypeQuery _query;

        public SavePermissionTypeModel Model { get; set; }

        public SavePermissionType(IConnectionStringProvider connectionStringProvider, SavePermissionTypeQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SavePermissionTypeResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SavePermissionTypeResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await SaveAsync(model.Type, result, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }

        private async Task SaveAsync(PermissionType module, SavePermissionTypeResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _type = await _query.ExecuteAsync(module, connection, transaction, cancellationToken);

            if (_type is null)
                throw SorschiaException.VariableIsNull<PermissionType>(nameof(_type));

            result.Type = _type;
        }
    }
}
