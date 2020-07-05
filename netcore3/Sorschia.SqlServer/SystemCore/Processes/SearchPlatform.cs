using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchPlatform : ProcessBase, ISearchPlatform
    {
        private readonly SearchPlatformQuery _query;

        public SearchPlatformModel Model { get; set; }

        public SearchPlatform(IConnectionStringProvider connectionStringProvider, SearchPlatformQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SearchPlatformResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SearchPlatformResult();
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
