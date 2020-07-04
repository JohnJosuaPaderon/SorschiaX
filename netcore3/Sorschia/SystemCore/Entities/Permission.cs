namespace Sorschia.SystemCore.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? TypeId { get; set; }
        public int? GroupId { get; set; }

        public PermissionType Type { get; internal set; }
        public PermissionGroup Group { get; internal set; }

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
