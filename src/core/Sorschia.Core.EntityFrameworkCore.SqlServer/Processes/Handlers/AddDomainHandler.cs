using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Processes.Handlers
{
    internal sealed class AddDomainHandler : IRequestHandler<AddDomain.Request, AddDomain.Response>
    {
        public Task<AddDomain.Response> Handle(AddDomain.Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
