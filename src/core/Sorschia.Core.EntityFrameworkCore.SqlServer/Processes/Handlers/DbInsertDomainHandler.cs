using MediatR;
using Sorschia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Processes.Handlers
{
    internal sealed class DbInsertDomainHandler : IRequestHandler<DbInsertDomain.Request, Domain>
    {
        public Task<Domain> Handle(DbInsertDomain.Request request, CancellationToken cancellationToken)
        {
            var context = request.DbContext;


        }
    }
}
