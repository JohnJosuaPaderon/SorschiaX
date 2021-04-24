using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Teams.Data;
using Sorschia.Teams.Entities;
using System.Threading;
using System.Threading.Tasks;
using SystemBase.Entities.Exceptions.Builders;
using SystemBase.Extensions;

namespace Sorschia.Teams.Proccesses.Handlers
{
    internal sealed class DbInsertTeamHandler : IRequestHandler<DbInsertTeam, Team>
    {
        public async Task<Team> Handle(DbInsertTeam request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var leader = await context.FindMemberAsync(request.LeaderId, cancellationToken);

            if (await context.Teams.AnyAsync(_ => _.Name == request.Name, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Team>()
                    .WithMessage("Team already exists")
                    .WithDebugMessage($"Team with Name '{request.Name}' already exists")
                    .Build();

            var team = request.AsTeam();
            context.Teams.AddWithFootprint(team);
            await context.SaveChangesAsync(cancellationToken);
            return team;
        }
    }
}
