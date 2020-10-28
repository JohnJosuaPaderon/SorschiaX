namespace Sorschia.Community.Entities
{
    public class PersonRelative
    {
        public long Id { get; set; }

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

        private int _relativeId;
        public int RelativeId
        {
            get => _relativeId;
            set
            {
                _relativeId = value;
                Relative = null;
            }
        }

        public Person Relative { get; private set; }

        private int? _relationshipId;
        public int? RelationshipId
        {
            get => _relationshipId;
            set
            {
                _relationshipId = value;
                Relationship = null;
            }
        }

        public Relationship Relationship { get; private set; }

        public static bool operator ==(PersonRelative left, PersonRelative right) => Equals(left, right);

        public static bool operator !=(PersonRelative left, PersonRelative right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is PersonRelative value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
