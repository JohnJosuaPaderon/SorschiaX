using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sorschia.Data;
using Sorschia.Utilities;
using System;

namespace Sorschia.Extensions
{
    public static class EntityEntryExtensions
    {
        public static EntityEntry<TEntity> SoftDelete<TEntity>(this EntityEntry<TEntity> instance)
            where TEntity : class
        {
            instance.Property<bool>(ShadowProperties.IsDeleted).CurrentValue = true;
            return instance;
        }

        public static EntityEntry<TEntity> SetInsertFootprint<TEntity>(this EntityEntry<TEntity> instance, Footprint footprint)
            where TEntity : class
        {
            instance.Property<int?>(ShadowProperties.InsertedById).CurrentValue = footprint.UserId;
            instance.Property<DateTimeOffset?>(ShadowProperties.InsertedOn).CurrentValue = footprint.Timestamp;
            return instance;
        }

        public static EntityEntry<TEntity> SetUpdateFootprint<TEntity>(this EntityEntry<TEntity> instance, Footprint footprint)
            where TEntity : class
        {
            instance.Property<int?>(ShadowProperties.UpdatedById).CurrentValue = footprint.UserId;
            instance.Property<DateTimeOffset?>(ShadowProperties.UpdatedOn).CurrentValue = footprint.Timestamp;
            return instance;
        }

        public static EntityEntry<TEntity> SetDeleteFootprint<TEntity>(this EntityEntry<TEntity> instance, Footprint footprint)
            where TEntity : class
        {
            instance.Property<int?>(ShadowProperties.DeletedById).CurrentValue = footprint.UserId;
            instance.Property<DateTimeOffset?>(ShadowProperties.DeletedOn).CurrentValue = footprint.Timestamp;
            return instance;
        }
    }
}
