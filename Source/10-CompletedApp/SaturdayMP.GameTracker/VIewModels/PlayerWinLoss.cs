using System;
namespace SaturdayMP.GameTracker.ViewModels
{
    public class PlayerWinLoss
    {
        public string PlayerName { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int Ties { get; set; }
    }
}
