using Dapper;
using Sorschia.Data;
using Sorschia.Extensions;

namespace Sorschia.Processes
{
    internal static class GetUserExtensions
    {
        public static DynamicParameters AsParams(this GetUser instance)
        {
            return new DynamicParameters()
                .AddInput("Id", instance.Id)
                .AddInput("IncludeUserApplications", instance.IncludeUserApplications)
                .AddInput("UserApplication_IncludeApplication", instance.UserApplication?.IncludeApplication)
                .AddInput("UserApplication_SkippedCount", instance.UserApplication?.SkippedCount)
                .AddInput("UserApplication_TakenCount", instance.UserApplication?.TakenCount)
                .AddValueTypeInput("UserApplication_SkippedApplicationIds", ValueTypes.SmallIntType, instance.UserApplication?.SkippedApplicationIds)
                .AddInput("IncludeUserRoles", instance.IncludeUserRoles)
                .AddInput("UserRole_IncludeRole", instance.UserRole?.IncludeRole)
                .AddInput("UserRole_SkippedCount", instance.UserRole?.SkippedCount)
                .AddInput("UserRole_TakenCount", instance.UserRole?.TakenCount)
                .AddValueTypeInput("UserRole_SkippedRoleIds", ValueTypes.IntType, instance.UserRole?.SkippedRoleIds)
                .AddInput("IncludeUserPermissions", instance.IncludeUserPermissions)
                .AddInput("UserPermission_IncludePermission", instance.UserPermission?.IncludePermission)
                .AddInput("UserPermission_SkippedCount", instance.UserPermission?.SkippedCount)
                .AddInput("UserPermission_TakenCount", instance.UserPermission?.TakenCount)
                .AddValueTypeInput("UserPermission_SkippedPermissionIds", ValueTypes.IntType, instance.UserPermission?.SkippedPermissionIds);
        }
    }
}
