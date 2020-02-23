using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Entities
{
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
            var id = UserId;

            if (repository != default && id > default(int))
            {
                User = await repository.GetUserAsync(id, cancellationToken);
            }

            return User;
        }

        public async Task<SystemPermission> GetPermissionAsync(ISystemBaseSecurityRepository repository, CancellationToken cancellationToken = default)
        {
            var id = PermissionId;

            if (repository != default && id > default(int))
            {
                Permission = await repository.GetPermissionAsync(id, cancellationToken);
            }

            return Permission;
        }

        public static bool operator ==(SystemUserPermission left, SystemUserPermission right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SystemUserPermission left, SystemUserPermission right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SystemUserPermission value)
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
}
