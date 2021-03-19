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
            var allGamesFromDB = context.RegisterScores
                .Include(x => x.Games)
                .ToList();

            return View(allGamesFromDB);
        }

        public IActionResult Details(int id)
        {
            var allGamesFromDB = context.RegisterScores
                .Include(x => x.Games)
                .FirstOrDefault(x => x.Id == id);

            return View(allGamesFromDB);
        }
    }
}
