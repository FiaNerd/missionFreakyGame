using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FreakyGame.Data;
using FreakyGame.Data.Entities;
using FreakyGame.Areas.API.Dto;

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

        // GET: api/Games
        [HttpGet]
        public IEnumerable<HighScoreDto> GetHighScores()
        {
            var highScores = context.HighScores.ToList();

            var dtoScore = highScores.Select(HighScoresToDto);

            return dtoScore;
        }

        public HighScoreDto HighScoresToDto(HighScore highScore)
           => new HighScoreDto
           {
               Id = highScore.Id,
               GameId = highScore.GameId,
               Player = highScore.Player,
               Date = highScore.Date,
               Score = highScore.Score,
           };

        // GET: api/Games/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HighScore>> GetHighScoreId(int id)
        {
            var highScore = await context.HighScores.FindAsync(id);

            if (highScore == null)
            {
                return NotFound();
            }

            return highScore;
        }

        // PUT: api/HighScores/5
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
        [HttpPost]
        public ActionResult<HighScore> PostHighScore(HighScoreDto highScoreDto)
        {
            if (ModelState.IsValid)
            {
                var newHighScore = new HighScore(
                      highScoreDto.GameId,
                      highScoreDto.Player,
                      highScoreDto.Date,
                      highScoreDto.Score
                  );

                context.HighScores.Add(newHighScore);

                context.SaveChangesAsync();
            }
            return CreatedAtAction("GetHighScore", new { id = highScoreDto.Id }, highScoreDto);
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
