using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CWitter.Data;
using CWitter.ViewModels;

namespace CWitter.Controllers
{
    public class CweetsController : Controller
    {
        private readonly CWitterContext _context;

        public CweetsController(CWitterContext context)
        {
            _context = context;
        }

        // GET: Cweets
        public async Task<IActionResult> Index()
        {
            var cweets = await _context.Cweets.ToListAsync();
            var model = new CweetListViewModel() { Cweets = cweets, Search = null };
            return View(model);
        }

        // GET: Cweets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cweet = await _context.Cweets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cweet == null)
            {
                return NotFound();
            }

            return View(cweet);
        }

        // GET: Cweets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cweets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Author,LicencePlate,Message")] Cweet cweet)
        {
            if (ModelState.IsValid)
            {
                cweet.ID = Guid.NewGuid().ToString();
                cweet.TimeStamp = DateTime.UtcNow;
                _context.Add(cweet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cweet);
        }

        // GET: Cweets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cweet = await _context.Cweets.FindAsync(id);
            if (cweet == null)
            {
                return NotFound();
            }
            return View(cweet);
        }

        [HttpGet("Cweets/Search/{number}")]
        public async Task<IActionResult> Search(string number)
        {
            var cweets = await _context.Cweets.Where(o => o.LicencePlate == number).ToListAsync();
            return View("Index", new CweetListViewModel() { Cweets = cweets, Search = number });
        }

        // POST: Cweets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,LicencePlate,Message,TimeStamp")] Cweet cweet)
        {
            if (id != cweet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cweet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CweetExists(cweet.ID))
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
            return View(cweet);
        }

        // GET: Cweets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cweet = await _context.Cweets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cweet == null)
            {
                return NotFound();
            }

            return View(cweet);
        }

        // POST: Cweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cweet = await _context.Cweets.FindAsync(id);
            _context.Cweets.Remove(cweet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CweetExists(string id)
        {
            return _context.Cweets.Any(e => e.ID == id);
        }
    }
}
