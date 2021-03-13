using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sorschia.Entities;

namespace Sorschia.Data
{
    partial class SorschiaDbContext
    {
        internal sealed class User_ConfigObj : EntityConfigurationBase<User>
        {
            private readonly DataOptions.User_OptionsObj _options;

            public User_ConfigObj(DataOptions.User_OptionsObj options) : base(options)
            {
                _options = options;
            }

            public override void Configure(EntityTypeBuilder<User> builder)
            {
                base.Configure(builder);

                builder
                    .Property(_ => _.Id)
                    .ApplyOptions(_options.Id);

                builder
                    .Property(_ => _.FirstName)
                    .ApplyOptions(_options.FirstName);

                builder
                    .Property(_ => _.MiddleName)
                    .ApplyOptions(_options.MiddleName);

                builder
                    .Property(_ => _.LastName)
                    .ApplyOptions(_options.LastName);

                builder
                    .Property(_ => _.NameSuffix)
                    .ApplyOptions(_options.NameSuffix);

                builder
                    .Property(_ => _.FullName)
                    .ApplyOptions(_options.FullName);

                builder
                    .Property(_ => _.Username)
                    .ApplyOptions(_options.Username);

                builder
                    .Property(_ => _.SecurePassword)
                    .ApplyOptions(_options.SecurePassword);

                builder
                    .Property(_ => _.EmailAddress)
                    .ApplyOptions(_options.EmailAddress);

                builder
                    .Property(_ => _.MobileNumber)
                    .ApplyOptions(_options.MobileNumber);

                builder
                    .Property(_ => _.IsActive)
                    .ApplyOptions(_options.IsActive);

                builder
                    .Property(_ => _.IsPasswordChangeRequired)
                    .ApplyOptions(_options.IsPasswordChangeRequired);

                builder
                    .Property(_ => _.IsEmailAddressVerified)
                    .ApplyOptions(_options.IsEmailAddressVerified);

                builder
                    .Property(_ => _.IsMobileNumberVerified)
                    .ApplyOptions(_options.IsMobileNumberVerified);
            }
        }
    }
}
