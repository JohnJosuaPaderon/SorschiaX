using Sorschia.SystemCore.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class UserPermission
    {
        public long Id { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? Expiration { get; set; }
        public bool IsExpired { get; set; }

        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                User = null;
            }
        }

        public User User { get; private set; }

        private int _permissionId;
        public int PermissionId
        {
            get => _permissionId;
            set
            {
                _permissionId = value;
                Permission = null;
            }
        }

        public Permission Permission { get; private set; }

        public async Task<User> GetUserAsync(IUserRepository repository, CancellationToken cancellationToken = default)
        {
            if (_userId != 0)
                User = await repository.GetAsync(_userId, cancellationToken);

            return User;
        }

        public async Task<Permission> GetPermissionAsync(IPermissionRepository repository, CancellationToken cancellationToken = default)
        {
            if (_permissionId != 0)
                Permission = await repository.GetAsync(_permissionId, cancellationToken);

            return Permission;
        }

        public static bool operator ==(UserPermission left, UserPermission right) => Equals(left, right);

        public static bool operator !=(UserPermission left, UserPermission right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is UserPermission value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
