using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Data;

namespace Sorschia.Extensions
{
    internal static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> HasSoftDeleteQueryFilter<TEntity>(this EntityTypeBuilder<TEntity> instance) where TEntity : class
        {
            return instance.HasQueryFilter(_ => !EF.Property<bool>(_, ShadowProperties.IsDeleted));
        }
    }
}
