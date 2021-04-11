﻿using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal static class DbInsertPermissionExtensions
    {
        public static Permission AsPermission(this DbInsertPermission instance, Role role = null)
        {
            if (instance is null)
                return null;

            return new Permission
            {
                RoleId = instance.RoleId,
                LookupCode = instance.LookupCode,
                Name = instance.Name,
                Description = instance.Description,
                Role = role
            };
        }
    }
}
