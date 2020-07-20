using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController]
    [SystemCoreRoute(ControllerRoutes.SystemCore.User)]
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

        [HttpGet(ActionTemplates.Get)]
        public async Task<ActionResult<User>> Get(int id) => await _repository.GetAsync(id);

        [HttpPost(ActionTemplates.SystemCore.User.Login)]
        [AllowAnonymous]
        public async Task<ActionResult<LoginUserResult>> Login([FromBody] LoginUserModel model) => await _repository.LoginAsync(model);

        [HttpPost]
        public async Task<ActionResult<SaveUserResult>> Save([FromBody] SaveUserModel model) => await _repository.SaveAsync(model);

        [HttpGet(ActionTemplates.Search)]
        public async Task<ActionResult<SearchUserResult>> Search([FromBody] SearchUserModel model) => await _repository.SearchAsync(model);

        [HttpPost(ActionTemplates.SystemCore.User.ValidateUserApplication)]
        public async Task<ActionResult<bool>> ValidateUserApplication([FromBody] ValidateUserApplicationModel model) => await _repository.ValidateUserApplicationAsync(model);

        [HttpPost(ActionTemplates.SystemCore.User.ValidateUserModule)]
        public async Task<ActionResult<bool>> ValidateUserModule([FromBody] ValidateUserModuleModel model) => await _repository.ValidateUserModuleAsync(model);

        [HttpPost(ActionTemplates.SystemCore.User.ValidateUserPermission)]
        public async Task<ActionResult<bool>> ValidateUserPermission([FromBody] ValidateUserPermissionModel model) => await _repository.ValidateUserPermissionAsync(model);
    }
}
