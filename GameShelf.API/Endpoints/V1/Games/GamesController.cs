using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain.Dtos;
using GameShelf.Domain.Services.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameShelf.API.Endpoints.V1.Games
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GamesController> _logger;

        public GamesController(IGameService gameService, ILogger<GamesController> logger)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(GameService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        // GET: /games
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Domain.Models.Game>>> GetGames()
        {
            try
            {
                var result = await _gameService.GetGamesAsync();

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }
        
        // GET: /games/{id}
        [HttpGet("{id}")]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<Domain.Models.Game>> GetGame(Guid id)
        {
            try
            {
                var result = await _gameService.GetGameAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }
        
        // POST: /games
        [HttpPost]
        [ProducesResponseType( StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGame(CreateGame dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _gameService.CreateGameAsync(dto);
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }
        
        // PUT: /games/{id}
        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateGame(UpdateGame dto)
        {
            try
            {
                await _gameService.UpdateGameAsync(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }

        // DELETE: /games/{id}
        [HttpDelete]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            try
            {
                await _gameService.DeleteGameAsync(id);
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                
                return StatusCode(500);
            }
        }

    }
}