using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Security
{
    internal sealed class UserValidator : IUserValidator
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;

        public UserValidator(IDbContextFactory<SorschiaDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> ValidateApplicationAsync(int userId, int applicationId, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.UserApplications
                .Where(_ => _.UserId == userId && _.ApplicationId == applicationId)
                .SingleOrDefaultAsync(cancellationToken) is not null;
        }

        public async Task<bool> ValidatePermissionAsync(int userId, int permissionId, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.UserPermissions
                .Where(_ => _.UserId == userId && _.PermissionId == permissionId)
                .SingleOrDefaultAsync(cancellationToken) is not null;
        }

        public async Task<bool> ValidateRoleAsync(int userId, int roleId, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.UserRoles
                .Where(_ => _.UserId == userId && _.RoleId == roleId)
                .SingleOrDefaultAsync(cancellationToken) is not null;
        }
    }
}
