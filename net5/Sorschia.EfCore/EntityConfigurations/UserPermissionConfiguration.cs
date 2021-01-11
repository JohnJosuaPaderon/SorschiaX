using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.EntityConfigurations
{
    internal sealed class UserPermissionConfiguration : EntityConfigurationBase<UserPermission>
    {
        public override void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            IgnoreUpdate();
            builder.ToTable("UserPermission");

            builder
                .HasOne(_ => _.User)
                .WithMany(_ => _.Permissions)
                .HasForeignKey(_ => _.UserId);

            builder
                .HasOne(_ => _.Permission)
                .WithMany(_ => _.Users)
                .HasForeignKey(_ => _.PermissionId);

            base.Configure(builder);
        }
    }
}
