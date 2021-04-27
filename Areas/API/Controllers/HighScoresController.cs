using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreakyGame.Data;
using FreakyGame.Data.Entities;
using FreakyGame.Areas.API.Dto;
using Microsoft.EntityFrameworkCore;

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
            var highScores = context.HighScores
                .Include(x => x.Game)
                .ToList();

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
               GTitle = highScore.GTitle
           };

        // GET: api/Games/5
        [HttpGet("{id:int}")]
        public ActionResult<HighScore> GetHighScoreId(int id)
        {
            var highScore = context.HighScores
                .Include(x => x.Game)
                .FirstOrDefault(x => x.Id == id);

            if (highScore == null)
            {
                return NotFound();
            }

            return highScore;
        }

        // POST: api/HighScores
        [HttpPost]
        public ActionResult<HighScore> PostHighScore(HighScoreDto dto)
        {
            var game = context.Games
           .Include(x => x.AllGameScores)
           .FirstOrDefault(x => x.Title == dto.GTitle);

            if (ModelState.IsValid)
            {
                //foreach (var item in dto.ListOfGames)
                //{
                    if (game == null)
                    {
                        return NotFound();
                    }
                //}
                var newHighScore = new HighScore(
                      gameId: game.Id,
                      player: dto.Player,
                      date: dto.Date,
                      score: dto.Score,
                      gTitle: dto.GTitle
                  );

                context.HighScores.Add(newHighScore);

                context.SaveChanges();
            }


            return CreatedAtAction("GetHighScore", new { id = dto.Id }, dto);
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

        //private bool HighScoreExists(int id)
        //{
        //    return context.HighScores.Any(e => e.Id == id);
        //}
    }
}
