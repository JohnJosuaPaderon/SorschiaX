using MediatR;
using Sorschia.Identity.Processes.Results;

namespace Sorschia.Identity.Processes
{
    public class InsertPermission : IRequest<InsertPermissionResult>
    {
        public int? RoleId { get; set; }
        public string LookupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
