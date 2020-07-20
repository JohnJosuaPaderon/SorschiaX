using Microsoft.AspNetCore.Mvc;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController]
    [SystemCoreRoute(ControllerRoutes.SystemCore.Permission)]
    [ApiPermissionAuthorize]
    public sealed class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _repository;

        public PermissionController(IPermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeletePermissionModel model) => await _repository.DeleteAsync(model);

        [HttpGet(ActionTemplates.Get)]
        public async Task<ActionResult<Permission>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<SavePermissionResult>> Save([FromBody] SavePermissionModel model) => await _repository.SaveAsync(model);

        [HttpGet(ActionTemplates.Search)]
        public async Task<ActionResult<SearchPermissionResult>> Search([FromQuery] SearchPermissionModel model) => await _repository.SearchAsync(model);
    }
}
