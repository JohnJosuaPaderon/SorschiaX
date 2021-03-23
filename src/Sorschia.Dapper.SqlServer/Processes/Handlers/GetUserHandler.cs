using Dapper;
using MediatR;
using Sorschia.Data;
using Sorschia.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class GetUserHandler : IRequestHandler<GetUser, GetUser.Result>
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public GetUserHandler(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<GetUser.Result> Handle(GetUser request, CancellationToken cancellationToken)
        {
            using var connection = await _connectionProvider.OpenAsync(cancellationToken);
            using var reader = await connection.QueryMultipleAsync("dbo.GetUser");
        }
    }
}
