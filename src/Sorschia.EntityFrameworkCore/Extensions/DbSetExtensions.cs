using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sorschia.Audit;

namespace Sorschia.Extensions
{
    public static class DbSetExtensions
    {
        public static EntityEntry<TEntity> AddWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity, IFootprint footprint) where TEntity : class
        {
            return instance.Add(entity)
                .SetInsertFootprint(footprint);
        }

        public static EntityEntry<TEntity> AddWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity) where TEntity : class
        {
            return instance.Add(entity)
                .SetInsertFootprint();
        }

        public static EntityEntry<TEntity> UpdateWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity, IFootprint footprint) where TEntity : class
        {
            return instance.Update(entity)
                .SetUpdateFootprint(footprint);
        }

        public static EntityEntry<TEntity> UpdateWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity) where TEntity : class
        {
            return instance.Update(entity)
                .SetUpdateFootprint();
        }
    }
}
