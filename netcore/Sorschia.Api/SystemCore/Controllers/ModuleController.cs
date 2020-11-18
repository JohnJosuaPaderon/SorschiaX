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
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.Module)]
    public class ModuleController : SorschiaControllerBase
    {
        private readonly IModuleRepository _repository;

        public ModuleController(IModuleRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public Task<bool> Delete([FromBody] DeleteModuleModel model) => _repository.DeleteAsync(model);

        [HttpGet(GET)]
        public Task<Module> Get(int id) => _repository.GetAsync(id);

        [HttpPost]
        public Task<SaveModuleResult> Save([FromBody] SaveModuleModel model) => _repository.SaveAsync(model);

        [HttpPost(SEARCH)]
        public Task<SearchModuleResult> Search([FromBody] SearchModuleModel model) => _repository.SearchAsync(model);
    }
}
