using Sorschia.Teams.Entities;

namespace Sorschia.Teams.Processes.Results
{
    public static class InsertTeamResultExtensions
    {
        public static InsertTeamResult Set(this InsertTeamResult instance, Team team)
        {
            if (instance is not null && team is not null)
            {
                instance.Id = team.Id;
                instance.Name = team.Name;
                instance.Leader = team.Leader;
                instance.LeaderId = team.LeaderId;
            }

            return instance;
        }
    }
}
