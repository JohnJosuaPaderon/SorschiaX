namespace Sorschia.Community.Entities
{
    public class Barangay : PoliticalArea
    {
        private long? _cityMunicipalityId;
        public long? CityMunicipalityId
        {
            get => _cityMunicipalityId;
            set
            {
                _cityMunicipalityId = value;
                CityMunicipality = null;
            }
        }

        public CityMunicipality CityMunicipality { get; private set; }
    }
}
