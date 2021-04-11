using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.EntityTypeConfigurations
{
    internal sealed class UserPermissionEntityTypeConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("UserPermission")
                .HasSoftDeleteQueryFilter();

            builder.HasOne(_ => _.User)
                .WithMany(_ => _.UserPermissions)
                .HasForeignKey(_ => _.UserId);

            builder.HasOne(_ => _.Permission)
                .WithMany()
                .HasForeignKey(_ => _.PermissionId);
        }
    }
}
