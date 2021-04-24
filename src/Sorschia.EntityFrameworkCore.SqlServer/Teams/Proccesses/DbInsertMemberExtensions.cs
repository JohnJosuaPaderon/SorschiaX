using Sorschia.Teams.Entities;
using SystemBase.Entities;

namespace Sorschia.Teams.Proccesses
{
    internal static class DbInsertMemberExtensions
    {
        public static Member AsMember(this DbInsertMember instance)
        {
            if (instance is null)
                return null;

            return new Member
            {
                FirstName = instance.FirstName,
                MiddleName = instance.MiddleName,
                LastName = instance.LastName,
                NameSuffix = instance.NameSuffix
            };
        }

        public static string BuildFullName(this DbInsertMember instance, IFullNameBuilder builder)
        {
            if (instance is null || builder is null)
                return null;

            return builder.Build(instance.FirstName, instance.MiddleName, instance.LastName, instance.NameSuffix);
        }
    }
}
