using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    public abstract class RolePermissionEntityTypeConfigurationBase
    {
        public virtual void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder
                .HasSoftDelete()
                .HasInsertFootprint()
                .HasDeleteFootprint();

            builder.HasOne(_ => _.Role)
                .WithMany(_ => _.RolePermissions)
                .HasForeignKey(_ => _.RoleId);

            builder.HasOne(_ => _.Permission)
                .WithMany()
                .HasForeignKey(_ => _.PermissionId);
        }
    }
}
