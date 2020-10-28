using Microsoft.AspNetCore.Mvc;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController]
    [SystemCoreRoute(ControllerRoutes.SystemCore.Platform)]
    [ApiPermissionAuthorize]
    public sealed class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repository;

        public PlatformController(IPlatformRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeletePlatformModel model) => await _repository.DeleteAsync(model);

        [HttpGet(ActionTemplates.Get)]
        public async Task<ActionResult<Platform>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<SavePlatformResult>> Save([FromBody] SavePlatformModel model) => await _repository.SaveAsync(model);

        [HttpPost(ActionTemplates.Search)]
        public async Task<ActionResult<SearchPlatformResult>> Search([FromBody] SearchPlatformModel model) => await _repository.SearchAsync(model);
    }
}
