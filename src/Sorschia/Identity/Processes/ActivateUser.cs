using MediatR;

namespace Sorschia.Identity.Processes
{
    public class ActivateUser : IRequest
    {
        public int UserId { get; set; }
    }
}
