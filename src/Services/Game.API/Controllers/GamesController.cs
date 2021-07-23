using Microsoft.AspNetCore.Mvc;

namespace Game.WebApi.Controllers
{
    public class GamesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}