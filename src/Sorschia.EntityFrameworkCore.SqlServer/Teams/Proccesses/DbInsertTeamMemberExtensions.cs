using Sorschia.Teams.Entities;

namespace Sorschia.Teams.Proccesses
{
    internal static class DbInsertTeamMemberExtensions
    {
        public static DbInsertTeamMember WithTeamId(this DbInsertTeamMember instance, int teamId)
        {
            if (instance is not null && teamId != 0)
                instance.TeamId = teamId;

            return instance;
        }

        public static DbInsertTeamMember WithTeam(this DbInsertTeamMember instance, Team team)
        {
            if (instance is not null && team is not null)
            {
                instance.Team = team;
                instance.TeamId = team.Id;
            }

            return instance;
        }

        public static DbInsertTeamMember WithMemberId(this DbInsertTeamMember instance, int memberId)
        {
            if (instance is not null && memberId != 0)
                instance.MemberId = memberId;

            return instance;
        }

        public static DbInsertTeamMember WithMember(this DbInsertTeamMember instance, Member member)
        {
            if (instance is not null && member is not null)
            {
                instance.Member = member;
                instance.MemberId = member.Id;
            }

            return instance;
        }

        public static TeamMember AsTeamMember(this DbInsertTeamMember instance, Team team = null, Member member = null)
        {
            if (instance is null)
                return null;

            return new TeamMember
            {
                TeamId = instance.TeamId,
                Team = team
            };
        }
    }
}
