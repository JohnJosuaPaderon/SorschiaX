using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Security
{
    public interface ICurrentUserValidator
    {
        Task<bool> ValidateApplicationAsync(int applicationId, CancellationToken cancellationToken = default);
        Task<bool> ValidatePermissionAsync(int permissionId, CancellationToken cancellationToken = default);
        Task<bool> ValidateRoleAsync(int roleId, CancellationToken cancellationToken = default);
    }
}
