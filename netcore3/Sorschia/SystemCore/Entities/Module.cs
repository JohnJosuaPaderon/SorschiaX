using Sorschia.SystemCore.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrdinalNumber { get; set; }

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

        public async Task<Application> GetApplicationAsync(IApplicationRepository repository, CancellationToken cancellationToken = default)
        {
            if (_applicationId > 0)
                Application = await repository.GetAsync(_applicationId ?? 0, cancellationToken);

            return Application;
        }

        public static bool operator ==(Module left, Module right) => Equals(left, right);

        public static bool operator !=(Module left, Module right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Module value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}
