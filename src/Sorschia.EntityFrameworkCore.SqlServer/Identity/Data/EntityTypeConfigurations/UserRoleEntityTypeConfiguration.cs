using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Identity.Entities;
using SystemBase.Extensions;

namespace Sorschia.Identity.Data.EntityTypeConfigurations
{
    internal sealed class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole")
                .HasSoftDeleteQueryFilter();

            builder.HasOne(_ => _.User)
                .WithMany(_ => _.UserRoles)
                .HasForeignKey(_ => _.UserId);

            builder.HasOne(_ => _.Role)
                .WithMany()
                .HasForeignKey(_ => _.RoleId);
        }
    }
}
