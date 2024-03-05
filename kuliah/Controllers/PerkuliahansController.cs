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
    public class PerkuliahansController : Controller
    {
        private readonly kuliahContext _context;

        public PerkuliahansController(kuliahContext context)
        {
            _context = context;
        }

        // GET: Perkuliahans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perkuliahan.ToListAsync());
        }

        // GET: Perkuliahans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perkuliahan = await _context.Perkuliahan
                .FirstOrDefaultAsync(m => m.Nim == id);
            if (perkuliahan == null)
            {
                return NotFound();
            }

            return View(perkuliahan);
        }

        // GET: Perkuliahans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perkuliahans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nim,Kode_MK,Nip,Nilai")] Perkuliahan perkuliahan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perkuliahan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perkuliahan);
        }

        // GET: Perkuliahans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perkuliahan = await _context.Perkuliahan.FindAsync(id);
            if (perkuliahan == null)
            {
                return NotFound();
            }
            return View(perkuliahan);
        }

        // POST: Perkuliahans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nim,Kode_MK,Nip,Nilai")] Perkuliahan perkuliahan)
        {
            if (id != perkuliahan.Nim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perkuliahan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerkuliahanExists(perkuliahan.Nim))
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
            return View(perkuliahan);
        }

        // GET: Perkuliahans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perkuliahan = await _context.Perkuliahan
                .FirstOrDefaultAsync(m => m.Nim == id);
            if (perkuliahan == null)
            {
                return NotFound();
            }

            return View(perkuliahan);
        }

        // POST: Perkuliahans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perkuliahan = await _context.Perkuliahan.FindAsync(id);
            if (perkuliahan != null)
            {
                _context.Perkuliahan.Remove(perkuliahan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerkuliahanExists(int id)
        {
            return _context.Perkuliahan.Any(e => e.Nim == id);
        }
    }
}
