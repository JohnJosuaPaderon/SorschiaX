using MediatR;

namespace Sorschia.Identity.Processes
{
    public class RequireUserPasswordChange : IRequest
    {
        public int UserId { get; set; }
    }
}
