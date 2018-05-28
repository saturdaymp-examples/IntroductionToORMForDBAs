using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SaturdayMP.GameTracker.Models
{
    public class Game
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<GamePlayed> GamesPlayed { get; set; }
    }
}
