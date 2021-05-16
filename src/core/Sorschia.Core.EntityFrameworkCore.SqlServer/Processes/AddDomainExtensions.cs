using Sorschia.Core.Data;
using Sorschia.Core.Entities;

namespace Sorschia.Core.Processes
{
    internal static class AddDomainExtensions
    {
        public static DbInsertDomain.Request ToDbInsertDomainRequest(this AddDomain.Request instance, CoreContext dbContext)
        {
            if (dbContext is null)
                return null;

            return new(dbContext)
            {
                Name = instance.Name
            };
        }

        public static AddDomain.Response FromDomain(this AddDomain.Response instance, Domain domain)
        {
            if (domain is not null)
            {
                instance.Id = domain.Id;
                instance.Name = domain.Name;
            }

            return instance;
        }
    }
}
