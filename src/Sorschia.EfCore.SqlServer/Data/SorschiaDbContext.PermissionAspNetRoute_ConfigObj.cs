using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        private class PermissionAspNetRoute_ConfigObj : IEntityTypeConfiguration<PermissionAspNetRoute>
        {
            public void Configure(EntityTypeBuilder<PermissionAspNetRoute> builder)
            {
                builder.ToTable("PermissionAspNetRoute", Schemas.Default);

                builder
                    .Property(_ => _.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

                builder
                    .Property(_ => _.PermissionId)
                    .HasColumnName("PermissionId")
                    .IsRequired();

                builder
                    .Property(_ => _.AspNetArea)
                    .HasColumnName("AspNetArea")
                    .HasMaxLength(PermissionAspNetRoute.AspNetAreaMaxLength);

                builder
                    .Property(_ => _.AspNetController)
                    .HasColumnName("AspNetController")
                    .IsRequired()
                    .HasMaxLength(PermissionAspNetRoute.AspNetControllerMaxLength);

                builder
                    .Property(_ => _.AspNetAction)
                    .HasColumnName("AspNetAction")
                    .IsRequired()
                    .HasMaxLength(PermissionAspNetRoute.AspNetActionMaxLength);

                builder.HasKey(_ => _.Id);

                builder
                    .HasOne(_ => _.Permission)
                    .WithMany(_ => _.AspNetRoutes)
                    .HasForeignKey(_ => _.PermissionId);

                builder
                    .HasSoftDelete()
                    .HasInsertFootprint()
                    .HasUpdateFootprint()
                    .HasDeleteFootprint();

            }
        }
    }
}
