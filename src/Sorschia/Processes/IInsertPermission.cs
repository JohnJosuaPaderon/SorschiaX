using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface IInsertPermission : IAsyncProcess<InsertPermissionInput, InsertPermissionOutput>
    {
    }

    public sealed class InsertPermissionInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LookupKey { get; set; }
        public short? ApplicationId { get; set; }
        public int? RoleId { get; set; }
        public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }

        public sealed class PermissionAspNetRouteObj
        {
            public string AspNetArea { get; set; }
            public string AspNetController { get; set; }
            public string AspNetAction { get; set; }
        }
    }

    public sealed class InsertPermissionOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LookupKey { get; set; }
        public ApplicationObj Application { get; set; }
        public RoleObj Role { get; set; }
        public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
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
