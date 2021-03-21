using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        private sealed class Permission_ConfigObj : IEntityTypeConfiguration<Permission>
        {
            public void Configure(EntityTypeBuilder<Permission> builder)
            {
                builder.ToTable("Permission", Schemas.Default);

                builder
                    .Property(_ => _.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

                builder
                    .Property(_ => _.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(Permission.NameMaxLength);

                builder
                    .Property(_ => _.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(Permission.DescriptionMaxLength);

                builder
                    .Property(_ => _.ApplicationId)
                    .HasColumnName("ApplicationId");

                builder
                    .Property(_ => _.RoleId)
                    .HasColumnName("RoleId");

                builder.HasKey(_ => _.Id);

                builder
                    .HasOne(_ => _.Application)
                    .WithMany(_ => _.Permissions)
                    .HasForeignKey(_ => _.ApplicationId);

                builder
                    .HasOne(_ => _.Role)
                    .WithMany(_ => _.Permissions)
                    .HasForeignKey(_ => _.RoleId);

                builder
                    .HasSoftDelete()
                    .HasInsertFootprint()
                    .HasUpdateFootprint()
                    .HasDeleteFootprint();
            }
        }
    }
}
