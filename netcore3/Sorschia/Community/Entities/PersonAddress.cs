namespace Sorschia.Community.Entities
{
    public class PersonAddress : Address
    {
        private int _personId;
        public int PersonId
        {
            get => _personId;
            set
            {
                _personId = value;
                Person = null;
            }
        }

        public Person Person { get; private set; }

        public static bool operator ==(PersonAddress left, PersonAddress right) => Equals(left, right);

        public static bool operator !=(PersonAddress left, PersonAddress right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is PersonAddress value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
