using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.UserModule)]
    public class UserModuleController : SorschiaControllerBase
    {
        private readonly IUserModuleRepository _repository;

        public UserModuleController(IUserModuleRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(SEARCH)]
        public Task<SearchUserModuleResult> Search([FromBody] SearchUserModuleModel model) => _repository.SearchAsync(model);
    }
}
