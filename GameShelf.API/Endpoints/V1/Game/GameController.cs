using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Services.Game;
using GameShelf.Domain.Services.Game.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.API.Endpoints.V1.Game
{
    [ApiController]
    [Route("v1/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService; 
        private readonly DataContext _db;

        public GameController(DataContext db,
            IGameService gameService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(GameService));
            _db = db ?? throw new ArgumentNullException(nameof(DataContext));
        }
        
        [HttpPost]
        [Route("CreateGame")]
        public async Task<IActionResult> CreateGame(CreateRequest req)
        {
            var dto = new CreateGame()
            {
                Title = req.Title,
                Year = req.Year
            };
            
            await _gameService.CreateGame(dto);
            
            return Ok();
        }
        
        [HttpGet]
        [Route("GetGames")]
        public async Task<ActionResult<List<Domain.Models.Game>>> GetGames()
        {
            return await _gameService.GetGames();
        }


        [HttpPost]
        [Route("UpdateGame")]
        public async Task<V1Response> DeleteGame(int id)
        {
            var (success, message) = await _gameService.DeleteGame(id);

            return new V1Response(success, message);
        }

        [HttpPost]
        [Route("DeleteGame")]
        public async Task<V1Response> UpdateGame(UpdateRequest req)
        {
            var dto = new UpdateGame()
            {
                Id = req.Id,
                Title = req.Title,
                Year = req.Year
            };

            var (success, message) = await _gameService.UpdateGame(dto);

            return new V1Response(success, message);
        }
    }
}