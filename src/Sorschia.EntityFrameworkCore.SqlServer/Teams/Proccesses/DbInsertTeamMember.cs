using MediatR;
using Sorschia.Teams.Data;
using Sorschia.Teams.Entities;

namespace Sorschia.Teams.Proccesses
{
    internal sealed class DbInsertTeamMember : DbRequestBase, IRequest<TeamMember>
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DbInsertTeamMember(TeamsContext context) : base(context)
        {
        }
    }
}
