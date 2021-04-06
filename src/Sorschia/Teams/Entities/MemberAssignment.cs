namespace Sorschia.Teams.Entities
{
    public class MemberAssignment : MemberAssignmentBase
    {
        public Member Member { get; set; }
        public Assignment Assignment { get; set; }
    }
}
