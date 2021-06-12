namespace Sorschia.Identity.Processing.Requests
{
    internal static class AddRoleRequestExtensions
    {
        public static InsertRoleRequest AsInsertRoleRequest(this AddRoleRequest instance) => new()
        {
            Name = instance.Name,
            LookupCode = instance.LookupCode,
            Description = instance.Description
        };
    }
}
