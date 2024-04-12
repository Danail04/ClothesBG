using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClothesBG.Data;

namespace ClothesBG.Controllers
{
    public class GirlsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GirlsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Girls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Girl.ToListAsync());
        }

        // GET: Girls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var girl = await _context.Girl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (girl == null)
            {
                return NotFound();
            }

            return View(girl);
        }

        // GET: Girls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Girls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Name,Price,ImageUrl")] Girl girl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(girl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(girl);
        }

        // GET: Girls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var girl = await _context.Girl.FindAsync(id);
            if (girl == null)
            {
                return NotFound();
            }
            return View(girl);
        }

        // POST: Girls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Name,Price,ImageUrl")] Girl girl)
        {
            if (id != girl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(girl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GirlExists(girl.Id))
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
            return View(girl);
        }

        // GET: Girls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var girl = await _context.Girl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (girl == null)
            {
                return NotFound();
            }

            return View(girl);
        }

        // POST: Girls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var girl = await _context.Girl.FindAsync(id);
            if (girl != null)
            {
                _context.Girl.Remove(girl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GirlExists(int id)
        {
            return _context.Girl.Any(e => e.Id == id);
        }
    }
}
