using System.ComponentModel.DataAnnotations.Schema;

namespace SaturdayMP.GameTracker.Models
{
    [Table("GamePlayers")]
    public class GamePlayer
    {
        public int Id { get; set; }

        public int GamePlayedId { get; set; }
        public GamePlayed GamePlayed { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int GameResultTypeId { get; set; }
        public GameResultType GameResultType { get; set; }
    }
}
