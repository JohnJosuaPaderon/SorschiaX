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
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.Application)]
    public class ApplicationController : SorschiaControllerBase
    {
        private readonly IApplicationRepository _repository;

        public ApplicationController(IApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public Task<bool> Delete([FromBody] DeleteApplicationModel model) => _repository.DeleteAsync(model);

        [HttpGet(GET)]
        public Task<Application> Get(int id) => _repository.GetAsync(id);

        [HttpPost]
        public Task<SaveApplicationResult> Save([FromBody] SaveApplicationModel model) => _repository.SaveAsync(model);

        [HttpPost(SEARCH)]
        public Task<SearchApplicationResult> Search([FromBody] SearchApplicationModel model) => _repository.SearchAsync(model);
    }
}
