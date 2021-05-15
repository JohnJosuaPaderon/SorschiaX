using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes.Results
{
    public class InsertPermissionResult : PermissionBase
    {
        public RoleObj Role { get; set; }

        public class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public static implicit operator RoleObj(RoleBase source)
            {
                if (source is null)
                    return null;

                return new()
                {
                    Id = source.Id,
                    Name = source.Name
                };
            }
        }
    }
}
