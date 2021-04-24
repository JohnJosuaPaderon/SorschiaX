using Sorschia.Teams.Entities;
using System.Collections.Generic;

namespace Sorschia.Teams.Processes.Results
{
    public class InsertTeamResult : TeamBase
    {
        public MemberObj Leader { get; set; }
        public IEnumerable<TeamMemberObj> TeamMembers { get; set; }

        public class TeamMemberObj
        {
            public long Id { get; set; }
            public MemberObj Member { get; set; }

            public static implicit operator TeamMemberObj(TeamMember source)
            {
                if (source is null)
                    return null;

                return new()
                {
                    Id = source.Id,
                    Member = source.Member
                };
            }
        }

        public class MemberObj
        {
            public int Id { get; set; }
            public string FullName { get; set; }

            public static implicit operator MemberObj(MemberBase source)
            {
                if (source is null)
                    return null;

                return new()
                {
                    Id = source.Id,
                    FullName = source.FullName
                };
            }
        }
    }
}
