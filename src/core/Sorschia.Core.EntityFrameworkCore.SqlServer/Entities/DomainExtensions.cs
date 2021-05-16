using Sorschia.Core.Processes;

namespace Sorschia.Core.Entities
{
    internal static class DomainExtensions
    {
        public static Domain FromDbUpdateDomainRequest(this Domain instance, DbUpdateDomain.Request request)
        {
            if (request is not null)
            {
                instance.Name = request.Name;
            }

            return instance;
        }
    }
}
