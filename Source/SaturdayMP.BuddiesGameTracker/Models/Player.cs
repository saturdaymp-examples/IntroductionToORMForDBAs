using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaturdayMP.BuddiesGameTracker.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
