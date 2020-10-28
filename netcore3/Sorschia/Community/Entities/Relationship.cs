namespace Sorschia.Community.Entities
{
    public class Relationship
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private int? _sexId;
        public int? SexId
        {
            get => _sexId;
            set
            {
                _sexId = value;
                Sex = null;
            }
        }

        public Sex Sex { get; private set; }

        public static bool operator ==(Relationship left, Relationship right) => Equals(left, right);

        public static bool operator !=(Relationship left, Relationship right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Relationship value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}
