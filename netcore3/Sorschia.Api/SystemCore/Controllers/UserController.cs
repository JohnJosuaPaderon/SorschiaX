using Microsoft.AspNetCore.Authorization;
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
    public sealed class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete([FromBody] DeleteUserModel model) => await _repository.DeleteAsync(model);

        [HttpGet]
        public async Task<ActionResult<User>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginUserResult>> Login([FromBody] LoginUserModel model) => await _repository.LoginAsync(model);

        [HttpPost]
        public async Task<ActionResult<SaveUserResult>> Save([FromBody] SaveUserModel model) => await _repository.SaveAsync(model);

        [HttpGet("search")]
        public async Task<ActionResult<SearchUserResult>> Search([FromBody] SearchUserModel model) => await _repository.SearchAsync(model);

        [HttpPost("validateUserApplication")]
        public async Task<ActionResult<bool>> ValidateUserApplication([FromBody] ValidateUserApplicationModel model) => await _repository.ValidateUserApplicationAsync(model);

        [HttpPost("validateUserModule")]
        public async Task<ActionResult<bool>> ValidateUserModule([FromBody] ValidateUserModuleModel model) => await _repository.ValidateUserModuleAsync(model);

        [HttpPost("validateUserPermission")]
        public async Task<ActionResult<bool>> ValidateUserPermission([FromBody] ValidateUserPermissionModel model) => await _repository.ValidateUserPermissionAsync(model);
    }
}
