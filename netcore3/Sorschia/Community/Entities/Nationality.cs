namespace Sorschia.Community.Entities
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public static bool operator ==(Nationality left, Nationality right) => Equals(left, right);

        public static bool operator !=(Nationality left, Nationality right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Nationality value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}
