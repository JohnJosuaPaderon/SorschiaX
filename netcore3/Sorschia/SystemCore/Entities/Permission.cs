using Sorschia.SystemCore.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Description { get; set; }

        private int? _groupId;
        public int? GroupId
        {
            get => _groupId;
            set
            {
                _groupId = value;
                Group = null;
            }
        }

        public PermissionGroup Group { get; private set; }

        public async Task<PermissionGroup> GetGroupAsync(IPermissionGroupRepository repository, CancellationToken cancellationToken = default)
        {
            if (_groupId > 0)
                Group = await repository.GetAsync(_groupId ?? 0, cancellationToken);

            return Group;
        }

        public static bool operator ==(Permission left, Permission right) => Equals(left, right);

        public static bool operator !=(Permission left, Permission right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Permission value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Description;
    }
}
