using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.Configurations
{
    internal sealed class UserEntityTypeConfiguration : UserEntityTypeConfigurationBase, IEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "Identity");
            base.Configure(builder);
        }
    }
}
