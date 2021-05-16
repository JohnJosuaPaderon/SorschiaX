using MediatR;
using Sorschia.Core.Data;
using Sorschia.Core.Entities;

namespace Sorschia.Core.Processes
{
    internal static class DbUpdateDomain
    {
        public class Request : DbRequestBase, IRequest<Domain>
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Request(CoreContext dbContext) : base(dbContext)
            {
            }
        }
    }

    internal static class DbUpdateDomainExtensions
    {
        public static Domain ToDomain(this DbUpdateDomain.Request instance)
        {
            return new()
            {
                Id = instance.Id,
                Name = instance.Name
            };
        }
    }
}
