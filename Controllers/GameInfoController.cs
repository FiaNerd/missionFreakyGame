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

        public IActionResult GameInfo()
        {
            var games = context.Games.ToList();

            return View(games);
        }
    }
}

