using Microsoft.AspNetCore.Mvc;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController]
    [Route(ControllerRoutes.SystemCore.Application)]
    [ApiPermissionAuthorize]
    public sealed class ApplicationController : ControllerBase
    {
        private readonly IApplicationRepository _repository;

        public ApplicationController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteApplicationModel model) => await _repository.DeleteAsync(model);

        [HttpGet(ActionTemplates.Get)]
        public async Task<ActionResult<Application>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<SaveApplicationResult>> Save([FromBody] SaveApplicationModel model) => await _repository.SaveAsync(model);

        [HttpGet(ActionTemplates.Search)]
        public async Task<ActionResult<SearchApplicationResult>> Search([FromQuery] SearchApplicationModel model) => await _repository.SearchAsync(model);
    }
}
