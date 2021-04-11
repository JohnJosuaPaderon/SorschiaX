using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Extensions
{
    internal static class EntityEntryExtensions
    {
        public static EntityEntry<User> SetSecurePassword(this EntityEntry<User> instance, string securePassword)
        {
            instance.Property<string>(ShadowProperties.User.SecurePassword).CurrentValue = securePassword;
            return instance;
        }

        public static string GetSecurePassword(this EntityEntry<User> instance)
        {
            return instance.Property<string>(ShadowProperties.User.SecurePassword).CurrentValue;
        }
    }
}
