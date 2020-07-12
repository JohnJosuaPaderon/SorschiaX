using Sorschia.Data;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SearchUser : ProcessBase, ISearchUser
    {
        private readonly SearchUserQuery _query;

        public SearchUserModel Model { get; set; }

        public SearchUser(IConnectionStringProvider connectionStringProvider, SearchUserQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<SearchUserResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SearchUserResult();
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
