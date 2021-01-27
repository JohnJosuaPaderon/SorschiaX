using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Configuration
{
    internal sealed class UserConfiguration : EntityConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder
                .Property(_ => _.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(_ => _.MiddleName)
                .HasColumnName("MiddleName")
                .HasMaxLength(50);

            builder
                .Property(_ => _.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(_ => _.NameSuffix)
                .HasColumnName("NameSuffix")
                .HasMaxLength(5);

            builder
                .Property(_ => _.FullName)
                .HasColumnName("FullName")
                .HasMaxLength(175)
                .IsRequired();

            builder
                .Property(_ => _.Username)
                .HasColumnName("Username")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property(_ => _.SecurePassword)
                .HasColumnName("SecurePassword")
                .HasMaxLength(128)
                .IsRequired();

            builder
                .Property(_ => _.EmailAddress)
                .HasColumnName("EmailAddress")
                .HasMaxLength(200);

            builder
                .Property(_ => _.MobileNumber)
                .HasColumnName("MobileNumber")
                .HasMaxLength(20);

            builder
                .Property(_ => _.IsActive)
                .HasColumnName("IsActive")
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(_ => _.IsPasswordChangeRequired)
                .HasColumnName("IsPasswordChangeRequired")
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(_ => _.IsEmailAddressVerified)
                .HasColumnName("IsEmailAddressVerified")
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(_ => _.IsMobileNumberVerified)
                .HasColumnName("IsMobileNumberVerified")
                .IsRequired()
                .HasDefaultValue(false);

            base.Configure(builder);
        }
    }
}
