using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.RolePermission)]
    public class RolePermissionController : SorschiaControllerBase
    {
        private readonly IRolePermissionRepository _repository;

        public RolePermissionController(IRolePermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(SEARCH)]
        public Task<SearchRolePermissionResult> Search([FromBody] SearchRolePermissionModel model) => _repository.SearchAsync(model);
    }
}
