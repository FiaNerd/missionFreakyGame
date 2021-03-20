using FreakyGame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("/gameinfo/{urlSlug}", Name = "gamedetails")]
        public IActionResult Detail(string urlSlug)
        {
            var gameInfo = context.Games
                .FirstOrDefault(game => game.UrlSlug == urlSlug);

            gameInfo.AllGameScores = context.RegisterScores
                .Where(score => score.GameId == gameInfo.Id)
                .ToList();
                

            if (gameInfo == null)
            {
                return NotFound();
            }

            return View(gameInfo);
        }


        public IActionResult GetAllDetail(int id)
        {
            var getDetails = context.RegisterScores
                .Include(x => x.Game)
                .Where(x => x.Id == id)
                .ToList();

            return View(getDetails);
        }
    }
}

