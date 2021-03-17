using FreakyGame.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreakyGame.Data
{
    public class FreakyGameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public FreakyGameContext(DbContextOptions<FreakyGameContext> options)
            : base(options)
        {

        }
    }
}
