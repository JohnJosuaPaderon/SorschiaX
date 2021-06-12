using MediatR;
using Sorschia.Identity.Processing.Responses;
using System.Collections.Generic;

namespace Sorschia.Identity.Processing.Requests
{
    public class AddRoleRequest : IRequest<AddRoleResponse>
    {
        public string Name { get; set; }
        public string LookupCode { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}
