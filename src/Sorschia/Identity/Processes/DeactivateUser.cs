using MediatR;

namespace Sorschia.Identity.Processes
{
    public class DeactivateUser : IRequest
    {
        public int UserId { get; set; }
    }
}
