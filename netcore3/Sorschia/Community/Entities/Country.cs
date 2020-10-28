namespace Sorschia.Community.Entities
{
    public class Country : PoliticalArea
    {
        public static bool operator ==(Country left, Country right) => Equals(left, right);

        public static bool operator !=(Country left, Country right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Country value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
