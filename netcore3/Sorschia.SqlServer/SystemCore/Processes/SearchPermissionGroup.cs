using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchPermissionGroup : ProcessBase, ISearchPermissionGroup
    {
        private readonly SearchPermissionGroupQuery _query;

        public SearchPermissionGroupModel Model { get; set; }

        public SearchPermissionGroup(IConnectionStringProvider connectionStringProvider, SearchPermissionGroupQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SearchPermissionGroupResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SearchPermissionGroupResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                await _query.ExecuteAsync(model, result, connection, cancellationToken);
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
