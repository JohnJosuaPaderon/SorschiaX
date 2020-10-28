using Sorschia.SystemCore.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface ISessionRepository
    {
        Task<Session> GetAsync(long id, CancellationToken cancellationToken = default);
    }
}
