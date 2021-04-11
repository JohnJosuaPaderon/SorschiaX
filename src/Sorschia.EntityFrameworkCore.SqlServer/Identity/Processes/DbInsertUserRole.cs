using MediatR;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal sealed class DbInsertUserRole : DbRequestBase, IRequest<UserRole>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public DbInsertUserRole(IdentityContext context) : base(context)
        {
        }
    }
}
