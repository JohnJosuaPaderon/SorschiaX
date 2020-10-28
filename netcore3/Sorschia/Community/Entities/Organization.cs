using System;

namespace Sorschia.Community.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public bool IsActive { get; set; }

        private int? _sectorId;
        public int? SectorId
        {
            get => _sectorId;
            set
            {
                _sectorId = value;
                Sector = null;
            }
        }

        public Sector Sector { get; private set; }

        public static bool operator ==(Organization left, Organization right) => Equals(left, right);

        public static bool operator !=(Organization left, Organization right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is Organization value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}
