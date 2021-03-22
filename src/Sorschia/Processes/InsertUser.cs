using MediatR;
using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class InsertUser : IRequest<InsertUser.Result>
    {
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameSuffix { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }
        public ICollection<short> ApplicationIds { get; set; } = new List<short>();
        public ICollection<int> RoleIds { get; set; } = new List<int>();
        public ICollection<int> PermissionIds { get; set; } = new List<int>();

        public User ToSource()
        {
            return new User
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                NameSuffix = NameSuffix,
                Username = Username,
                EmailAddress = EmailAddress,
                MobileNumber = MobileNumber,
                IsActive = IsActive,
                IsPasswordChangeRequired = IsPasswordChangeRequired,
                IsEmailAddressVerified = IsEmailAddressVerified,
                IsMobileNumberVerified = IsMobileNumberVerified
            };
        }

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }

            public static implicit operator ApplicationObj?(Application? source)
            {
                if (source is null) return null;

                return new ApplicationObj
                {
                    Id = source.Id,
                    Name = source.Name,
                    Description = source.Description
                };
            }
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }

            public static implicit operator RoleObj?(Role? source)
            {
                if (source is null) return null;

                return new RoleObj
                {
                    Id = source.Id,
                    Name = source.Name,
                    Description = source.Description
                };
            }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }

            public static implicit operator PermissionObj?(Permission? source)
            {
                if (source is null) return null;

                return new PermissionObj
                {
                    Id = source.Id,
                    Name = source.Name,
                    Description = source.Description
                };
            }
        }

        public sealed class UserApplicationObj
        {
            public long Id { get; set; }
            public ApplicationObj? Application { get; set; }

            public static implicit operator UserApplicationObj?(UserApplication? source)
            {
                if (source is null) return null;

                return new UserApplicationObj
                {
                    Id = source.Id,
                    Application = source.Application
                };
            }
        }

        public sealed class UserRoleObj
        {
            public long Id { get; set; }
            public RoleObj? Role { get; set; }

            public static implicit operator UserRoleObj?(UserRole? source)
            {
                if (source is null) return null;

                return new UserRoleObj
                {
                    Id = source.Id,
                    Role = source.Role!
                };
            }
        }

        public sealed class UserPermissionObj
        {
            public long Id { get; set; }
            public PermissionObj? Permission { get; set; }

            public static implicit operator UserPermissionObj?(UserPermission? source)
            {
                if (source is null) return null;

                return new UserPermissionObj
                {
                    Id = source.Id,
                    Permission = source.Permission!
                };
            }
        }

        public class Result
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = default!;
            public string? MiddleName { get; set; }
            public string LastName { get; set; } = default!;
            public string? NameSuffix { get; set; }
            public string FullName { get; set; } = default!;
            public string Username { get; set; } = default!;
            public string? EmailAddress { get; set; }
            public string? MobileNumber { get; set; }
            public bool IsActive { get; set; }
            public bool IsPasswordChangeRequired { get; set; }
            public bool IsEmailAddressVerified { get; set; }
            public bool IsMobileNumberVerified { get; set; }
            public ICollection<UserApplicationObj> UserApplications { get; set; } = new List<UserApplicationObj>();
            public ICollection<UserRoleObj> UserRoles { get; set; } = new List<UserRoleObj>();
            public ICollection<UserPermissionObj> UserPermissions { get; set; } = new List<UserPermissionObj>(); 

            public void FromSource(User? source)
            {
                if (source is null) return;

                Id = source.Id;
                FirstName = source.FirstName;
                MiddleName = source.MiddleName;
                LastName = source.LastName;
                NameSuffix = source.NameSuffix;
                FullName = source.FullName;
                Username = source.Username;
                EmailAddress = source.EmailAddress;
                MobileNumber = source.MobileNumber;
                IsActive = source.IsActive;
                IsPasswordChangeRequired = source.IsPasswordChangeRequired;
                IsEmailAddressVerified = source.IsEmailAddressVerified;
                IsMobileNumberVerified = source.IsMobileNumberVerified;
            }
        }
    }
}
