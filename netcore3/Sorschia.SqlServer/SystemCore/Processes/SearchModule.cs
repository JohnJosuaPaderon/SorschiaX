using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchModule : ProcessBase, ISearchModule
    {
        private readonly SearchModuleQuery _query;

        public SearchModuleModel Model { get; set; }

        public SearchModule(IConnectionStringProvider connectionStringProvider, SearchModuleQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SearchModuleResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SearchModuleResult();
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
