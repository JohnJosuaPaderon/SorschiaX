using MediatR;

namespace Sorschia.Processes
{
    public class VerifyUserEmailAddress : IRequest
    {
        public int UserId { get; set; }
        public bool IsVerified { get; set; }
    }
}
