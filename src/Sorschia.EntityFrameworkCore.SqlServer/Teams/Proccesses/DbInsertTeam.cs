using MediatR;
using Sorschia.Teams.Data;
using Sorschia.Teams.Entities;

namespace Sorschia.Teams.Proccesses
{
    internal sealed class DbInsertTeam : DbRequestBase, IRequest<Team>
    {
        public string Name { get; set; }
        public int LeaderId { get; set; }

        public DbInsertTeam(TeamsContext context) : base(context)
        {
        }
    }
}
