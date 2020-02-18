using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Entities
{
    public class SystemUserModule
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public bool IsApproved { get; set; }

        public SystemUser User { get; set; }
        public SystemModule Module { get; set; }

        public async Task<SystemUser> GetUserAsync(ISystemBaseSecurityRepository repository, CancellationToken cancellationToken = default)
        {
            if (repository != default && UserId > default(int))
            {
                User = await repository.GetUserAsync(UserId, cancellationToken);
            }

            return User;
        }

        public async Task<SystemModule> GetModuleAsync(ISystemBaseSecurityRepository repository, CancellationToken cancellationToken = default)
        {
            if (repository != default && ModuleId > default(int))
            {
                Module = await repository.GetModuleAsync(ModuleId, cancellationToken);
            }

            return Module;
        }

        public static bool operator ==(SystemUserModule left, SystemUserModule right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SystemUserModule left, SystemUserModule right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SystemUserModule value)
            {
                return (Equals(Id, default(long)) && Equals(value.Id, default(long))) ? false : Equals(Id, value.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class SystemUserPermission
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public bool IsApproved { get; set; }

        public SystemUser User { get; set; }
        public SystemPermission Permission { get; set; }

        public async Task<SystemUser> GetUserAsync(ISystemBaseSecurityRepository repository, CancellationToken cancellationToken = default)
        {
            if (repository != default && UserId > default(int))
            {
                User = await repository.GetUserAsync(UserId, cancellationToken);
            }

            return User;
        }

        public async Task<SystemPermission> GetPermissionAsync(ISystemBaseSecurityRepository repository, CancellationToken cancellationToken = default)
        {
            if (repository != default && PermissionId > default(int))
            {
                Permission = await repository.GetPermissionAsync(PermissionId, cancellationToken);
            }

            return Permission;
        }
    }
}
