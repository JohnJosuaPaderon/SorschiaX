using System.Collections.Generic;

namespace Sorschia.Processes
{
    interface IUpdatePermission : IAsyncProcess<UpdatePermissionInput, UpdatePermissionOutput>
    {
    }

    public sealed class UpdatePermissionInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LookupKey { get; set; }
        public short? ApplicationId { get; set; }
        public int? RoleId { get; set; }
        public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
        public IList<long> DeletedAspNetRouteIds { get; set; }

        public sealed class PermissionAspNetRouteObj
        {
            public long Id { get; set; }
            public string AspNetArea { get; set; }
            public string AspNetController { get; set; }
            public string AspNetAction { get; set; }
        }
    }

    public sealed class UpdatePermissionOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LookupKey { get; set; }
        public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
        public IList<long> DeletedAspNetRouteIds { get; set; }

        public sealed class PermissionAspNetRouteObj
        {
            public long Id { get; set; }
            public string AspNetArea { get; set; }
            public string AspNetController { get; set; }
            public string AspNetAction { get; set; }
        }
    }
}
