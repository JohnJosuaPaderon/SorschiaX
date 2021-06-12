using MediatR;
using Sorschia.Identity.Processing.Responses;

namespace Sorschia.Identity.Processing.Requests
{
    public class DeletePermissionRequest : IRequest<DeletePermissionResponse>
    {
        public int Id { get; set; }
    }
}
