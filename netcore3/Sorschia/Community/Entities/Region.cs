namespace Sorschia.Community.Entities
{
    public class Region : PoliticalArea
    {
        private long? _countryId;
        public long? CountryId
        {
            get => _countryId;
            set
            {
                _countryId = value;
                Country = null;
            }
        }

        public Country Country { get; private set; }

        public static bool operator ==(Region left, Region right) => Equals(left, right);

        public static bool operator !=(Region left, Region right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Region value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
