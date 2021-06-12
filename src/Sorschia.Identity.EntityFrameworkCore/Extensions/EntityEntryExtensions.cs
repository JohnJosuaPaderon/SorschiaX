using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sorschia.Identity.Data;
using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Extensions
{
    public static class EntityEntryExtensions
    {
        public static EntityEntry<User> SetSecurePassword(this EntityEntry<User> instance, string securePassword)
        {
            instance.Property<string>(ShadowProperties.User.SecurePassword).CurrentValue = securePassword;
            return instance;
        }
    }
}
