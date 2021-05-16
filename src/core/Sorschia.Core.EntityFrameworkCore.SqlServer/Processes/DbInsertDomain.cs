using MediatR;
using Sorschia.Core.Data;
using Sorschia.Core.Entities;

namespace Sorschia.Core.Processes
{
    internal static class DbInsertDomain
    {
        public class Request : DbRequestBase, IRequest<Domain>
        {
            public string Name { get; set; }

            public Request(CoreContext dbContext) : base(dbContext)
            {
            }
        }
    }

    internal static class DbInsertDomainExtensions
    {
        public static Domain ToDomain(this DbInsertDomain.Request instance)
        {
            return new()
            {
                Name = instance.Name
            };
        }
    }
}
