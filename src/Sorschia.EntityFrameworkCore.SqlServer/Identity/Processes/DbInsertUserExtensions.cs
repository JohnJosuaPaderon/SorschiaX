using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal static class DbInsertUserExtensions
    {
        public static User AsUser(this DbInsertUser instance)
        {
            if (instance is null)
                return null;

            return new User
            {
                FirstName = instance.FirstName,
                MiddleName = instance.MiddleName,
                LastName = instance.LastName,
                NameSuffix = instance.NameSuffix,
                Username = instance.Username,
                Status = instance.Status,
                IsPasswordChangeRequired = instance.IsPasswordChangeRequired
            };
        }
    }
}
