using FreakyGame.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FreakyGame.Controllers
{
    public class GameInfoController : Controller
    {
        private readonly FreakyGameContext context;

        public GameInfoController(FreakyGameContext context)
        {
            this.context = context;
        }

        // GET /products/black-tshirt
        [Route("/gameInfo/{urlSlug}", Name = "gamedetails")]
        public IActionResult Details(string urlSlug)
        {
            var gameInfo = context.Games
                .FirstOrDefault(game => game.UrlSlug == urlSlug);

            return View(gameInfo);
        }
    }
}

