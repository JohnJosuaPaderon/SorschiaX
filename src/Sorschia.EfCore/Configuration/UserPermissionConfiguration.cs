using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Configuration
{
    internal sealed class UserPermissionConfiguration : EntityConfigurationBase<UserPermission>
    {
        public override void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            IgnoreUpdate();
            builder.ToTable("UserPermission");

            builder
                .Property(_ => _.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder
                .Property(_ => _.PermissionId)
                .HasColumnName("PermissionId")
                .IsRequired();

            builder
                .HasOne(_ => _.User)
                .WithMany(_ => _.Permissions)
                .HasForeignKey(_ => _.UserId);

            builder
                .HasOne(_ => _.Permission)
                .WithMany()
                .HasForeignKey(_ => _.PermissionId);

            base.Configure(builder);
        }
    }
}
