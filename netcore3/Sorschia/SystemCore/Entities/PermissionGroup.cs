namespace Sorschia.SystemCore.Entities
{
    public class PermissionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public PermissionGroup Parent { get; private set; }

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
