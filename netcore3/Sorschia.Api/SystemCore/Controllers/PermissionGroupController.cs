using Microsoft.AspNetCore.Mvc;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController]
    [Route(ControllerRouteTemplate.SystemCore)]
    [ApiPermissionAuthorize]
    public sealed class PermissionGroupController : ControllerBase
    {
        private readonly IPermissionGroupRepository _repository;

        public PermissionGroupController(IPermissionGroupRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeletePermissionGroupModel model) => await _repository.DeleteAsync(model);

        [HttpGet]
        public async Task<ActionResult<PermissionGroup>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<SavePermissionGroupResult>> Save([FromBody] SavePermissionGroupModel model) => await _repository.SaveAsync(model);

        [HttpGet("search")]
        public async Task<ActionResult<SearchPermissionGroupResult>> Search([FromQuery] SearchPermissionGroupModel model) => await _repository.SearchAsync(model);
    }
}
