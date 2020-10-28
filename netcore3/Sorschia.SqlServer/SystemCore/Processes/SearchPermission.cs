using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchPermission : ProcessBase, ISearchPermission
    {
        private readonly SearchPermissionQuery _query;

        public SearchPermissionModel Model { get; set; }

        public SearchPermission(IConnectionStringProvider connectionStringProvider, SearchPermissionQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SearchPermissionResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SearchPermissionResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                await _query.ExecuteAsync(model, result, connection, default, cancellationToken);
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
