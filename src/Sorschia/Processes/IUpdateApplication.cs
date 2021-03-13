using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface IUpdateApplication : IAsyncProcess<UpdateApplicationInput, UpdateApplicationOutput>
    {
    }

    public sealed class UpdateApplicationInput
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RoleObj> Roles { get; set; }
        public IList<PermissionObj> Permissions { get; set; }
        public IList<int> DeletedRoleIds { get; set; }
        public IList<int> DeletedPermissionIds { get; set; }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public IList<PermissionObj> Permissions { get; set; }
            public IList<int> DeletedPermissionIds { get; set; }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string LookupKey { get; set; }
            public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
            public IList<long> DeletedAspNetRouteIds { get; set; }
        }

        public sealed class PermissionAspNetRouteObj
        {
            public long Id { get; set; }
            public string AspNetArea { get; set; }
            public string AspNetController { get; set; }
            public string AspNetAction { get; set; }
        }
    }

    public sealed class UpdateApplicationOutput
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RoleObj> Roles { get; set; }
        public IList<PermissionObj> Permissions { get; set; }
        public IList<int> DeletedRoleIds { get; set; }
        public IList<int> DeletedPermissionIds { get; set; }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public IList<PermissionObj> Permissions { get; set; }
            public IList<int> DeletedPermissionIds { get; set; }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string LookupKey { get; set; }
            public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
            public IList<long> DeletedAspNetRouteIds { get; set; }
        }

        public sealed class PermissionAspNetRouteObj
        {
            public long Id { get; set; }
            public string AspNetArea { get; set; }
            public string AspNetController { get; set; }
            public string AspNetAction { get; set; }
        }
    }
}
