using System.ComponentModel.DataAnnotations;

namespace SaturdayMP.GameTracker.Models
{
    public class Player
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
