using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using kuliah.Data;
using kuliah.Models;

namespace kuliah.Controllers
{
    public class MarakuliahsController : Controller
    {
        private readonly kuliahContext _context;

        public MarakuliahsController(kuliahContext context)
        {
            _context = context;
        }

        // GET: Marakuliahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marakuliah.ToListAsync());
        }

        // GET: Marakuliahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marakuliah = await _context.Marakuliah
                .FirstOrDefaultAsync(m => m.Kode_MK == id);
            if (marakuliah == null)
            {
                return NotFound();
            }

            return View(marakuliah);
        }

        // GET: Marakuliahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marakuliahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kode_MK,Nama_MK,Sks")] Marakuliah marakuliah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marakuliah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marakuliah);
        }

        // GET: Marakuliahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marakuliah = await _context.Marakuliah.FindAsync(id);
            if (marakuliah == null)
            {
                return NotFound();
            }
            return View(marakuliah);
        }

        // POST: Marakuliahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kode_MK,Nama_MK,Sks")] Marakuliah marakuliah)
        {
            if (id != marakuliah.Kode_MK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marakuliah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarakuliahExists(marakuliah.Kode_MK))
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
            return View(marakuliah);
        }

        // GET: Marakuliahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marakuliah = await _context.Marakuliah
                .FirstOrDefaultAsync(m => m.Kode_MK == id);
            if (marakuliah == null)
            {
                return NotFound();
            }

            return View(marakuliah);
        }

        // POST: Marakuliahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marakuliah = await _context.Marakuliah.FindAsync(id);
            if (marakuliah != null)
            {
                _context.Marakuliah.Remove(marakuliah);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarakuliahExists(int id)
        {
            return _context.Marakuliah.Any(e => e.Kode_MK == id);
        }
    }
}
