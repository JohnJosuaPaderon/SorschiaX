namespace Sorschia.Community.Entities
{
    public class CityMunicipality : PoliticalArea
    {
        public bool IsCity { get; set; }
        public bool IsMunicipality { get; set; }

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

        private long? _provinceId;
        public long? ProvinceId
        {
            get => _provinceId;
            set
            {
                _provinceId = value;
                Province = null;
            }
        }

        public Province Province { get; private set; }

        public static bool operator ==(CityMunicipality left, CityMunicipality right) => Equals(left, right);

        public static bool operator !=(CityMunicipality left, CityMunicipality right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is CityMunicipality value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
