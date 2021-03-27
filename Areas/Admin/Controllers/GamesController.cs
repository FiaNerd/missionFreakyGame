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

        // GET: Admin/Games
        public async Task<IActionResult> Index()
        {
            //.\Areas\Admin\Views\Games\Index.cshtml
            return View(await context.Games
                .ToListAsync());
        }

        // GET: Admin/Games/Details/5
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

        // GET: Games/Create
        //[Route("/admin/games")]
        public IActionResult Create()
        {
            // .\Areas\Admin\Views\Games\Create.cshtml
            return View();
        }


        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Route("/admin/games")]
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

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Genre,ReleaseYear,ImageUrl,UrlSlug")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(game);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            return View(game);
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
