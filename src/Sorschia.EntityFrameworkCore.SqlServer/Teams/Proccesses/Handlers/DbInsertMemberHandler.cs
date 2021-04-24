using MediatR;
using Sorschia.Teams.Entities;
using System.Threading;
using System.Threading.Tasks;
using SystemBase.Entities;
using SystemBase.Extensions;

namespace Sorschia.Teams.Proccesses.Handlers
{
    internal sealed class DbInsertMemberHandler : IRequestHandler<DbInsertMember, Member>
    {
        private readonly IFullNameBuilder _fullNameBuilder;

        public DbInsertMemberHandler(IFullNameBuilder fullNameBuilder)
        {
            _fullNameBuilder = fullNameBuilder;
        }

        public async Task<Member> Handle(DbInsertMember request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();
            var member = request.AsMember();
            member.FullName = request.BuildFullName(_fullNameBuilder);
            context.Members.AddWithFootprint(member);
            await context.SaveChangesAsync(cancellationToken);
            return member;
        }
    }
}
