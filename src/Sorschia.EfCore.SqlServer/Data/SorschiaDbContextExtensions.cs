using Sorschia.Entities;
using Sorschia.Entities.Exceptions.Builders;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    internal static class SorschiaDbContextExtensions
    {
        public static async Task<User> GetUserAsync(this SorschiaDbContext instance, int id, bool throwEntityNotFoundException = true, CancellationToken cancellationToken = default)
        {
            var user = await instance.Users.FindAsync(new object[] { id }, cancellationToken);

            if (throwEntityNotFoundException && user is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<User>()
                    .AddLookupField("Id", id)
                    .Build();

            return user;
        }
    }
}
