using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class SessionRepository : RepositoryBase, ISessionRepository
    {
        public SessionRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<Session> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetSession>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
