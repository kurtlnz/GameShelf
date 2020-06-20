using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameShelf.Domain;
using GameShelf.Domain.Models;
using GameShelf.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.API.Controllers
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
        [Route("AddGame")]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            var games = await _gameService.AddGame(game);

            if (games == null)
            {
                return NotFound();
            }
            
            return games;
        }
        
        [HttpGet]
        [Route("GetGames")]
        public async Task<ActionResult<List<Game>>> GetGames()
        {
            var games = await _gameService.GetGames();

            if (games == null)
            {
                return NotFound();
            }
            
            return games;
        }
    }
}