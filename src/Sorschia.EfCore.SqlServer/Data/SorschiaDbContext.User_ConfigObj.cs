using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;
using Sorschia.Extensions;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        private sealed class User_ConfigObj : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.ToTable("User", Schemas.Default);

                builder
                    .Property(_ => _.Id)
                    .HasColumnName("Id")
                    .UseIdentityColumn();

                builder
                    .Property(_ => _.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired()
                    .HasMaxLength(User.FirstNameMaxLength);

                builder
                    .Property(_ => _.MiddleName)
                    .HasColumnName("MiddleName")
                    .HasMaxLength(User.MiddleNameMaxLength);

                builder
                    .Property(_ => _.LastName)
                    .HasColumnName("LastName")
                    .IsRequired()
                    .HasMaxLength(User.LastNameMaxLength);

                builder
                    .Property(_ => _.NameSuffix)
                    .HasColumnName("NameSuffix")
                    .HasMaxLength(User.NameSuffixMaxLength);

                builder
                    .Property(_ => _.Username)
                    .HasColumnName("Username")
                    .IsRequired()
                    .HasMaxLength(User.UsernameMaxLength);

                builder
                    .Property(_ => _.EmailAddress)
                    .HasColumnName("EmailAddress")
                    .HasMaxLength(User.EmailAddressMaxLength);

                builder
                    .Property(_ => _.MobileNumber)
                    .HasColumnName("MobileNumber")
                    .HasMaxLength(User.MobileNumberMaxLength);

                builder
                    .Property(_ => _.IsActive)
                    .HasColumnName("IsActive")
                    .IsRequired()
                    .HasDefaultValue(false);

                builder
                    .Property(_ => _.IsPasswordChangeRequired)
                    .HasColumnName("IsPasswordChangeRequired")
                    .IsRequired()
                    .HasDefaultValue(false);

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

                builder
                    .Property<string>(ShadowProperties.User.SecurePassword)
                    .HasColumnName("SecurePassword")
                    .IsRequired();

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
