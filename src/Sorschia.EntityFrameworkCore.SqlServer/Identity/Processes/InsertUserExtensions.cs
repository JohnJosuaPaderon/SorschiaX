using Sorschia.Identity.Data;

namespace Sorschia.Identity.Processes
{
    internal static class InsertUserExtensions
    {
        public static DbInsertUser AsDbInsertUser(this InsertUser instance, IdentityContext context)
        {
            if (instance is null)
                return null;

            return new DbInsertUser(context)
            {
                FirstName = instance.FirstName,
                MiddleName = instance.MiddleName,
                LastName = instance.LastName,
                NameSuffix = instance.NameSuffix,
                Username = instance.Username,
                Password = instance.Password,
                Status = instance.Status,
                IsPasswordChangeRequired = instance.IsPasswordChangeRequired
            };
        }
    }
}
