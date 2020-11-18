using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.ApplicationPermission)]
    public class ApplicationPermissionController : SorschiaControllerBase
    {
        private readonly IApplicationPermissionRepository _repository;

        public ApplicationPermissionController(IApplicationPermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(SEARCH)]
        public Task<SearchApplicationPermissionResult> Search([FromBody] SearchApplicationPermissionModel model) => _repository.SearchAsync(model);
    }
}
