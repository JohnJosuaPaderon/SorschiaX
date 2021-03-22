using MediatR;
using Sorschia.Entities;
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

        public Application ToSource()
        {
            return new Application
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public ICollection<PermissionObj> Permissions { get; set; } = new List<PermissionObj>();
            public ICollection<int> DeletedPermissionIds { get; set; } = new List<int>();

            public Role ToSource()
            {
                return new Role
                {
                    Id = Id,
                    Name = Name,
                    Description = Description
                };
            }

            public void FromSource(Role? source)
            {
                if (source is null) return;

                Id = source.Id;
                Name = source.Name;
                Description = source.Description;
            }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
            public ICollection<PermissionAspNetRouteObj> AspNetRoutes { get; set; } = new List<PermissionAspNetRouteObj>();
            public ICollection<long> DeletedAspNetRouteIds { get; set; } = new List<long>();

            public Permission ToSource(short? applicationId, int? roleId)
            {
                return new Permission
                {
                    Id = Id,
                    Name = Name,
                    Description = Description,
                    ApplicationId = applicationId,
                    RoleId = roleId
                };
            }

            public void FromSource(Permission? source)
            {
                if (source is null) return;
                
                Id = source.Id;
                Name = source.Name;
                Description = source.Description;
            }
        }

        public sealed class PermissionAspNetRouteObj
        {
            public long Id { get; set; }
            public string? AspNetArea { get; set; }
            public string AspNetController { get; set; } = default!;
            public string AspNetAction { get; set; } = default!;

            public PermissionAspNetRoute ToSource(int permissionId)
            {
                return new PermissionAspNetRoute
                {
                    Id = Id,
                    PermissionId = permissionId,
                    AspNetArea = AspNetArea,
                    AspNetController = AspNetController,
                    AspNetAction = AspNetController
                };
            }

            public static implicit operator PermissionAspNetRouteObj?(PermissionAspNetRoute? source)
            {
                if (source is null) return null;

                return new PermissionAspNetRouteObj
                {
                    Id = source.Id,
                    AspNetArea = source.AspNetArea,
                    AspNetController = source.AspNetController,
                    AspNetAction = source.AspNetAction
                };
            }
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

            public void FromSource(Application? source)
            {
                if (source is null) return;

                Id = source.Id;
                Name = source.Name;
                Description = source.Description;
            }
        }
    }
}
