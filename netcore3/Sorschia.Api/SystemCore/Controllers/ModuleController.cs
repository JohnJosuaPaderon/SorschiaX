using Microsoft.AspNetCore.Mvc;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController]
    [SystemCoreRoute(ControllerRoutes.SystemCore.Module)]
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

        [HttpGet(ActionTemplates.Get)]
        public async Task<ActionResult<Module>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<SaveModuleResult>> Save([FromBody] SaveModuleModel model) => await _repository.SaveAsync(model);

        [HttpPost(ActionTemplates.Search)]
        public async Task<ActionResult<SearchModuleResult>> Search([FromBody] SearchModuleModel model) => await _repository.SearchAsync(model);
    }
}
