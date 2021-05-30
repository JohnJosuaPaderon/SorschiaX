using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Data;
using System;

namespace Sorschia.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> HasSoftDelete<TEntity>(this EntityTypeBuilder<TEntity> instance) where TEntity : class
        {
            instance.Property<bool>(ShadowProperties.IsDeleted);
            return instance;
        }

        public static EntityTypeBuilder<TEntity> HasInsertFootprint<TEntity>(this EntityTypeBuilder<TEntity> instance) where TEntity : class
        {
            instance.Property<int?>(ShadowProperties.InsertedById);
            instance.Property<DateTimeOffset?>(ShadowProperties.InsertedOn);
            return instance;
        }

        public static EntityTypeBuilder<TEntity> HasUpdateFootprint<TEntity>(this EntityTypeBuilder<TEntity> instance) where TEntity : class
        {
            instance.Property<int?>(ShadowProperties.UpdatedById);
            instance.Property<DateTimeOffset?>(ShadowProperties.UpdatedOn);
            return instance;
        }

        public static EntityTypeBuilder<TEntity> HasDeleteFootprint<TEntity>(this EntityTypeBuilder<TEntity> instance) where TEntity : class
        {
            instance.Property<int?>(ShadowProperties.DeletedById);
            instance.Property<DateTimeOffset?>(ShadowProperties.DeletedOn);
            return instance;
        }
    }
}
