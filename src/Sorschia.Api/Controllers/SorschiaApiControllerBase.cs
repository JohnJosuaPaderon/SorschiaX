using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Api.Controllers
{
    public abstract class SorschiaApiControllerBase : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator
        {
            get
            {
                if (_mediator is null)
                    _mediator = HttpContext.RequestServices.GetService<IMediator>();

                return _mediator;
            }
        }
    }
}
