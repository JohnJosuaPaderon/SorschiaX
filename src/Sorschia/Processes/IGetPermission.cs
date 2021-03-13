using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface IGetPermission : IAsyncProcess<GetPermissionInput, GetPermissionOutput>
    {
    }

    public sealed class GetPermissionInput
    {
        public int Id { get; set; }
        public bool AllowDeleted { get; set; }
        public bool IncludeApplication { get; set; }
        public bool IncludeRole { get; set; }
        public bool IncludeAspNetRoutes { get; set; }
        public PermissionAspNetRouteObj AspNetRoute { get; set; }

        public sealed class PermissionAspNetRouteObj : PaginationInputInt64
        {
        }
    }

    public sealed class GetPermissionOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationObj Application { get; set; }
        public RoleObj Role { get; set; }
        public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
        public long AspNetRoutesTotalCount { get; set; }

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
