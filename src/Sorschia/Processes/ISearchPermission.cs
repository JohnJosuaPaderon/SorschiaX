using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface ISearchPermission : IAsyncProcess<SearchPermissionInput, SearchPermissionOutput>
    {
    }

    public sealed class SearchPermissionInput : PaginationInputInt32
    {
        public string FilterText { get; set; }
        public bool IncludeApplication { get; set; }
        public bool IncludeRole { get; set; }
        public bool IncludeAspNetRoutes { get; set; }
        public IList<short> ApplicationIds { get; set; }
        public IList<int> RoleIds { get; set; }
        public PermissionAspNetRouteObj AspNetRoute { get; set; }

        public sealed class PermissionAspNetRouteObj : PaginationInputInt64
        {
        }
    }

    public sealed class SearchPermissionOutput
    {
        public IList<PermissionObj> Permissions { get; set; }
        public int PermissionsTotalCount { get; set; }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string LookupKey { get; set; }
            public ApplicationObj Application { get; set; }
            public RoleObj Role { get; set; }
            public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
            public long AspNetRoutesTotalCount { get; set; }
        }

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
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
