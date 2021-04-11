using MediatR;

namespace Sorschia.Identity.Processes
{
    public class LockUser : IRequest
    {
        public int UserId { get; set; }
    }
}
