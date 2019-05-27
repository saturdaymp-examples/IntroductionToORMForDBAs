using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaturdayMP.GameTracker.Data;
using SaturdayMP.GameTracker.Models;

namespace SaturdayMP.GameTracker.Controllers
{
    public class GamesPlayedController : Controller
    {
        private readonly GameTrackerContext _context;

        public GamesPlayedController(GameTrackerContext context)
        {
            _context = context;
        }

        // GET: GamesPlayed
        public async Task<IActionResult> Index()
        {
            var gameTrackerContext = _context.GamePlayed.Include(g => g.Game);
            return View(await gameTrackerContext.ToListAsync());
        }

        // GET: GamesPlayed/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlayed = await _context.GamePlayed
                .Include(g => g.Game)
                .SingleOrDefaultAsync(m => m.Id == id);
            
            if (gamePlayed == null)
            {
                return NotFound();
            }

            return View(gamePlayed);
        }

        // GET: GamesPlayed/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name");
            return View();
        }

        // POST: GamesPlayed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,DatePlayed")] GamePlayed gamePlayed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamePlayed);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Edit), new { id = gamePlayed.Id });
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", gamePlayed.GameId);
            return View(gamePlayed);
        }

        // GET: GamesPlayed/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlayed = await _context.GamePlayed
                                           .Include(g => g.GamePlayers).ThenInclude(p => p.Player)
                                           .Include(g => g.GamePlayers).ThenInclude(p => p.GameResultType)
                                           .SingleOrDefaultAsync(m => m.Id == id);

            if (gamePlayed == null)
            {
                return NotFound();
            }

            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", gamePlayed.GameId);
            ViewData["Players"] = new SelectList(_context.Players, "Id", "Name");
            ViewData["GameResults"] = new SelectList(_context.GameResultTypes, "Id", "Type");

            return View(gamePlayed);
        }

        // POST: GamesPlayed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,DatePlayed")] GamePlayed gamePlayed)
        {
            if (id != gamePlayed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamePlayed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamePlayedExists(gamePlayed.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Name", gamePlayed.GameId);
            return View(gamePlayed);
        }

        // GET: GamesPlayed/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlayed = await _context.GamePlayed
                .Include(g => g.Game)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gamePlayed == null)
            {
                return NotFound();
            }

            return View(gamePlayed);
        }

        // POST: GamesPlayed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamePlayed = await _context.GamePlayed.SingleOrDefaultAsync(m => m.Id == id);
            _context.GamePlayed.Remove(gamePlayed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateGamePlayer([Bind("GamePlayedId,PlayerId,GameResultTypeId")] GamePlayer gamePlayer)
        {
            _context.Add(gamePlayer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = gamePlayer.GamePlayedId});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGamePlayer(int id)
        {
            var gamePlayer = await _context.GamePlayers.SingleOrDefaultAsync(m => m.Id == id);
            int gamePlayedId = gamePlayer.GamePlayedId;

            _context.GamePlayers.Remove(gamePlayer);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = gamePlayedId });
        }

        private bool GamePlayedExists(int id)
        {
            return _context.GamePlayed.Any(e => e.Id == id);
        }
    }
}
