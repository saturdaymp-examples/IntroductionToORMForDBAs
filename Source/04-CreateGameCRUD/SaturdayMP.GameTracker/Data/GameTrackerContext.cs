using SaturdayMP.GameTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace SaturdayMP.GameTracker.Data
{
    public class GameTrackerContext : DbContext
    {
        public GameTrackerContext(DbContextOptions<GameTrackerContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
