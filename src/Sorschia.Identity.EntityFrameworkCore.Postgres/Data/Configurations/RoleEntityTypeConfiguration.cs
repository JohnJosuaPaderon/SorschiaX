using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    internal sealed class RoleEntityTypeConfiguration : RoleEntityTypeConfigurationBase, IEntityTypeConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", "Identity");
            base.Configure(builder);
        }
    }
}
