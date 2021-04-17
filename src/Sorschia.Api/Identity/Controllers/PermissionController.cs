using Microsoft.AspNetCore.Mvc;
using Sorschia.Api.Controllers;
using Sorschia.Api.Routing;
using Sorschia.Api.Versioning;
using Sorschia.Identity.Processes;
using Sorschia.Identity.Processes.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Api.Identity.Controllers
{
    [ApiController]
    [Route(ControllerRoutes.Identity.Permission)]
    [ApiVersion(ApiVersions.Identity.V1)]
    public class PermissionController : SorschiaApiControllerBase
    {
        [HttpGet(ActionRoutes.Identity.Permission.Find)]
        public Task<ActionResult<object>> Find(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ActionResult<object>(id));
        }

        [HttpPost(ActionRoutes.Identity.Permission.Insert)]
        public async Task<ActionResult<InsertPermissionResult>> Insert([FromBody] InsertPermission request, CancellationToken cancellationToken)
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
