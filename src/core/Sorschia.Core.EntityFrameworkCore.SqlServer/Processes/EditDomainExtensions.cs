using Sorschia.Core.Data;
using Sorschia.Core.Entities;

namespace Sorschia.Core.Processes
{
    internal static class EditDomainExtensions
    {
        public static DbUpdateDomain.Request ToDbUpdateDomainRequest(this EditDomain.Request instance, CoreContext dbContext)
        {
            if (dbContext is null)
                return null;

            return new(dbContext)
            {
                Id = instance.Id,
                Name = instance.Name
            };
        }

        public static EditDomain.Response FromDomain(this EditDomain.Response instance, Domain domain)
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
