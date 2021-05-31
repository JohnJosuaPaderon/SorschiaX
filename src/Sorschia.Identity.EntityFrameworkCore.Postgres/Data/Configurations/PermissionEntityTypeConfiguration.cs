using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    internal sealed class PermissionEntityTypeConfiguration : PermissionEntityTypeConfigurationBase, IEntityTypeConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", "Identity");
            base.Configure(builder);
        }
    }
}
