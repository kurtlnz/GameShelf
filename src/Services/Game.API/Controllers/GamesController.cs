using System;
using System.Net;
using System.Threading.Tasks;
using Game.API.Services;
using Microsoft.AspNetCore.Http;
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

        // GET /games
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameService.GetAllGamesAsync();
            return Ok(result);
        }

        // GET /games/id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _gameService.GetGameByIdAsync(id);
            return Ok(result);
        }

        // POST /games
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create()
        {
            var result = await _gameService.CreateGameAsync();
            return Ok(result);
        }

        // PUT /games/id
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _gameService.UpdateGameAsync();
            return Ok(result);
        }

        // DELETE /games/id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _gameService.DeleteGameAsync(id);
            return Ok();
        }
    }
}