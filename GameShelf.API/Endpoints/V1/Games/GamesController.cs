using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Dtos;
using GameShelf.Domain.Services.Game;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.API.Endpoints.V1.Games
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService; 
        private readonly DataContext _db;

        public GamesController(DataContext db,
            IGameService gameService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(GameService));
            _db = db ?? throw new ArgumentNullException(nameof(DataContext));
        }
        
        // GET: /games
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Domain.Models.Game>>> GetGames()
        {
            var result = await _gameService.GetGamesAsync();
            
            return Ok(result);
        }
        
        // GET: /games/{id}
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult<Domain.Models.Game>> GetGames(Guid id)
        {
            var result = await _gameService.GetGameAsync(id);
            
            return Ok(result);
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
            
            await _gameService.CreateGameAsync(dto);
            
            return Ok();
        }
        
        // PUT: /games/{id}
        [HttpPut]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateGame(UpdateGame dto)
        {
            await _gameService.UpdateGameAsync(dto);

            return Ok();
        }

        // DELETE: /games/{id}
        [HttpDelete]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            await _gameService.DeleteGameAsync(id);
            
            return Ok();
        }

    }
}