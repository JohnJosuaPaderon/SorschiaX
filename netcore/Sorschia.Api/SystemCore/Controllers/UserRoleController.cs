using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.UserRole)]
    public class UserRoleController : SorschiaControllerBase
    {
        private readonly IUserRoleRepository _repository;

        public UserRoleController(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(SEARCH)]
        public Task<SearchUserRoleResult> Search([FromBody] SearchUserRoleModel model) => _repository.SearchAsync(model);
    }
}
