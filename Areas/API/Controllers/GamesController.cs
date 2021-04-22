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
    public class GamesController : ControllerBase
    {
        private readonly FreakyGameContext context;

        public GamesController(FreakyGameContext context)
        {
            this.context = context;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<GameDto> GetGames()
        {
            var games = context.Games.ToList();

            var dtoGame = games.Select(GamesToDto);

            return dtoGame;
        }

        public GameDto GamesToDto(Game games)
           => new GameDto
           {
               Id = games.Id,
               Title = games.Title,
               Description = games.Description,
               ReleaseYear = games.ReleaseYear,
               Genre = games.Genre,
               ImageUrl = games.ImageUrl,
           };

        // GET: api/Games/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Game>> GetGameId(int id)
        {
            var game = await context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutGame(int id, GameDto game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            context.Entry(game).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        [HttpPost]
        public ActionResult<Game> PostGame(GameDto dto)
        {
            //if (ModelState.IsValid)
            //{
            var newGame = new Game(
               //id: dto.Id,
               dto.Title,
               dto.Description,
               dto.ReleaseYear,
               dto.Genre,
               dto.ImageUrl);

            context.Games.Add(newGame);

            context.SaveChanges();

            return CreatedAtAction("GetGame", new { id = dto.Id }, dto);
            //}

        }
        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //public async Task<ActionResult<GameDto>> PostGame(Game game)
        //{
        //    context.Games.Add(game);
        //    await context.SaveChangesAsync();

        //    return CreatedAtAction("GetGame", new { id = game.Id }, game);
        //}

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            context.Games.Remove(game);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return context.Games.Any(e => e.Id == id);
        }
    }
}
