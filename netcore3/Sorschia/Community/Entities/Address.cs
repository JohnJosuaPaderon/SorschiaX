using System;
using System.Collections.Generic;
using System.Text;

namespace Sorschia.Community.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public string HouseBuildingNumber { get; set; }
        public string Street { get; set; }

        private long? _barangayId;
        public long? BarangayId
        {
            get => _barangayId;
            set
            {
                _barangayId = value;
                Barangay = null;
            }
        }

        public Barangay Barangay { get; private set; }

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

        private int? _categoryId;
        public int? CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
                Category = null;
            }
        }

        public AddressCategory Category { get; private set; }

        public static bool operator ==(Address left, Address right) => Equals(left, right);

        public static bool operator !=(Address left, Address right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Address value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
