using SaturdayMP.GameTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace SaturdayMP.GameTracker.Data
{
    public class GameTrackerContext : DbContext
    {
        public GameTrackerContext(DbContextOptions<GameTrackerContext> options) : base(options)
        {
        }

        public DbSet<GameResultType> GameResultTypes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<SaturdayMP.GameTracker.Models.GamePlayed> GamePlayed { get; set; }
    }
}
