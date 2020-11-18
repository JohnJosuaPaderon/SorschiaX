using Microsoft.AspNetCore.Mvc;
using Sorschia.Authorization;
using Sorschia.Controllers;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Repositories;
using Sorschia.SystemCore.Routing;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Controllers
{
    [ApiController, ApiPermissionAuthorize, SystemCoreRoute(ControllerRoutes.UserApplication)]
    public class UserApplicationController : SorschiaControllerBase
    {
        private readonly IUserApplicationRepository _repository;

        public UserApplicationController(IUserApplicationRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(SEARCH)]
        public Task<SearchUserApplicationResult> Search([FromBody] SearchUserApplicationModel model) => _repository.SearchAsync(model);
    }
}
