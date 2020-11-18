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
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.Permission)]
    public class PermissionController : SorschiaControllerBase
    {
        private readonly IPermissionRepository _repository;

        public PermissionController(IPermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public Task<bool> Delete([FromBody] DeletePermissionModel model) => _repository.DeleteAsync(model);

        [HttpGet(GET)]
        public Task<Permission> Get(int id) => _repository.GetAsync(id);

        [HttpPost]
        public Task<SavePermissionResult> Save([FromBody] SavePermissionModel model) => _repository.SaveAsync(model);

        [HttpPost(SEARCH)]
        public Task<SearchPermissionResult> Search([FromBody] SearchPermissionModel model) => _repository.SearchAsync(model);
    }
}
