using MediatR;

namespace Sorschia.Processes
{
    public class RequireUserPasswordChange : IRequest
    {
        public int UserId { get; set; }
        public bool IsRequired { get; set; }
    }
}
