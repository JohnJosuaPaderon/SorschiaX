using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.UserPermission)]
    public class UserPermissionController : SorschiaControllerBase
    {
        private readonly IUserPermissionRepository _repository;

        public UserPermissionController(IUserPermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(SEARCH)]
        public Task<SearchUserPermissionResult> Search([FromBody] SearchUserPermissionModel model) => _repository.SearchAsync(model);
    }
}
