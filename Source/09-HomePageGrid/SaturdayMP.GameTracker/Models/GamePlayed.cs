using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaturdayMP.GameTracker.Models
{
    [Table("GamesPlayed")]
    public class GamePlayed
    {
        public GamePlayed()
        {
            GamePlayers = new List<GamePlayer>();
        }

        public int Id { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public DateTime DatePlayed { get; set; }

        public ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
