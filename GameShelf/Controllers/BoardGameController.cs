using System.Collections.Generic;
using GameShelf.Models;
using GameShelf.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.Controllers
{
    public class BoardGameController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var boardGames = new List<Game>
            {
                new Game(){ Id = 1, Title = "Carcassonne" },
                new Game(){ Id = 2, Title = "Splendor" },
                new Game(){ Id = 3, Title = "Settlers of Catan"}
            };
            
            var viewModel = new BoardGameViewModel()
            {
                BoardGames = boardGames
            };
            
            return View(viewModel);
        }
    }
}