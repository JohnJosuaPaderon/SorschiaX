using Sorschia.Teams.Entities;
using System.Threading;
using System.Threading.Tasks;
using SystemBase.Entities.Exceptions.Builders;

namespace Sorschia.Teams.Data
{
    internal static class TeamsContextExtensions
    {
        public static async Task<Team> FindTeamAsync(this TeamsContext instance, int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var team = await instance.Teams.FindAsync(new object[] { id }, cancellationToken);

            if (team is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<Team>()
                    .AddField(nameof(Team.Id), id)
                    .WithMessage("Team doesn't exists")
                    .WithDebugMessage($"Team with Id '{id}' doesn't exists")
                    .Build();

            return team;
        }

        public static async Task<Member> FindMemberAsync(this TeamsContext instancce, int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var member = await instancce.Members.FindAsync(new object[] { id }, cancellationToken);

            if (member is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<Member>()
                    .WithDebugMessage($"Member with Id '{id}' doesn't exists")
                    .WithMessage("Member doesn't exists")
                    .AddField(nameof(Member.Id), id)
                    .Build();

            return member;
        }

        public static async Task<Assignment> FindAssignmentAsync(this TeamsContext instance, long id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var assignment = await instance.Assignments.FindAsync(new object[] { id }, cancellationToken);

            if (assignment is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<Assignment>()
                    .WithDebugMessage($"Assignment with Id '{id}' doesn't exists")
                    .WithMessage("Assignement doesn't exists")
                    .AddField(nameof(Assignment.Id), id)
                    .Build();

            return assignment;
        }
    }
}
