using System;

namespace Sorschia.Community.Entities
{
    public class OrganizationMember
    {
        public long Id { get; set; }
        public DateTime? JoinDate { get; set; }
        public bool IsActive { get; set; }

        private int _organizationId;
        public int OrganizationId
        {
            get => _organizationId;
            set
            {
                _organizationId = value;
                Organization = null;
            }
        }

        public Organization Organization { get; private set; }

        private int _memberId;
        public int MemberId
        {
            get => _memberId;
            set
            {
                _memberId = value;
                Member = null;
            }
        }

        public Person Member { get; private set; }

        private int? _roleId;
        public int? RoleId
        {
            get => _roleId;
            set
            {
                _roleId = value;
                Role = null;
            }
        }

        public Role Role { get; private set; }

        public static bool operator ==(OrganizationMember left, OrganizationMember right) => Equals(left, right);

        public static bool operator !=(OrganizationMember left, OrganizationMember right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is OrganizationMember value) && (!Equals(Id, default(long)) || !Equals(value.Id, default(long))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
