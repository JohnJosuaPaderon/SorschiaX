using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class ValidateUserModule : ProcessBase, IValidateUserModule
    {
        private readonly ValidateUserModuleQuery _query;

        public ValidateUserModuleModel Model { get; set; }

        public ValidateUserModule(IConnectionStringProvider connectionStringProvider, ValidateUserModuleQuery query) : base(connectionStringProvider)
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
