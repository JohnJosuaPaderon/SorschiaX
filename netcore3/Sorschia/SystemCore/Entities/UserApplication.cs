using Sorschia.SystemCore.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class UserApplication
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

        private int _applicationId;
        public int ApplicationId
        {
            get => _applicationId;
            set
            {
                _applicationId = value;
                Application = null;
            }
        }

        public Application Application { get; private set; }

        public async Task<User> GetUserAsync(IUserRepository repository, CancellationToken cancellationToken = default)
        {
            if (_userId > 0)
                User = await repository.GetAsync(_userId, cancellationToken);

            return User;
        }

        public async Task<Application> GetApplicationAsync(IApplicationRepository repository, CancellationToken cancellationToken = default)
        {
            if (_applicationId > 0)
                Application = await repository.GetAsync(_applicationId, cancellationToken);

            return Application;
        }

        public static bool operator ==(UserApplication left, UserApplication right) => Equals(left, right);

        public static bool operator !=(UserApplication left, UserApplication right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is UserApplication value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
