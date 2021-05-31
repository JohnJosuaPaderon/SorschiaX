using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    internal sealed class UserPermissionEntityTypeConfiguration : UserPermissionEntityTypeConfigurationBase, IEntityTypeConfiguration<UserPermission>
    {
        public override void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("UserPermission", "Identity");
            base.Configure(builder);
        }
    }
}
