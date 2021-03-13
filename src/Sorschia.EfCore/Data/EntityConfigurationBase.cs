using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    public abstract class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        private readonly EntityOptions _options;

        public EntityConfigurationBase(EntityOptions options)
        {
            _options = options;
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (_options.Schema is null)
            {
                builder.ToTable(_options.TableName);
            }
            else
            {
                builder.ToTable(_options.TableName, _options.Schema);
            }

            if (_options.IsInsertIgnored)
            {
                builder
                    .Ignore(_ => _.InsertedBy)
                    .Ignore(_ => _.InsertedById)
                    .Ignore(_ => _.InsertedOn);
            }
            else
            {
                builder
                    .Property(_ => _.InsertedById)
                    .ApplyOptions(_options.InsertedById);

                builder
                    .Property(_ => _.InsertedOn)
                    .ApplyOptions(_options.InsertedOn);

                builder
                    .HasOne(_ => _.InsertedBy)
                    .WithMany()
                    .HasForeignKey(_ => _.InsertedById);
            }

            if (_options.IsUpdateIgnored)
            {
                builder
                    .Ignore(_ => _.UpdatedBy)
                    .Ignore(_ => _.UpdatedById)
                    .Ignore(_ => _.UpdatedOn);
            }
            else
            {
                builder
                    .Property(_ => _.UpdatedById)
                    .ApplyOptions(_options.UpdatedById);

                builder
                    .Property(_ => _.UpdatedOn)
                    .ApplyOptions(_options.UpdatedOn);

                builder
                    .HasOne(_ => _.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(_ => _.UpdatedById);
            }

            if (_options.IsDeleteIgnored)
            {
                builder
                    .Ignore(_ => _.IsDeleted)
                    .Ignore(_ => _.DeletedBy)
                    .Ignore(_ => _.DeletedById)
                    .Ignore(_ => _.DeletedOn);
            }
            else
            {
                builder
                    .Property(_ => _.IsDeleted)
                    .ApplyOptions(_options.IsDeleted);

                builder
                    .Property(_ => _.DeletedById)
                    .ApplyOptions(_options.DeletedById);

                builder
                    .Property(_ => _.DeletedOn)
                    .ApplyOptions(_options.DeletedOn);

                builder
                    .HasOne(_ => _.DeletedBy)
                    .WithMany()
                    .HasForeignKey(_ => _.DeletedBy);

                builder.HasQueryFilter(_ => !_.IsDeleted);
            }
        }
    }
}
