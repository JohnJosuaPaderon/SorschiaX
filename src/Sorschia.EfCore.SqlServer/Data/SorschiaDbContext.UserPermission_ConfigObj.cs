using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        private sealed class UserPermission_ConfigObj : IEntityTypeConfiguration<UserPermission>
        {
            public void Configure(EntityTypeBuilder<UserPermission> builder)
            {
                builder.ToTable("UserPermission", Schemas.Default);

                builder
                    .Property(_ => _.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

                builder
                    .Property(_ => _.UserId)
                    .HasColumnName("UserId")
                    .IsRequired();

                builder
                    .Property(_ => _.PermissionId)
                    .HasColumnName("PermissionId")
                    .IsRequired();

                builder.HasKey(_ => _.Id);

                builder
                    .HasOne(_ => _.User)
                    .WithMany(_ => _.UserPermissions)
                    .HasForeignKey(_ => _.UserId);

                builder
                    .HasOne(_ => _.Permission)
                    .WithMany()
                    .HasForeignKey(_ => _.PermissionId);

                builder
                    .HasSoftDelete()
                    .HasInsertFootprint()
                    .HasDeleteFootprint();
            }
        }
    }
}
