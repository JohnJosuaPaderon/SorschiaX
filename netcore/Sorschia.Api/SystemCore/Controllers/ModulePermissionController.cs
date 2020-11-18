using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.ModulePermission)]
    public class ModulePermissionController : SorschiaControllerBase
    {
        private readonly IModulePermissionRepository _repository;

        public ModulePermissionController(IModulePermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(SEARCH)]
        public Task<SearchModulePermissionResult> Search([FromBody] SearchModulePermissionModel model) => _repository.SearchAsync(model);
    }
}
