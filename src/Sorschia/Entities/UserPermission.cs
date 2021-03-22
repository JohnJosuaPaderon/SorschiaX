﻿namespace Sorschia.Entities
{
    public class UserPermission
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public User? User { get; set; }
        public Permission? Permission { get; set; }
    }
}