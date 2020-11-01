using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameShelf.Domain.Dtos;
using GameShelf.Domain.Models;
using GameShelf.Services.Game;
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
        private readonly IMapper _mapper;

        public GamesController(IGameService gameService, ILogger<GamesController> logger, IMapper mapper)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(GameService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        // GET: /games
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult> GetGames()
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
        public async Task<ActionResult> GetGame(Guid id)
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
                var game = _mapper.Map<Game>(dto);
                
                var result = await _gameService.CreateGameAsync(game);
                
                return Ok(result);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var game = _mapper.Map<Game>(dto);
                
                var result = await _gameService.UpdateGameAsync(game);

                return Ok(result);
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