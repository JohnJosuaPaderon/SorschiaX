using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data.EntityTypeConfigurations
{
    internal sealed class UserApplicationEntityTypeConfiguration : IEntityTypeConfiguration<UserApplication>
    {
        public void Configure(EntityTypeBuilder<UserApplication> builder)
        {
            builder.ToTable("UserApplication", Schemas.Default);

            builder
                .Property(_ => _.Id)
                .HasColumnName("Id")
                .UseIdentityColumn();

            builder
                .Property(_ => _.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder
                .Property(_ => _.ApplicationId)
                .HasColumnName("ApplicationId")
                .IsRequired();

            builder.HasKey(_ => _.Id);

            builder
                .HasOne(_ => _.User)
                .WithMany(_ => _.UserApplications)
                .HasForeignKey(_ => _.UserId);

            builder
                .HasOne(_ => _.Application)
                .WithMany()
                .HasForeignKey(_ => _.ApplicationId);

            builder
                .HasSoftDelete()
                .HasInsertFootprint()
                .HasDeleteFootprint();
        }
    }
}
