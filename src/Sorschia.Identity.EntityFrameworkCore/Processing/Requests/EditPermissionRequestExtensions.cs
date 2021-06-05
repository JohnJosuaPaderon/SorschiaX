namespace Sorschia.Identity.Processing.Requests
{
    internal static class EditPermissionRequestExtensions
    {
        public static UpdatePermissionRequest AsUpdatePermissionRequest(this EditPermissionRequest instance) => new()
        {
            Id = instance.Id,
            Name = instance.Name,
            LookupCode = instance.LookupCode,
            Description = instance.Description
        };
    }
}
