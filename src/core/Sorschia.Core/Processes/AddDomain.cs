using MediatR;
using Sorschia.Core.Entities;

namespace Sorschia.Core.Processes
{
    public static class AddDomain
    {
        public class Request : IRequest<Response>
        {
            public string Name { get; set; } = "";
        }

        public class Response : DomainBase
        {
        }
    }
}
