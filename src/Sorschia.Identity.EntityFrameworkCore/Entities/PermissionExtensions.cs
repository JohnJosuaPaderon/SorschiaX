using Sorschia.Identity.Processing.Requests;

namespace Sorschia.Identity.Entities
{
    internal static class PermissionExtensions
    {
        public static Permission From(this Permission instance, UpdatePermissionRequest request)
        {
            if (request is not null)
            {
                instance.Name = request.Name;
                instance.LookupCode = request.LookupCode;
                instance.Description = request.Description;
            }

            return instance;
        }
    }
}
