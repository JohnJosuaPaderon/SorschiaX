using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Configuration
{
    internal sealed class ApplicationConfiguration : EntityConfigurationBase<Application>
    {
        public override void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Application");

            builder
                .Property(_ => _.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(_ => _.Description)
                .HasColumnName("Description")
                .HasMaxLength(500);

            base.Configure(builder);
        }
    }
}
