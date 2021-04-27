using FreakyGame.Data.Entities;
using Microsoft.EntityFrameworkCore;
using FreakyGame.Areas.API.Dto;

namespace FreakyGame.Data
{
    public class FreakyGameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<HighScore> HighScores { get; set; }


        public FreakyGameContext(DbContextOptions<FreakyGameContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FreakyGame;Trusted_Connection=True");
        }

    }
}
