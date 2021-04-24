using Sorschia.Teams.Entities;

namespace Sorschia.Teams.Proccesses
{
    internal static class DbInsertTeamExtensions
    {
        public static DbInsertTeam WithLeaderId(this DbInsertTeam instance, int leaderId)
        {
            if (instance is not null)
            {
                instance.LeaderId = leaderId;
            }

            return instance;
        }

        public static Team AsTeam(this DbInsertTeam instance)
        {
            if (instance is null)
                return null;

            return new Team
            {
                Name = instance.Name,
                LeaderId = instance.LeaderId
            };
        }
    }
}
