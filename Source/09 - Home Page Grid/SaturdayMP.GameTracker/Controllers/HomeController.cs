using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaturdayMP.GameTracker.Models;
using SaturdayMP.GameTracker.Data;
using Microsoft.EntityFrameworkCore;
using SaturdayMP.GameTracker.ViewModels;

namespace SaturdayMP.GameTracker.Controllers
{
    public class HomeController : Controller
    {

        private GameTrackerContext _context;

        public HomeController(GameTrackerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            // Count the number of wins, loses, and ties for each player.
            var model = _context.Players
                                .Include(p => p.GamesPlayers)
                                    .ThenInclude(gp => gp.GameResultType)
                                .Select(p => new PlayerWinLoss()
                                {
                                    PlayerName = p.Name,
                                    Wins = p.GamesPlayers.Where(gp => gp.GameResultType.KeyCode == 10).Count(),
                                    Loses = p.GamesPlayers.Where(gp => gp.GameResultType.KeyCode == 11).Count(),
                                    Ties = p.GamesPlayers.Where(gp => gp.GameResultType.KeyCode == 12).Count()
                                }
                                       )
                                .ToList();

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
