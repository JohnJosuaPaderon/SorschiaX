using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        private sealed class UserRole_ConfigObj : IEntityTypeConfiguration<UserRole>
        {
            public void Configure(EntityTypeBuilder<UserRole> builder)
            {
                builder.ToTable("UserRole", Schemas.Default);

                builder
                    .Property(_ => _.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

                builder
                    .Property(_ => _.UserId)
                    .HasColumnName("UserId")
                    .IsRequired();

                builder
                    .Property(_ => _.RoleId)
                    .HasColumnName("RoleId")
                    .IsRequired();

                builder.HasKey(_ => _.Id);

                builder
                    .HasOne(_ => _.User)
                    .WithMany(_ => _.UserRoles)
                    .HasForeignKey(_ => _.UserId);

                builder
                    .HasOne(_ => _.Role)
                    .WithMany()
                    .HasForeignKey(_ => _.RoleId);

                builder
                    .HasSoftDelete()
                    .HasInsertFootprint()
                    .HasDeleteFootprint();
            }
        }
    }
}
