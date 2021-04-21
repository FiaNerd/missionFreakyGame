using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreakyGame.Data;
using FreakyGame.Data.Entities;

namespace FreakyGame.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoresController : ControllerBase
    {
        private readonly FreakyGameContext context;

        public HighScoresController(FreakyGameContext context)
        {
            this.context = context;
        }

        // GET: api/HighScores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HighScore>>> GetHighScores()
        {
            return await context.HighScores.ToListAsync();
        }

        // GET: api/HighScores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HighScore>> GetHighScore(int id)
        {
            var highScore = await context.HighScores.FindAsync(id);

            if (highScore == null)
            {
                return NotFound();
            }

            return highScore;
        }

        // PUT: api/HighScores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighScore(int id, HighScore highScore)
        {
            if (id != highScore.Id)
            {
                return BadRequest();
            }

            context.Entry(highScore).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighScoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HighScores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HighScore>> PostHighScore(HighScore highScore)
        {
            context.HighScores.Add(highScore);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetHighScore", new { id = highScore.Id }, highScore);
        }

        // DELETE: api/HighScores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHighScore(int id)
        {
            var highScore = await context.HighScores.FindAsync(id);
            if (highScore == null)
            {
                return NotFound();
            }

            context.HighScores.Remove(highScore);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool HighScoreExists(int id)
        {
            return context.HighScores.Any(e => e.Id == id);
        }
    }
}
