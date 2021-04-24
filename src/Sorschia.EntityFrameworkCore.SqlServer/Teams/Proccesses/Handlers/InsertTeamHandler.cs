using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Teams.Data;
using Sorschia.Teams.Entities;
using Sorschia.Teams.Processes;
using Sorschia.Teams.Processes.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Teams.Proccesses.Handlers
{
    internal sealed class InsertTeamHandler : IRequestHandler<InsertTeam, InsertTeamResult>
    {
        private readonly IDbContextFactory<TeamsContext> _contextFactory;
        private readonly IMediator _mediator;

        public InsertTeamHandler(IDbContextFactory<TeamsContext> contextFactory, IMediator mediator)
        {
            _contextFactory = contextFactory;
            _mediator = mediator;
        }

        public async Task<InsertTeamResult> Handle(InsertTeam request, CancellationToken cancellationToken)
        {
            using var context = _contextFactory.CreateDbContext();
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            var result = new InsertTeamResult();
            var team = await _mediator.Send(request.AsDbInsertTeam(context), cancellationToken);
            result.Set(team);
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        }

        private async Task InsertTeamMembersAsync(TeamsContext context, Team team, IEnumerable<int> memberIds, InsertTeamResult result, CancellationToken cancellationToken)
        {
            if (memberIds is null)
                return;

            var teamMembers = new List<InsertTeamResult.TeamMemberObj>();

            foreach (var memberId in memberIds)
            {
                teamMembers.Add(await _mediator.Send(new DbInsertTeamMember(context), cancellationToken));
            }

            result.TeamMembers = teamMembers;
        }
    }
}
