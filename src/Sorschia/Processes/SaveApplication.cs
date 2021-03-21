using MediatR;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class SaveApplication : IRequest<SaveApplication.Result>
    {
        public short Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<RoleObj> Roles { get; set; } = new HashSet<RoleObj>();
        public ICollection<PermissionObj> Permissions { get; set; } = new HashSet<PermissionObj>();
        public ICollection<int> DeletedRoleIds { get; set; } = new HashSet<int>();
        public ICollection<int> DeletedPermissionIds { get; set; } = new HashSet<int>();

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public ICollection<PermissionObj> Permissions { get; set; } = new HashSet<PermissionObj>();
            public ICollection<int> DeletedPermissionIds { get; set; } = new HashSet<int>();
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public ICollection<PermissionAspNetRouteObj> AspNetRoutes { get; set; } = new HashSet<PermissionAspNetRouteObj>();
            public ICollection<long> DeletedAspNetRouteIds { get; set; } = new HashSet<long>();
        }

        public sealed class PermissionAspNetRouteObj
        {
            public long Id { get; set; }
            public string? AspNetArea { get; set; }
            public string AspNetController { get; set; } = default!;
            public string AspNetAction { get; set; } = default!;
        }

        public class Result
        {
            public short Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public ICollection<RoleObj> Roles { get; set; } = new HashSet<RoleObj>();
            public ICollection<PermissionObj> Permissions { get; set; } = new HashSet<PermissionObj>();
            public ICollection<int> DeletedRoleIds { get; set; } = new HashSet<int>();
            public ICollection<int> DeletedPermissionIds { get; set; } = new HashSet<int>();
        }
    }
}
