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
    public class DosensController : Controller
    {
        private readonly kuliahContext _context;

        public DosensController(kuliahContext context)
        {
            _context = context;
        }

        // GET: Dosens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dosen.ToListAsync());
        }

        // GET: Dosens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosen = await _context.Dosen
                .FirstOrDefaultAsync(m => m.Nip == id);
            if (dosen == null)
            {
                return NotFound();
            }

            return View(dosen);
        }

        // GET: Dosens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dosens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nip,Nama_Dosen")] Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dosen);
        }

        // GET: Dosens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosen = await _context.Dosen.FindAsync(id);
            if (dosen == null)
            {
                return NotFound();
            }
            return View(dosen);
        }

        // POST: Dosens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nip,Nama_Dosen")] Dosen dosen)
        {
            if (id != dosen.Nip)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dosen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DosenExists(dosen.Nip))
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
            return View(dosen);
        }

        // GET: Dosens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dosen = await _context.Dosen
                .FirstOrDefaultAsync(m => m.Nip == id);
            if (dosen == null)
            {
                return NotFound();
            }

            return View(dosen);
        }

        // POST: Dosens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosen = await _context.Dosen.FindAsync(id);
            if (dosen != null)
            {
                _context.Dosen.Remove(dosen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DosenExists(int id)
        {
            return _context.Dosen.Any(e => e.Nip == id);
        }
    }
}
