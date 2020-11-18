using Microsoft.AspNetCore.Mvc;

namespace Sorschia.Controllers
{
    public abstract class SorschiaControllerBase : ControllerBase
    {
        protected const string GET = "{id}";
        protected const string SEARCH = "search";
    }
}
