namespace Sorschia.Data
{
    public partial class SorschiaDataSettings
    {
        public string DefaultSchema { get; set; }
        public ApplicationTableSettings Application { get; set; }
        public PermissionTableSettings Permission { get; set; }
        public RoleSettings Role { get; set; }
        public UserSettings User { get; set; }
        public UserApplicationSettings UserApplication { get; set; }
        public UserPermissionSettings UserPermission { get; set; }
        public UserRoleSettings UserRole { get; set; }

        public static SorschiaDataSettings Default { get; } = new SorschiaDataSettings
        {
            DefaultSchema = "dbo",
            Application = new ApplicationTableSettings
            {
                Name = new ColumnSettings
                {
                    ColumnName = "Name",
                    IsRequired = true,
                    MaxLength = 50
                },
                Description = new ColumnSettings
                {
                    ColumnName = "Description",
                    MaxLength = 500
                }
            },
            Permission = new PermissionTableSettings
            {
                Name = new ColumnSettings
                {
                    ColumnName = "Name",
                    IsRequired = true,
                    MaxLength = 50
                },
                Description = new ColumnSettings
                {
                    ColumnName = "Description",
                    MaxLength = 500
                },
                ApplicationId = new ColumnSettings
                {
                    ColumnName = "ApplicationId"
                },
                WebController = new ColumnSettings
                {
                    ColumnName = "WebController",
                    MaxLength = 200
                },
                WebAction = new ColumnSettings
                {
                    ColumnName = "WebAction",
                    MaxLength = 200
                }
            },
            Role = new RoleSettings
            {
                Name = new ColumnSettings
                {
                    ColumnName = "Name",
                    IsRequired = true,
                    MaxLength = 50
                },
                Description = new ColumnSettings
                {
                    ColumnName = "Description",
                    MaxLength = 500
                },
                ApplicationId = new ColumnSettings
                {
                    ColumnName = "ApplicationId"
                }
            },
            User = new UserSettings
            {
                FirstName = new ColumnSettings
                {
                    ColumnName = "FirstName",
                    IsRequired = true,
                    MaxLength = 50
                },
                MiddleName = new ColumnSettings
                {
                    ColumnName = "MiddleName",
                    MaxLength = 50
                },
                LastName = new ColumnSettings
                {
                    ColumnName = "LastName",
                    IsRequired = true,
                    MaxLength = 50
                },
                NameSuffix = new ColumnSettings
                {
                    ColumnName = "NameSuffix",
                    MaxLength = 5
                },
                FullName = new ColumnSettings
                {
                    ColumnName = "FullName",
                    IsRequired = true,
                    MaxLength = 160
                },
                Username = new ColumnSettings
                {
                    ColumnName = "Username",
                    IsRequired = true,
                    MaxLength = 50
                },
                SecurePassword = new ColumnSettings
                {
                    ColumnName = "SecurePassword",
                    IsRequired = true,
                    MaxLength = 128
                },
                EmailAddress = new ColumnSettings
                {
                    ColumnName = "EmailAddress",
                    MaxLength = 100
                },
                MobileNumber = new ColumnSettings
                {
                    ColumnName = "MobileNumber",
                    MaxLength = 20
                },
                IsActive = new ColumnSettings
                {
                    ColumnName = "IsActive"
                },
                IsPasswordChangeRequired = new ColumnSettings
                {
                    ColumnName = "IsPasswordChangeRequired"
                },
                IsEmailAddressVerified = new ColumnSettings
                {
                    ColumnName = "IsEmailAddressVerified"
                },
                IsMobileNumberVerified = new ColumnSettings
                {
                    ColumnName = "IsMobileNumberVerified"
                }
            },
            UserApplication = new UserApplicationSettings
            {
                UserId = new ColumnSettings
                {
                    ColumnName = "UserId",
                    IsRequired = true
                },
                ApplicationId = new ColumnSettings
                {
                    ColumnName = "ApplicationId",
                    IsRequired = true
                },
                IsUpdateFootprintIgnored = true
            },
            UserPermission = new UserPermissionSettings
            {
                UserId = new ColumnSettings
                {
                    ColumnName = "UserId",
                    IsRequired = true
                },
                PermissionId = new ColumnSettings
                {
                    ColumnName = "PermissionId",
                    IsRequired = true
                },
                IsUpdateFootprintIgnored = true
            },
            UserRole = new UserRoleSettings
            {
                UserId = new ColumnSettings
                {
                    ColumnName = "UserId",
                    IsRequired = true
                },
                RoleId = new ColumnSettings
                {
                    ColumnName = "RoleId",
                    IsRequired = true
                }
            }
        };

        public sealed class ApplicationTableSettings : EntityTableSettings
        {
            public ColumnSettings Name { get; set; }
            public ColumnSettings Description { get; set; }
        }

        public sealed class PermissionTableSettings : EntityTableSettings
        {
            public ColumnSettings Name { get; set; }
            public ColumnSettings Description { get; set; }
            public ColumnSettings ApplicationId { get; set; }
            public ColumnSettings RoleId { get; set; }
            public ColumnSettings WebController { get; set; }
            public ColumnSettings WebAction { get; set; }
        }

        public sealed class RoleSettings : EntityTableSettings
        {
            public ColumnSettings Name { get; set; }
            public ColumnSettings Description { get; set; }
            public ColumnSettings ApplicationId { get; set; }
        }

        public sealed class UserSettings : EntityTableSettings
        {
            public ColumnSettings FirstName { get; set; }
            public ColumnSettings MiddleName { get; set; }
            public ColumnSettings LastName { get; set; }
            public ColumnSettings NameSuffix { get; set; }
            public ColumnSettings FullName { get; set; }
            public ColumnSettings Username { get; set; }
            public ColumnSettings SecurePassword { get; set; }
            public ColumnSettings EmailAddress { get; set; }
            public ColumnSettings MobileNumber { get; set; }
            public ColumnSettings IsActive { get; set; }
            public ColumnSettings IsPasswordChangeRequired { get; set; }
            public ColumnSettings IsEmailAddressVerified { get; set; }
            public ColumnSettings IsMobileNumberVerified { get; set; }
        }

        public sealed class UserApplicationSettings : EntityTableSettings
        {
            public ColumnSettings UserId { get; set; }
            public ColumnSettings ApplicationId { get; set; }
        }

        public sealed class UserPermissionSettings : EntityTableSettings
        {
            public ColumnSettings UserId { get; set; }
            public ColumnSettings PermissionId { get; set; }
        }

        public sealed class UserRoleSettings : EntityTableSettings
        {
            public ColumnSettings UserId { get; set; }
            public ColumnSettings RoleId { get; set; }
        }
    }
}
