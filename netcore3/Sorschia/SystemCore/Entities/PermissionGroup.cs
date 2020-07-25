using Sorschia.SystemCore.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class PermissionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private int? _parentId;
        public int? ParentId
        {
            get => _parentId;
            set
            {
                _parentId = value;
                Parent = null;
            }
        }

        public PermissionGroup Parent { get; private set; }

        public async Task<PermissionGroup> GetParentAsync(IPermissionGroupRepository repository, CancellationToken cancellationToken = default)
        {
            if (_parentId != 0)
                Parent = await repository.GetAsync(_parentId ?? 0, cancellationToken);

            return Parent;
        }

        public static bool operator ==(PermissionGroup left, PermissionGroup right) => Equals(left, right);

        public static bool operator !=(PermissionGroup left, PermissionGroup right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is PermissionGroup value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}
