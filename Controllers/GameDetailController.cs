using FreakyGame.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FreakyGame.Controllers
{
    public class GameDetailController : Controller
    {
        private readonly FreakyGameContext context;

        public GameDetailController(FreakyGameContext context)
        {
            this.context = context;
        }

        // GET /products/black-tshirt
        [Route("/gamedetails/{urlSlug}", Name = "gamedetails")]
        public IActionResult Detail(string urlSlug)
        {
            var gameInfo = context.Games
                .FirstOrDefault(game => game.UrlSlug == urlSlug);

            gameInfo.AllGameScores = context.RegisterScores
                .Where(score => score.GameId == gameInfo.Id)
                .Include(x => x.Game)
                .ToList();

            gameInfo.AllGameScores =
                (from scoreList in gameInfo.AllGameScores orderby scoreList.Score descending select scoreList)
                .Take(10)
                .ToList();

            if (gameInfo == null)
            {
                return NotFound();
            }

            return View(gameInfo);
        }
    }
}

