using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processing.Responses
{
    public class EditPermissionResponse : PermissionBase
    {
        public EditPermissionResponse From(Permission permission)
        {
            if (permission is not null)
            {
                Id = permission.Id;
                Name = permission.Name;
                LookupCode = permission.LookupCode;
                Description = permission.Description;
            }

            return this;
        }
    }
}
