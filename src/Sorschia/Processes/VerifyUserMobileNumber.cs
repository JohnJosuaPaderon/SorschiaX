using MediatR;

namespace Sorschia.Processes
{
    public class VerifyUserMobileNumber : IRequest
    {
        public int UserId { get; set; }
        public bool IsVerified { get; set; }
    }
}
