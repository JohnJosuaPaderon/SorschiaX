﻿using Sorschia.Community.Entities;

namespace Sorschia.Education.Entities
{
    public class School : Organization
    {
        public static bool operator ==(School left, School right) => Equals(left, right);

        public static bool operator !=(School left, School right) => !(left == right);

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return (obj is School value) && (!Equals(Id, default(int)) || !Equals(value.Id, default(int))) && Equals(Id, value.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;
    }
}