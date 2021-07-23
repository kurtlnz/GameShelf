using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Game.API.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("secureping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult SecurePing() => Ok();

        [HttpGet("/")]
        public ActionResult<string> Get()
        {
            _logger.LogInformation("Requesting Build Version {0} in route: {1}", _configuration["BUILD_VERSION"], HttpContext.Request.Path);
            return Ok($"Version: {_configuration["BUILD_VERSION"]}");
        }
    }
}