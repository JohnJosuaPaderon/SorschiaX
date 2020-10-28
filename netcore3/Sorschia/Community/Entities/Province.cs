namespace Sorschia.Community.Entities
{
    public class Province : PoliticalArea
    {
        private long? _regionId;
        public long? RegionId
        {
            get => _regionId;
            set
            {
                _regionId = value;
                Region = null;
            }
        }

        public Region Region { get; private set; }

        public static bool operator ==(Province left, Province right) => Equals(left, right);

        public static bool operator !=(Province left, Province right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Province value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
