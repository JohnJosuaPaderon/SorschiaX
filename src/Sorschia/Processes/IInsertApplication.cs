﻿using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface IInsertApplication : IAsyncProcess<InsertApplicationInput, InsertApplicationOutput>
    {
    }

    public sealed class InsertApplicationInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RoleObj> Roles { get; set; }
        public IList<PermissionObj> Permissions { get; set; }

        public sealed class RoleObj
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public IList<PermissionObj> Permissions { get; set; }
        }

        public sealed class PermissionObj
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string LookupKey { get; set; }
            public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
        }

        public sealed class PermissionAspNetRouteObj
        {
            public string AspNetArea { get; set; }
            public string AspNetController { get; set; }
            public string AspNetAction { get; set; }
        }
    }

    public sealed class InsertApplicationOutput
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<RoleObj> Roles { get; set; }
        public IList<PermissionObj> Permissions { get; set; }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public IList<PermissionObj> Permissions { get; set; }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string LookupKey { get; set; }
            public IList<PermissionAspNetRouteObj> AspNetRoutes { get; set; }
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
