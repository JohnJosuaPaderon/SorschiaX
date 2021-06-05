using MediatR;
using Sorschia.Identity.Processing.Responses;

namespace Sorschia.Identity.Processing.Requests
{
    public class EditPermissionRequest : IRequest<EditPermissionResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LookupCode { get; set; }
        public string Description { get; set; }
    }
}
