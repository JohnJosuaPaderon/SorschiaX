using Sorschia.SystemCore.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class UserModule
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

        private int _moduleId;
        public int ModuleId
        {
            get => _moduleId;
            set
            {
                _moduleId = value;
                Module = null;
            }
        }

        public Module Module { get; private set; }

        public async Task<User> GetUserAsync(IUserRepository repository, CancellationToken cancellationToken = default)
        {
            if (_userId > 0)
                User = await repository.GetAsync(_userId, cancellationToken);

            return User;
        }

        public async Task<Module> GetModuleAsync(IModuleRepository repository, CancellationToken cancellationToken = default)
        {
            if (_moduleId > 0)
                Module = await repository.GetAsync(_moduleId, cancellationToken);

            return Module;
        }

        public static bool operator ==(UserModule left, UserModule right) => Equals(left, right);

        public static bool operator !=(UserModule left, UserModule right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is UserModule value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
