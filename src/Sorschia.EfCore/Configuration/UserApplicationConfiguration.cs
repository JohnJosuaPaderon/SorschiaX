using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Configuration
{
    internal sealed class UserApplicationConfiguration : EntityConfigurationBase<UserApplication>
    {
        public override void Configure(EntityTypeBuilder<UserApplication> builder)
        {
            IgnoreUpdate();
            builder.ToTable("UserApplication");

            builder
                .Property(_ => _.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder
                .Property(_ => _.ApplicationId)
                .HasColumnName("ApplicationId")
                .IsRequired();

            builder
                .HasOne(_ => _.User)
                .WithMany(_ => _.Applications)
                .HasForeignKey(_ => _.UserId);

            builder
                .HasOne(_ => _.Application)
                .WithMany()
                .HasForeignKey(_ => _.ApplicationId);

            base.Configure(builder);
        }
    }
}
