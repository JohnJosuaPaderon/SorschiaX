using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Entities
{
    public class SystemApplication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PlatformId { get; set; }

        public SystemApplicationPlatform Platform { get; set; }

        public async Task<SystemApplicationPlatform> GetPlatformAsync(ISystemBaseSecurityRepository repository, CancellationToken cancellationToken = default)
        {
            var id = PlatformId ?? default;

            if (repository != default && id > default(int))
            {
                Platform = await repository.GetApplicationPlatformAsync(id, cancellationToken);
            }

            return Platform;
        }

        public static bool operator ==(SystemApplication left, SystemApplication right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SystemApplication left, SystemApplication right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SystemApplication value)
            {
                return (Equals(Id, default(int)) && Equals(value.Id, default(int))) ? false : Equals(Id, value.Id);
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

        public override string ToString()
        {
            return Name;
        }
    }
}
