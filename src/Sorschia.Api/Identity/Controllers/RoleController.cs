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
    [Route(ControllerRoutes.Identity.Role)]
    [ApiVersion(ApiVersions.Identity.V1)]
    public class RoleController : SorschiaApiControllerBase
    {
        [HttpGet(ActionRoutes.Identity.Role.Find)]
        public Task<ActionResult<object>> Find(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ActionResult<object>(id));
        }

        [HttpPost(ActionRoutes.Identity.Role.Insert)]
        public async Task<ActionResult<InsertRoleResult>> Insert([FromBody] InsertRole request, CancellationToken cancellationToken)
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
