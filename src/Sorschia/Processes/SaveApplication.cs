using MediatR;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class SaveApplication : IRequest<SaveApplication.Result>
    {
        public short Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<RoleObj> Roles { get; set; } = new List<RoleObj>();
        public ICollection<PermissionObj> Permissions { get; set; } = new List<PermissionObj>();
        public ICollection<int> DeletedRoleIds { get; set; } = new List<int>();
        public ICollection<int> DeletedPermissionIds { get; set; } = new List<int>();

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public ICollection<PermissionObj> Permissions { get; set; } = new List<PermissionObj>();
            public ICollection<int> DeletedPermissionIds { get; set; } = new List<int>();
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public ICollection<PermissionAspNetRouteObj> AspNetRoutes { get; set; } = new List<PermissionAspNetRouteObj>();
            public ICollection<long> DeletedAspNetRouteIds { get; set; } = new List<long>();
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
            public ICollection<RoleObj> Roles { get; set; } = new List<RoleObj>();
            public ICollection<PermissionObj> Permissions { get; set; } = new List<PermissionObj>();
            public ICollection<int> DeletedRoleIds { get; set; } = new List<int>();
            public ICollection<int> DeletedPermissionIds { get; set; } = new List<int>();
        }
    }
}
