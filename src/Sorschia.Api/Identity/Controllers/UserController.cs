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
    [Route(ControllerRoutes.Identity.User)]
    [ApiVersion(ApiVersions.Identity.V1)]
    public class UserController : SorschiaApiControllerBase
    {
        [HttpGet(ActionRoutes.Identity.User.Find)]
        public Task<ActionResult<object>> Find(int id, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ActionResult<object>(id));
        }

        [HttpPost(ActionRoutes.Identity.User.Insert)]
        public async Task<ActionResult<InsertUserResult>> Insert([FromBody] InsertUser request, CancellationToken cancellationToken)
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
