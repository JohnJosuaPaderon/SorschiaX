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
    public sealed class ModuleController : ControllerBase
    {
        private readonly IModuleRepository _repository;

        public ModuleController(IModuleRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteModuleModel model) => await _repository.DeleteAsync(model);

        [HttpGet]
        public async Task<ActionResult<Module>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<SaveModuleResult>> Save([FromBody] SaveModuleModel model) => await _repository.SaveAsync(model);

        [HttpGet("search")]
        public async Task<ActionResult<SearchModuleResult>> Search([FromQuery] SearchModuleModel model) => await _repository.SearchAsync(model);
    }
}
