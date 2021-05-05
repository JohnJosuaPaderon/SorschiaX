using MediatR;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal sealed class DbInsertPermission : DbRequestBase, IRequest<Permission>
    {
        public Role Role { get; set; }
        public int? RoleId { get; set; }
        public string LookupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DbInsertPermission(IdentityContext context) : base(context)
        {
        }
    }
}
