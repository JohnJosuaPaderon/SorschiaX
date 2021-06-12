using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processing.Responses
{
    public class DeletePermissionResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DeletePermissionResponse From(Permission permission)
        {
            if (permission is not null)
            {
                Id = permission.Id;
                Name = permission.Name;
            }

            return this;
        }
    }
}
