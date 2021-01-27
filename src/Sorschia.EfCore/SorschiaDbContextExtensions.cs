using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sorschia
{
    internal static class SorschiaDbContextExtensions
    {
        public static async Task<bool> VerifyPermissionAsync(this SorschiaDbContext instance)
        {
            await instance.Permissions.ToListAsync();
            return false;
        }
    }
}
