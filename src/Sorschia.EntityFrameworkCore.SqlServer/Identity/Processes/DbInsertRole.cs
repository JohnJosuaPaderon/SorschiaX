using MediatR;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal sealed class DbInsertRole : DbRequestBase, IRequest<Role>
    {
        public string LookupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DbInsertRole(IdentityContext context) : base(context)
        {
        }
    }
}
