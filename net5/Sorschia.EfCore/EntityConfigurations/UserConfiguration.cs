using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Generators;

namespace Sorschia.EntityConfigurations
{
    internal class UserConfiguration : EntityConfigurationBase<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder
                .Ignore(_ => _.Password)
                .Ignore(_ => _.CipherPassword);

            builder
                .Property(_ => _.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(_ => _.MiddleName)
                .HasMaxLength(50);

            builder
                .Property(_ => _.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(_ => _.NameExtension)
                .HasMaxLength(5);

            builder
                .Property(_ => _.FullName)
                .IsRequired()
                .HasMaxLength(175)
                .HasValueGenerator<FullNameGenerator>();

            builder
                .Property(_ => _.Username)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(_ => _.PasswordHash)
                .IsRequired()
                .HasMaxLength(128)
                .HasValueGenerator<UserPasswordHashGenerator>();

            builder
                .Property(_ => _.EmailAddress)
                .HasMaxLength(100);

            builder
                .Property(_ => _.MobileNumber)
                .HasMaxLength(20);

            builder
                .Property(_ => _.IsActive)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(_ => _.IsLocked)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(_ => _.IsPasswordChangeRequired)
                .IsRequired()
                .HasDefaultValue(true);

            builder
                .Property(_ => _.IsEmailAddressVerified)
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property(_ => _.IsMobileNumberVerified)
                .IsRequired()
                .HasDefaultValue(false);

            base.Configure(builder);
        }
    }
}
