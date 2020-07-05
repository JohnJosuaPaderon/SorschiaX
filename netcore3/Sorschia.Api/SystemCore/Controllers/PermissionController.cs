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
    public sealed class PermissionController : ControllerBase
    {
        private const string APIPERMISSION = "apiPermission";

        private readonly IPermissionRepository _repository;

        public PermissionController(IPermissionRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeletePermissionModel model) => await _repository.DeleteAsync(model);

        [HttpGet]
        public async Task<ActionResult<Permission>> Get(int id) => await _repository.GetAsync(id);

        [HttpGet(APIPERMISSION)]
        public async Task<ActionResult<ApiPermission>> GetApiPermission(int id) => await _repository.GetApiPermissionAsync(id);

        [HttpPost]
        public async Task<ActionResult<SavePermissionResult>> Save([FromBody] SavePermissionModel model) => await _repository.SaveAsync(model);

        [HttpPost(APIPERMISSION)]
        public async Task<ActionResult<SaveApiPermissionResult>> SaveApiPermission([FromBody] SaveApiPermissionModel model) => await _repository.SaveApiPermissionAsync(model);

        [HttpGet("search")]
        public async Task<ActionResult<SearchPermissionResult>> Search([FromQuery] SearchPermissionModel model) => await _repository.SearchAsync(model);

    }
}
