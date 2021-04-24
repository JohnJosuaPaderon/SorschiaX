using Sorschia.Teams.Data;
using Sorschia.Teams.Processes;

namespace Sorschia.Teams.Proccesses
{
    internal static class InsertTeamExtensions
    {
        public static DbInsertTeam AsDbInsertTeam(this InsertTeam instance, TeamsContext context)
        {
            if (instance is null)
                return null;

            return new DbInsertTeam(context)
            {
                Name = instance.Name,
                LeaderId = instance.LeaderId
            };
        }
    }
}
