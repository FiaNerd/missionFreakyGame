using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost]
        public ActionResult<Game> PostGame(GameDto dto)
        {
            bool gameExists = context.Games
                .Any(x => x.Title == dto.Title);


            if (ModelState.IsValid && !gameExists )
            {
                var newGame = new Game(
                      title: dto.Title,
                      description: dto.Description,
                      genre: dto.Genre,
                      releaseYear: dto.ReleaseYear,
                      imageUrl: dto.ImageUrl
                  );

                context.Games.Add(newGame);

                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetGames), new { id = dto.Id }, dto);
        }


        //DELETE: api/Games/5
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
    }
}
