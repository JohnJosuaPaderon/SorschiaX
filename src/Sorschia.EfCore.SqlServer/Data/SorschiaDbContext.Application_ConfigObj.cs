using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        private class Application_ConfigObj : IEntityTypeConfiguration<Application>
        {
            public void Configure(EntityTypeBuilder<Application> builder)
            {
                builder.ToTable("Application", Schemas.Default);

                builder
                    .Property(_ => _.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

                builder
                    .Property(_ => _.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(Application.NameMaxLength);

                builder
                    .Property(_ => _.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(Application.DescriptionMaxLength);

                builder.HasKey(_ => _.Id);

                builder
                    .HasSoftDelete()
                    .HasInsertFootprint()
                    .HasUpdateFootprint()
                    .HasDeleteFootprint();
            }
        }
    }
}
