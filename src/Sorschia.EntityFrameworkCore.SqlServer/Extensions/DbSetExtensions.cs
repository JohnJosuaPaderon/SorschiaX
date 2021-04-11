using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sorschia.Auditing;

namespace Sorschia.Extensions
{
    internal static class DbSetExtensions
    {
        public static EntityEntry<TEntity> AddWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity) where TEntity : class
        {
            return instance.Add(entity)
                .SetInsertFootprint();
        }

        public static EntityEntry<TEntity> AddWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity, Footprint? footprint) where TEntity : class
        {
            return instance.Add(entity)
                .SetInsertFootprint(footprint);
        }

        public static EntityEntry<TEntity> UpdateWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity) where TEntity : class
        {
            return instance.Update(entity)
                .SetUpdateFootprint();
        }

        public static EntityEntry<TEntity> UpdateWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity, Footprint? footprint) where TEntity : class
        {
            return instance.Update(entity)
                .SetUpdateFootprint(footprint);
        }

        public static EntityEntry<TEntity> SoftDelete<TEntity>(this DbSet<TEntity> instance, TEntity entity) where TEntity : class
        {
            return instance.Update(entity)
                .SetSoftDelete();
        }

        public static EntityEntry<TEntity> SoftDeleteWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity) where TEntity : class
        {
            return instance.SoftDelete(entity)
                .SetDeleteFootprint();
        }

        public static EntityEntry<TEntity> SoftDeleteWithFootprint<TEntity>(this DbSet<TEntity> instance, TEntity entity, Footprint? footprint) where TEntity : class
        {
            return instance.SoftDelete(entity)
                .SetDeleteFootprint(footprint);
        }
    }
}
