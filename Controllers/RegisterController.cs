using FreakyGame.Data;
using FreakyGame.Data.Entities;
using FreakyGame.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyGame.Controllers
{
    public class RegisterController : Controller
    {
        private readonly FreakyGameContext context;


        public RegisterController(FreakyGameContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var highScore = context.RegisterScores
                .ToList();

            return View(highScore);
        }
        // GET: Highscores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await context.RegisterScores
                .FirstOrDefaultAsync(m => m.Id == id);

            if (highscore == null)
            {
                return NotFound();
            }

            return View(highscore);
        }


        // GET /products/new
        [Route("/register/new")]
        public ActionResult CreateScore()
        {
            //ViewBag.select = new SelectList(context.Games.ToList(), "Id", "Title");

            var listScore = new CreateScoreViewModel();
            listScore.ListScores = context.Games
                .Select(a => new SelectListItem()
                {
                    Value = a.Id.ToString(),
                    Text = a.Title
                })
                .ToList();

            return View(listScore);
        }

        // POST /products/new
        // name=lorem   &     description=ipsum   &    imageUrl=http://test.png   &   price=1
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/register/new")]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult CreateScore(CreateScoreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newHighScore = new RegisterScore(
                    player: viewModel.Player,
                    date: viewModel.Date,
                    score: viewModel.Score,
                    gameId: viewModel.GameId);

                context.RegisterScores.Add(newHighScore);


                context.SaveChanges();
            }

            // .\Views\Products\Create.cshtml
            return RedirectToAction("Index", "Home");

        }
        //return View(viewModel);

    }
}

