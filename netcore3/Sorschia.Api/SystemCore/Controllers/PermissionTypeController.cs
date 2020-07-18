using Microsoft.AspNetCore.Mvc;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController]
    [Route(ControllerRoutes.SystemCore.PermissionType)]
    [ApiPermissionAuthorize]
    public sealed class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeRepository _repository;

        public PermissionTypeController(IPermissionTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeletePermissionTypeModel model) => await _repository.DeleteAsync(model);

        [HttpGet]
        public async Task<ActionResult<PermissionType>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost]
        public async Task<ActionResult<SavePermissionTypeResult>> Save([FromBody] SavePermissionTypeModel model) => await _repository.SaveAsync(model);

        [HttpGet(ActionTemplates.Search)]
        public async Task<ActionResult<SearchPermissionTypeResult>> Search([FromQuery] SearchPermissionTypeModel model) => await _repository.SearchAsync(model);
    }
}
