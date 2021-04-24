using MediatR;
using Sorschia.Teams.Data;
using Sorschia.Teams.Entities;

namespace Sorschia.Teams.Proccesses
{
    internal sealed class DbInsertMember : DbRequestBase, IRequest<Member>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }

        public DbInsertMember(TeamsContext context) : base(context)
        {
        }
    }
}
