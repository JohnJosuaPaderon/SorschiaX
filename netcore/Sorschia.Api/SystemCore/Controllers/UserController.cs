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
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.User)]
    public class UserController : SorschiaControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete]
        public Task<bool> Delete([FromBody] DeleteUserModel model) => _repository.DeleteAsync(model);

        [HttpGet(GET)]
        public Task<User> Get(int id) => _repository.GetAsync(id);

        [HttpPost]
        public Task<SaveUserResult> Save([FromBody] SaveUserModel model) => _repository.SaveAsync(model);

        [HttpPost(SEARCH)]
        public Task<SearchUserResult> Search([FromBody] SearchUserModel model) => _repository.SearchAsync(model);
    }
}
