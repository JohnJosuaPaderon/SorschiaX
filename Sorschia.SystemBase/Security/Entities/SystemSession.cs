﻿using System;

namespace Sorschia.SystemBase.Security.Entities
{
    public class SystemSession
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string ApplicationId { get; set; }
        public string MacAddress { get; set; }
        public string IpAddress { get; set; }
        public string OperatingSystem { get; set; }

        public static bool operator ==(SystemSession left, SystemSession right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SystemSession left, SystemSession right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SystemSession value)
            {
                return (Equals(Id, default(Guid)) && Equals(value.Id, default(Guid))) ? false : Equals(Id, value.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
