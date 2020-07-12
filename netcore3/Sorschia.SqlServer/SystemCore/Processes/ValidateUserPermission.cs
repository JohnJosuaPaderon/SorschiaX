using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class ValidateUserPermission : ProcessBase, IValidateUserPermission
    {
        private readonly ValidateUserPermissionQuery _query;

        public ValidateUserPermissionModel Model { get; set; }

        public ValidateUserPermission(IConnectionStringProvider connectionStringProvider, ValidateUserPermissionQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await _query.ExecuteAsync(model, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
