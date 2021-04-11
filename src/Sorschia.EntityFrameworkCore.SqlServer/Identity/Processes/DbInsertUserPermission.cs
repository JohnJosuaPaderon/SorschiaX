﻿using MediatR;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal sealed class DbInsertUserPermission : DbRequestBase, IRequest<UserPermission>
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public DbInsertUserPermission(IdentityContext context) : base(context)
        {
        }
    }
}