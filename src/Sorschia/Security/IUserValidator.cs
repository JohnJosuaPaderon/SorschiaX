using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Security
{
    public interface IUserValidator
    {
        Task<bool> ValidateApplicationAsync(int userId, int applicationId, CancellationToken cancellationToken = default);
        Task<bool> ValidatePermissionAsync(int userId, int permissionId, CancellationToken cancellationToken = default);
        Task<bool> ValidateRoleAsync(int userId, int roleId, CancellationToken cancellationToken = default);
    }
}
