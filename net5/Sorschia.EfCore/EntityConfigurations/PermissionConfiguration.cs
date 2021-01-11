using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.EntityConfigurations
{
    internal sealed class PermissionConfiguration : EntityConfigurationBase<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");

            builder
                .Property(_ => _.Name)
                .IsRequired()
                .HasMaxLength(75);

            builder
                .Property(_ => _.Description)
                .HasMaxLength(250);

            base.Configure(builder);
        }
    }
}
