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
}
