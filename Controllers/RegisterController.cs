using FreakyGame.Data;
using FreakyGame.Data.Entities;
using FreakyGame.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FreakyGame.Controllers
{
    public class RegisterController : Controller
    {
        private readonly FreakyGameContext context;

        public RegisterController(FreakyGameContext context)
        {
            this.context = context;
        }

        ////GET /products/black-tshirt
        //[Route("/products/{urlSlug}", Name = "productdetails")]
        //public ActionResult Details(string urlSlug)
        //{
        //    var product = context.Products
        //        .FirstOrDefault(product => product.UrlSlug == urlSlug);

        //    return View(product);
        //}

        // GET /products/new
        [Route("/register/highscore")]
        public ActionResult CreateScore()
        {
            // .\Views\Products\Create.cshtml
            return View();
        }

        // POST /products/new
        // name=lorem   &     description=ipsum   &    imageUrl=http://test.png   &   price=1
        [HttpPost]
        [Route("/register/highscore")]
        //public ActionResult Create(IFormCollection collection)
        public ActionResult CreateScore(CreateScoreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var highScore = new RegisterScore(
                    player: viewModel.Player,
                    date: viewModel.Date,
                    score: viewModel.Score);

                context.RegisterScores.Add(highScore);

                context.SaveChanges();
            }

            // .\Views\Products\Create.cshtml
            return View();
        }

    }
}
