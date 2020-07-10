using Sorschia.SystemCore.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class Session
    {
        public Guid Id { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string Operatingsystem { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime? SessionEnd { get; set; }

        private int? _userId;
        public int? UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                User = null;
            }
        }

        public User User { get; private set; }

        private int? _applicationId;
        public int? ApplicationId
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
                User = await repository.GetAsync(_userId ?? 0, cancellationToken);

            return User;
        }

        public async Task<Application> GetApplicationAsync(IApplicationRepository repository, CancellationToken cancellationToken = default)
        {
            if (_applicationId > 0)
                Application = await repository.GetAsync(_applicationId ?? 0, cancellationToken);

            return Application;
        }

        public static bool operator ==(Session left, Session right) => Equals(left, right);

        public static bool operator !=(Session left, Session right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Session value) && (!Equals(Id, default(Guid)) || !Equals(value.Id, default(Guid))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
