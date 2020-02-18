using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Entities
{
    public class SystemModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrdinalNumber { get; set; }
        public int? ApplicationId { get; set; }

        public SystemApplication Application { get; set; }

        public async Task<SystemApplication> GetApplicationAsync(ISystemBaseSecurityRepository repository, CancellationToken cancellationToken = default)
        {
            if (repository != default && ApplicationId > default(int))
            {
                Application = await repository.GetApplicationAsync(ApplicationId.Value, cancellationToken);
            }

            return Application;
        }

        public static bool operator ==(SystemModule left, SystemModule right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SystemModule left, SystemModule right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SystemModule value)
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
