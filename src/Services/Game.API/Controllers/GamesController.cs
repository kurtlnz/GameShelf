using System;
using System.Threading.Tasks;
using Game.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Game.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameService.GetAllGames();
            return Ok(result);
        }
    }
}