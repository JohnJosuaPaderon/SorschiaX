using MediatR;

namespace Sorschia.Processes
{
    public class UpdateUserPassword : IRequest
    {
        public int UserId { get; set; }
        public string Password { get; set; } = default!;
    }
}
