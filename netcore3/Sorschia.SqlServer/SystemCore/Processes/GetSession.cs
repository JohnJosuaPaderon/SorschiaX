using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetSession : ProcessBase, IGetSession
    {
        private readonly GetSessionQuery _query;

        public long Id { get; set; }

        public GetSession(IConnectionStringProvider connectionStringProvider, GetSessionQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<Session> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await _query.ExecuteAsync(id, connection, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
