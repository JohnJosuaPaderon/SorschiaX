using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sorschia.Auditing;
using Sorschia.ErrorHandling.Builders;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<TEntity> FindByIdAsync<TEntity, TId>(this DbSet<TEntity> instance, TId id, string errorMessage, string errorDebugMessage, CancellationToken cancellationToken = default) where TEntity : class
        {
            if (Equals(id, default(TId)))
                return null;

            var entity = await instance.FindAsync(new object[] { id }, cancellationToken);

            if (entity is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<TEntity>()
                    .WithMessage(errorMessage)
                    .WithDebugMessage(errorDebugMessage)
                    .AddField("Id", id)
                    .Build();

            return entity;
        }

        public static async Task<TEntity> FindByIdAsync<TEntity, TId>(this DbSet<TEntity> instance, TId id, string errorMessage, CancellationToken cancellationToken = default) where TEntity : class
        {
            return await instance.FindByIdAsync(id, errorMessage, null, cancellationToken);
        }

        public static async Task<TEntity> FindByIdAsync<TEntity, TId>(this DbSet<TEntity> instance, TId id, CancellationToken cancellationToken = default) where TEntity : class
        {
            return await instance.FindByIdAsync(id, null, null, cancellationToken);
        }

        public static EntityEntry<TEntity> SoftDelete<TEntity>(this DbSet<TEntity> instance, TEntity entity) where TEntity : class
        {
            return instance.Update(entity)
                .SetDeleted();
        }

        public static EntityEntry<TEntity> SoftDelete<TEntity>(this DbSet<TEntity> instance, TEntity entity, Footprint footprint) where TEntity : class
        {
            return instance.SoftDelete(entity)
                .SetDeleteFootprint(footprint);
        }

        public static EntityEntry<TEntity> Add<TEntity>(this DbSet<TEntity> instance, TEntity entity, Footprint footprint) where TEntity : class
        {
            return instance.Add(entity)
                .SetInsertFootprint(footprint);
        }

        public static EntityEntry<TEntity> Update<TEntity>(this DbSet<TEntity> instance, TEntity entity, Footprint footprint) where TEntity : class
        {
            return instance.Update(entity)
                .SetUpdateFootprint(footprint);
        }
    }
}
