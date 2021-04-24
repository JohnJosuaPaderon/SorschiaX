using MediatR;
using Sorschia.Teams.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Teams.Processes
{
    public class InsertTeam : IRequest<InsertTeamResult>
    {
        public string Name { get; set; }
        public int LeaderId { get; set; }
        public IEnumerable<int> MemberIds { get; set; }
    }
}
