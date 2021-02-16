using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Data;
using Sorschia.Entities;

namespace Sorschia.Builders
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> TryToTable<TEntity>(this EntityTypeBuilder<TEntity> instance, string name) where TEntity : class
        {
            if (name is not null)
                instance.ToTable(name);

            return instance;
        }

        public static EntityTypeBuilder<TEntity> Apply<TEntity>(this EntityTypeBuilder<TEntity> instance, TableSettings settings) where TEntity : class
        {
            return instance
                .TryToTable(settings.TableName);
        }
        public static EntityTypeBuilder<TEntity> HasInt32IdentityColumn<TEntity>(this EntityTypeBuilder<TEntity> instance, ColumnSettings settings, bool isPrimaryKey = true) where TEntity : class, IIdInt32
        {
            instance.Property(_ => _.Id)
                .TryHasColumnName(settings.ColumnName)
                .UseIdentityColumn();

            if (isPrimaryKey)
                instance.HasKey(_ => _.Id);

            return instance;
        }

        public static EntityTypeBuilder<TEntity> HasInt64IdentityColumn<TEntity>(this EntityTypeBuilder<TEntity> instance, ColumnSettings settings, bool isPrimaryKey = true) where TEntity : class, IIdInt64
        {
            instance.Property(_ => _.Id)
                .TryHasColumnName(settings.ColumnName)
                .UseIdentityColumn();

            if (isPrimaryKey)
                instance.HasKey(_ => _.Id);

            return instance;
        }
    }
}
