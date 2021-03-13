namespace Sorschia.Data
{
    partial class DataOptions
    {
        public sealed class User_OptionsObj : EntityOptions
        {
            public PropertyOptions Id { get; init; } = new PropertyOptions("Id");
            public StringPropertyOptions FirstName { get; init; } = new StringPropertyOptions("FirstName")
            {
                IsRequired = true,
                MaxLength = 100
            };
            public StringPropertyOptions MiddleName { get; init; } = new StringPropertyOptions("MiddleName")
            {
                MaxLength = 100
            };
            public StringPropertyOptions LastName { get; init; } = new StringPropertyOptions("LastName")
            {
                IsRequired = true,
                MaxLength = 100
            };
            public StringPropertyOptions NameSuffix { get; init; } = new StringPropertyOptions("NameSuffix")
            {
                MaxLength = 5
            };
            public StringPropertyOptions FullName { get; init; } = new StringPropertyOptions("FullName")
            {
                IsRequired = true,
                MaxLength = 350
            };
            public StringPropertyOptions Username { get; init; } = new StringPropertyOptions("Username")
            {
                IsRequired = true,
                MaxLength = 50
            };
            public StringPropertyOptions SecurePassword { get; init; } = new StringPropertyOptions("SecurePassword")
            {
                IsRequired = true,
                MaxLength = 250
            };
            public StringPropertyOptions EmailAddress { get; init; } = new StringPropertyOptions("EmailAddress")
            {
                MaxLength = 250
            };
            public StringPropertyOptions MobileNumber { get; init; } = new StringPropertyOptions("MobileNumber")
            {
                MaxLength = 20
            };
            public PropertyOptions IsActive { get; init; } = new PropertyOptions("IsActive");
            public PropertyOptions IsPasswordChangeRequired { get; init; } = new PropertyOptions("IsPasswordChangeRequired");
            public PropertyOptions IsEmailAddressVerified { get; init; } = new PropertyOptions("IsEmailAddressVerified");
            public PropertyOptions IsMobileNumberVerified { get; init; } = new PropertyOptions("IsMobileNumberVerified");

            public User_OptionsObj(string tableName, string schema = null) : base(tableName, schema)
            {
            }
        }
    }
}
