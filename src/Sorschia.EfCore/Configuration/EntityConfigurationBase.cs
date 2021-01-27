using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Configuration
{
    public abstract class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        protected bool IsInsertIgnored { get; set; } = false;
        protected bool IsUpdateIgnored { get; set; } = false;
        protected bool IsDeleteIgnored { get; set; } = false;

        protected void IgnoreInsert() => IsInsertIgnored = true;
        protected void IgnoreUpdate() => IsUpdateIgnored = true;
        protected void IgnoreDelete() => IsDeleteIgnored = true;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (IsInsertIgnored)
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

            if (IsUpdateIgnored)
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

            if (IsDeleteIgnored)
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
