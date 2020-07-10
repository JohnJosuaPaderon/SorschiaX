using Sorschia.SystemCore.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private int? _platformId;
        public int? PlatformId
        {
            get => _platformId;
            set
            {
                _platformId = value;
                Platform = null;
            }
        }

        public Platform Platform { get; private set; }

        public async Task<Platform> GetPlatformAsync(IPlatformRepository repository, CancellationToken cancellationToken = default)
        {
            if (_platformId > 0)
                Platform = await repository.GetAsync(_platformId ?? 0, cancellationToken);

            return Platform;
        }

        public static bool operator ==(Application left, Application right) => Equals(left, right);

        public static bool operator !=(Application left, Application right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Application value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}
