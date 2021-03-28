using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreakyGame.Data;
using FreakyGame.Data.Entities;
using FreakyGame.Areas.Admin.Models.ViewModels;

namespace FreakyGame.Area.Admin.Controllers
{
    [Area("Admin")]
    public class GamesController : Controller
    {
        private readonly FreakyGameContext context;

        public GamesController(FreakyGameContext context)
        {
            this.context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await context.Games
                .ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await context.Games
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var newGame = new Game(
                    viewModel.Title,
                    viewModel.Description,
                    viewModel.ReleaseYear,
                    viewModel.ImageUrl);

                context.Add(newGame);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        ////POST: Games/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateGameViewModel viewModel)

        {
            var game = context.Games.FirstOrDefault(x => x.Id == id);

            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var updateGame = new Game(
                           game.Title = viewModel.Title,
                           game.Description = viewModel.Description,
                           game.ReleaseYear = viewModel.ReleaseYear,
                           game.ImageUrl = viewModel.ImageUrl);

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }


        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var game = await context.Games
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (game == null)
                {
                    return NotFound();
                }

                return View(game);
            }

            // POST: Games/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var game = await context.Games.FindAsync(id);
                context.Games.Remove(game);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool GameExists(int id)
            {
                return context.Games.Any(e => e.Id == id);
            }
        }
    }
