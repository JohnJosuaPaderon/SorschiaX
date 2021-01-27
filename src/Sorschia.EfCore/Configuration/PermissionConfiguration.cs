using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Configuration
{
    internal sealed class PermissionConfiguration : EntityConfigurationBase<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");

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
                .Property(_ => _.RoleId)
                .HasColumnName("RoleId");

            builder
                .HasOne(_ => _.Application)
                .WithMany(_ => _.Permissions)
                .HasForeignKey(_ => _.ApplicationId);

            builder
                .HasOne(_ => _.Role)
                .WithMany(_ => _.Permissions)
                .HasForeignKey(_ => _.RoleId);

            base.Configure(builder);
        }
    }
}
