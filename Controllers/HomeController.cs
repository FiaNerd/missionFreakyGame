using FreakyGame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FreakyGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly FreakyGameContext context;

        public HomeController(FreakyGameContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var allGamesFromDB = context.Games
                .Include(x => x.AllGameScores)
                .ToList();


            foreach (var game in allGamesFromDB)
            {
                game.AllGameScores
                    .OrderByDescending(x => x.Score)
                    .Max(x => x.Score);

            }

            return View(allGamesFromDB);
        }

        public IActionResult Detail(int id)
        {
            var allGamesFromDB = context.Games
                .Include(x => x.AllGameScores)
                .FirstOrDefault(x => x.Id == id);
                

            return View(allGamesFromDB);
        }
    }
}
