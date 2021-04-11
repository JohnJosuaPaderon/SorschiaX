using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Data.EntityTypeConfigurations
{
    internal sealed class PermissionEntityTypeConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission")
                .HasSoftDeleteQueryFilter();

            builder.HasOne(_ => _.Role)
                .WithMany(_ => _.Permissions)
                .HasForeignKey(_ => _.RoleId);
        }
    }
}
