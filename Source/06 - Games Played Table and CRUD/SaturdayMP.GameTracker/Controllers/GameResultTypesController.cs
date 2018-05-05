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
    public class GameResultTypesController : Controller
    {
        private readonly GameTrackerContext _context;

        public GameResultTypesController(GameTrackerContext context)
        {
            _context = context;
        }

        // GET: GameResultTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameResultTypes.ToListAsync());
        }

        // GET: GameResultTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameResultType = await _context.GameResultTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gameResultType == null)
            {
                return NotFound();
            }

            return View(gameResultType);
        }

        // GET: GameResultTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameResultType = await _context.GameResultTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (gameResultType == null)
            {
                return NotFound();
            }
            return View(gameResultType);
        }

        // POST: GameResultTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KeyCode,Type")] GameResultType gameResultType)
        {
            if (id != gameResultType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameResultType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameResultTypeExists(gameResultType.Id))
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
            return View(gameResultType);
        }

        private bool GameResultTypeExists(int id)
        {
            return _context.GameResultTypes.Any(e => e.Id == id);
        }
    }
}
