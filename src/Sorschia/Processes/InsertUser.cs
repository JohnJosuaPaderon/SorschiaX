using MediatR;
using Sorschia.Processes.Results;

namespace Sorschia.Processes
{
    public class InsertUser : IRequest<InsertUserResult>
    {
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameSuffix { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
    }
}
