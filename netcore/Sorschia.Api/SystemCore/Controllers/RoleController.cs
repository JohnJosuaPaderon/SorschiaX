using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.Role)]
    public class RoleController : SorschiaControllerBase
    {
        private readonly IRoleRepository _repository;

        public RoleController(IRoleRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public Task<bool> Delete([FromBody] DeleteRoleModel model) => _repository.DeleteAsync(model);

        [HttpGet(GET)]
        public Task<Role> Get(int id) => _repository.GetAsync(id);

        [HttpPost]
        public Task<SaveRoleResult> Save([FromBody] SaveRoleModel model) => _repository.SaveAsync(model);

        [HttpPost(SEARCH)]
        public Task<SearchRoleResult> Search([FromBody] SearchRoleModel model) => _repository.SearchAsync(model);
    }
}
