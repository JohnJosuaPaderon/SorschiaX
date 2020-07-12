using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class ValidateUserApplication : ProcessBase, IValidateUserApplication
    {
        private readonly ValidateUserApplicationQuery _query;

        public ValidateUserApplicationModel Model { get; set; }

        public ValidateUserApplication(IConnectionStringProvider connectionStringProvider, ValidateUserApplicationQuery query) : base(connectionStringProvider)
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
