using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    public abstract class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        private readonly TableSettings _settings;
        protected bool IsInsertFootprintIgnored { get; set; }
        protected bool IsUpdateFootprintIgnored { get; set; }
        protected bool IsDeleteFootprintIgnored { get; set; }

        public EntityConfigurationBase(TableSettings settings)
        {
            _settings = settings;
            IsInsertFootprintIgnored = settings.IsInsertFootprintIgnored ?? false;
            IsUpdateFootprintIgnored = settings.IsUpdateFootprintIgnored ?? false;
            IsDeleteFootprintIgnored = settings.IsDeleteFootprintIgnored ?? false;
        }

        protected void IgnoreInsertFootprint() => IsInsertFootprintIgnored = true;
        protected void IgnoreUpdateFootprint() => IsUpdateFootprintIgnored = true;
        protected void IgnoreDeleteFootprint() => IsDeleteFootprintIgnored = true;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Apply(_settings);

            if (IsInsertFootprintIgnored)
            {
                builder
                    .Ignore(_ => _.InsertedBy)
                    .Ignore(_ => _.InsertedById)
                    .Ignore(_ => _.InsertedOn);
            }
            else
            {
                builder
                    .HasOne(_ => _.InsertedBy)
                    .WithMany()
                    .HasForeignKey(_ => _.InsertedById);
            }

            if (IsUpdateFootprintIgnored)
            {
                builder
                    .Ignore(_ => _.UpdatedBy)
                    .Ignore(_ => _.UpdatedById)
                    .Ignore(_ => _.UpdatedOn);
            }
            else
            {
                builder
                    .HasOne(_ => _.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(_ => _.UpdatedById);
            }

            if (IsDeleteFootprintIgnored)
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
                    .HasDefaultValue(false);

                builder
                    .HasQueryFilter(_ => !_.IsDeleted);

                builder
                    .HasOne(_ => _.DeletedBy)
                    .WithMany()
                    .HasForeignKey(_ => _.DeletedById);
            }
        }
    }
}
