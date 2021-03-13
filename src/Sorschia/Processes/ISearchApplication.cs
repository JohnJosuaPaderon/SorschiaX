using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface ISearchApplication : IAsyncProcess<SearchApplicationInput, SearchApplicationOutput>
    {
    }

    public sealed class SearchApplicationInput : PaginationInputInt32
    {
        public string FilterText { get; set; }
        public bool IncludeRoles { get; set; }
        public bool IncludePermissions { get; set; }
        public RoleObj Role { get; set; }
        public PermissionObj Permission { get; set; }

        public sealed class RoleObj : PaginationInputInt32
        {
            public bool IncludePermissions { get; set; }
            public PermissionObj Permission { get; set; }
        }

        public sealed class PermissionObj : PaginationInputInt32
        {
            public bool IncludeAspNetRoutes { get; set; }
            public PermissionAspNetRouteObj AspNetRoute { get; set; }
        }

        public sealed class PermissionAspNetRouteObj : PaginationInputInt64
        {
        }
    }

    public sealed class SearchApplicationOutput
    {
        public IList<ApplicationObj> Applications { get; set; }
        public int ApplicationsTotalCount { get; set; }

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public IList<RoleObj> Roles { get; set; }
            public int RolesTotalCount { get; set; }
            public IList<PermissionObj> Permissions { get; set; }
            public int PermissionsTotalCount { get; set; }
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public IList<PermissionObj> Permissions { get; set; }
            public int PermissionsTotalCount { get; set; }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string LookupKey { get; set; }
            public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
            public long AspNetRoutesTotalCount { get; set; }
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
