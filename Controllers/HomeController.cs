using FreakyGame.Data;
using Microsoft.AspNetCore.Mvc;
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
            var games = context.Games.ToList();

            return View(games); 
        }

    }
}
