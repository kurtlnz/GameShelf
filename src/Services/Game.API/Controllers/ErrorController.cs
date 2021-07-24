using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Game.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("error")]
    public sealed class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            switch (exception)
            {
                default:
                    _logger.LogError(exception, $"Unhandled exception ({exception.GetType().FullName}) was raised");
                    return Problem(exception.Message);
            }
        }
    }
}