using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    internal sealed class RolePermissionEntityTypeConfiguration : RolePermissionEntityTypeConfigurationBase, IEntityTypeConfiguration<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermission", "Identity");
            base.Configure(builder);
        }
    }
}
