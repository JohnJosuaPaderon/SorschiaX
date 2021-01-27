using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Configuration
{
    internal sealed class RoleConfiguration : EntityConfigurationBase<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder
                .Property(_ => _.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(_ => _.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);

            builder
                .Property(_ => _.ApplicationId)
                .HasColumnName("ApplicationId");

            builder
                .HasOne(_ => _.Application)
                .WithMany(_ => _.Roles)
                .HasForeignKey(_ => _.ApplicationId);

            base.Configure(builder);
        }
    }
}
