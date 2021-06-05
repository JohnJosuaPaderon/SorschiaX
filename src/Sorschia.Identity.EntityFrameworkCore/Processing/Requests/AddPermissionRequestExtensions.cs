namespace Sorschia.Identity.Processing.Requests
{
    internal static class AddPermissionRequestExtensions
    {
        public static InsertPermissionRequest AsInsertPermissionRequest(this AddPermissionRequest instance) => new()
        {
            Name = instance.Name,
            LookupCode = instance.LookupCode,
            Description = instance.Description
        };
    }
}
