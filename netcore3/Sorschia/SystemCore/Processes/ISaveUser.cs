using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using Sorschia.Utilities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveUser : IAsyncProcess<SaveUserResult>
    {
        SaveUserModel Model { get; set; }
    }

    public sealed class SaveUserModel
    {
        public sealed class UserObj : NameBase
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string CipherNewPassword { get; set; }
            public string CipherOldPassword { get; set; }
            public bool IsActive { get; set; }
            public bool IsPasswordChangeRequired { get; set; }

            public static implicit operator User(UserObj source)
            {
                if (source is null) return null;

                return new User
                {
                    Id = source.Id,
                    FirstName = source.FirstName,
                    MiddleName = source.MiddleName,
                    LastName = source.LastName,
                    NameExtension = source.NameExtension,
                    Username = source.Username,
                    IsActive = source.IsActive,
                    IsPasswordChangeRequired = source.IsPasswordChangeRequired
                };
            }
        }

        public UserObj User { get; set; }
        public IList<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
        public IList<UserModule> UserModules { get; set; } = new List<UserModule>();
        public IList<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
        public IList<DeleteUserApplicationModel> DeletedUserApplications { get; set; } = new List<DeleteUserApplicationModel>();
        public IList<DeleteUserModuleModel> DeletedUserModules { get; set; } = new List<DeleteUserModuleModel>();
        public IList<DeleteUserPermissionModel> DeletedUserPermissions { get; set; } = new List<DeleteUserPermissionModel>();
    }

    public sealed class SaveUserResult
    {
        public User User { get; set; }
        public IList<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
        public IList<UserModule> UserModules { get; set; } = new List<UserModule>();
        public IList<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
        public IList<long> DeletedUserApplicationIds { get; set; } = new List<long>();
        public IList<long> DeletedUserModuleIds { get; set; } = new List<long>();
        public IList<long> DeletedUserPermissionIds { get; set; } = new List<long>();
    }
}
