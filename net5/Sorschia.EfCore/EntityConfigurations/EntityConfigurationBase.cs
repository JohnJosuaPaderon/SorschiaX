using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.EntityConfigurations
{
    public abstract class EntityConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        protected bool IsInsertIgnored { get; set; }
        protected bool IsUpdateIgnored { get; set; }
        protected bool IsDeleteIgnored { get; set; }

        protected void IgnoreInsert() => IsInsertIgnored = true;
        protected void IgnoreUpdate() => IsUpdateIgnored = true;
        protected void IgnoreDelete() => IsUpdateIgnored = true;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (IsInsertIgnored)
            {
                builder
                    .Ignore(entity => entity.InsertedBy)
                    .Ignore(entity => entity.InsertedById)
                    .Ignore(entity => entity.InsertedOn);
            }
            else
            {
                builder
                    .HasOne(entity => entity.InsertedBy)
                    .WithMany()
                    .HasForeignKey(entity => entity.InsertedById);
            }

            if (IsUpdateIgnored)
            {
                builder
                    .Ignore(entity => entity.UpdatedBy)
                    .Ignore(entity => entity.UpdatedById)
                    .Ignore(entity => entity.UpdatedOn);
            }
            else
            {
                builder
                    .HasOne(entity => entity.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(entity => entity.UpdatedById);
            }

            if (IsDeleteIgnored)
            {
                builder
                    .Ignore(entity => entity.IsDeleted)
                    .Ignore(entity => entity.DeletedBy)
                    .Ignore(entity => entity.DeletedById)
                    .Ignore(entity => entity.DeletedOn);
            }
            else
            {
                builder
                    .HasOne(entity => entity.DeletedBy)
                    .WithMany()
                    .HasForeignKey(entity => entity.DeletedById);
            }
        }
    }
}
