using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchPermissionType : ProcessBase, ISearchPermissionType
    {
        private readonly SearchPermissionTypeQuery _query;

        public SearchPermissionTypeModel Model { get; set; }

        public SearchPermissionType(IConnectionStringProvider connectionStringProvider, SearchPermissionTypeQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SearchPermissionTypeResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SearchPermissionTypeResult();
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
