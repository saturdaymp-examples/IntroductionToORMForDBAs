using System.ComponentModel.DataAnnotations;

namespace SaturdayMP.GameTracker.Models
{
    public class Game
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
