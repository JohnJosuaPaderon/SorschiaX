using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Sorschia.Controllers
{
    [ApiController]
    public sealed class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (feature.Error is SorschiaException sorschiaException && sorschiaException.IsMessageViewable)
            {
                return Problem(feature.Error.Message, type: ApiConstants.CustomErrorContentType);
            }
            else
            {
                return Problem();
            }
        }
    }
}
