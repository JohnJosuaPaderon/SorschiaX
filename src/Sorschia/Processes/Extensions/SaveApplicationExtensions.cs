using Sorschia.Entities;
using System.Runtime.Serialization;

namespace Sorschia.Processes.Extensions
{
    public static class SaveApplicationExtensions
    {
        public static void FromRequest(this Application instance, SaveApplication? request, bool includeId = false)
        {
            if (request is null) return;

            if (includeId)
                instance.Id = request.Id;

            instance.Name = request.Name;
            instance.Description = request.Description;
        }

        public static bool HasChanges(this Application instance, SaveApplication? request)
        {
            if (request is null) return false;

            return
                instance.Name != request.Name ||
                instance.Description != request.Description;
        }

        public static void FromRequest(this Role instance, SaveApplication.RoleObj? requestRole, short? applicationId, bool includeId = false)
        {
            if (requestRole is null) return;

            if (includeId)
                instance.Id = requestRole.Id;

            instance.Name = requestRole.Name;
            instance.Description = requestRole.Description;
            instance.ApplicationId = applicationId;
        }

        public static bool HasChanges(this Role instance, SaveApplication.RoleObj? requestRole, short? applicationId)
        {
            if (requestRole is null) return false;

            return
                instance.Name != requestRole.Name ||
                instance.Description != requestRole.Description ||
                instance.ApplicationId != applicationId;
        }

        public static void FromRequest(this Permission instance, SaveApplication.PermissionObj? requestPermission, short? applicationId, int? roleId, bool includeId = false)
        {
            if (requestPermission is null) return;

            if (includeId)
                instance.Id = requestPermission.Id;

            instance.Name = requestPermission.Name;
            instance.Description = requestPermission.Description;
            instance.ApplicationId = applicationId;
            instance.RoleId = roleId;
        }

        public static bool HasChanges(this Permission instance, SaveApplication.PermissionObj? requestPermission, short? applicationId, int? roleId)
        {
            if (requestPermission is null) return false;

            return
                instance.Name != requestPermission.Name ||
                instance.Description != requestPermission.Description ||
                instance.ApplicationId != applicationId ||
                instance.RoleId != roleId;
        }

        public static void FromRequest(this PermissionAspNetRoute instance, SaveApplication.PermissionAspNetRouteObj? requestPermissionAspNetRoute, int permissionId, bool includeId = false)
        {
            if (requestPermissionAspNetRoute is null) return;

            if (includeId)
                instance.Id = requestPermissionAspNetRoute.Id;

            instance.PermissionId = permissionId;
            instance.AspNetArea = requestPermissionAspNetRoute.AspNetArea;
            instance.AspNetController = requestPermissionAspNetRoute.AspNetController;
            instance.AspNetAction = requestPermissionAspNetRoute.AspNetAction;
        }

        public static bool HasChanges(this PermissionAspNetRoute instance, SaveApplication.PermissionAspNetRouteObj? requestPermissionAspNetRoute, int permissionId)
        {
            if (requestPermissionAspNetRoute is null) return false;

            return
                instance.PermissionId != permissionId ||
                instance.AspNetArea != requestPermissionAspNetRoute.AspNetArea ||
                instance.AspNetController != requestPermissionAspNetRoute.AspNetController ||
                instance.AspNetAction != requestPermissionAspNetRoute.AspNetAction;
        }
    }
}
