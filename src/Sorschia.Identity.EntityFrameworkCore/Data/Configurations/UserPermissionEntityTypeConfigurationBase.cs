using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    public abstract class UserPermissionEntityTypeConfigurationBase
    {
        public virtual void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder
                .HasSoftDelete()
                .HasInsertFootprint()
                .HasDeleteFootprint();

            builder.HasOne(_ => _.User)
                .WithMany(_ => _.UserPermissions)
                .HasForeignKey(_ => _.UserId);

            builder.HasOne(_ => _.Permission)
                .WithMany()
                .HasForeignKey(_ => _.PermissionId);
        }
    }
}
