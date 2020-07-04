using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchApplication : ProcessBase, ISearchApplication
    {
        private readonly SearchApplicationQuery _query;

        public SearchApplicationModel Model { get; set; }

        public SearchApplication(IConnectionStringProvider connectionStringProvider, SearchApplicationQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SearchApplicationResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SearchApplicationResult();
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
