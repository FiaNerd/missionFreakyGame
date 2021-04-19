using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreakyGame.Data;

namespace FreakyGame.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HighScoresController : Controller
    {
        private readonly FreakyGameContext context;

        public HighScoresController(FreakyGameContext context)
        {
            this.context = context;
        }

        // GET: Admin/HighScores
        public async Task<IActionResult> Index()
        {
            var freakyGameContext = context.HighScores
                .Include(r => r.Game);

            return View(await freakyGameContext.ToListAsync());
        }

        // GET: Admin/HighScores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerScore = await context.HighScores
                .Include(r => r.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerScore == null)
            {
                return NotFound();
            }

            return View(registerScore);
        }
    }
}
