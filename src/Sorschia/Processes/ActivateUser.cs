using MediatR;

namespace Sorschia.Processes
{
    public class ActivateUser : IRequest
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
