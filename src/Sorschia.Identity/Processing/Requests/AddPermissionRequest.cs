using MediatR;
using Sorschia.Identity.Processing.Responses;

namespace Sorschia.Identity.Processing.Requests
{
    public class AddPermissionRequest : IRequest<AddPermissionResponse>
    {
        public string Name { get; set; }
        public string LookupCode { get; set; }
        public string Description { get; set; }
    }
}
