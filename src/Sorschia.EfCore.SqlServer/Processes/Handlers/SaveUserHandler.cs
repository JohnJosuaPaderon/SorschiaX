using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using Sorschia.Processes.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes.Handlers
{
    internal sealed class SaveUserHandler : IRequestHandler<SaveUser, SaveUserResult>
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;

        public SaveUserHandler(IDbContextFactory<SorschiaDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<SaveUserResult> Handle(SaveUser request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
