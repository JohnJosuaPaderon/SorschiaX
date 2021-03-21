using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        private sealed class Role_ConfigObj : IEntityTypeConfiguration<Role>
        {
            public void Configure(EntityTypeBuilder<Role> builder)
            {
                builder.ToTable("Role", Schemas.Default);

                builder
                    .Property(_ => _.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

                builder
                    .Property(_ => _.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(Role.NameMaxLength);

                builder
                    .Property(_ => _.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(Role.DescriptionMaxLength);

                builder
                    .Property(_ => _.ApplicationId)
                    .HasColumnName("ApplicationId");

                builder.HasKey(_ => _.Id);

                builder
                    .HasOne(_ => _.Application)
                    .WithMany(_ => _.Roles)
                    .HasForeignKey(_ => _.ApplicationId);

                builder
                    .HasSoftDelete()
                    .HasInsertFootprint()
                    .HasUpdateFootprint()
                    .HasDeleteFootprint();
            }
        }
    }
}
