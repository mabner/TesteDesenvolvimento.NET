using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocaFacil;
using LocaFacil.Models;

namespace LocaFacil.Controllers
{
    public class UfsController : Controller
    {
        private readonly LocaFacilContext _context;

        public UfsController(LocaFacilContext context)
        {
            _context = context;
        }

        // GET: Ufs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uf.ToListAsync());
        }

        // GET: Ufs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uf = await _context.Uf
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uf == null)
            {
                return NotFound();
            }

            return View(uf);
        }

        // GET: Ufs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ufs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sigla,Nome")] Uf uf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uf);
        }

        // GET: Ufs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uf = await _context.Uf.FindAsync(id);
            if (uf == null)
            {
                return NotFound();
            }
            return View(uf);
        }

        // POST: Ufs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sigla,Nome")] Uf uf)
        {
            if (id != uf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UfExists(uf.Id))
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
            return View(uf);
        }

        // GET: Ufs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uf = await _context.Uf
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uf == null)
            {
                return NotFound();
            }

            return View(uf);
        }

        // POST: Ufs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uf = await _context.Uf.FindAsync(id);
            _context.Uf.Remove(uf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UfExists(int id)
        {
            return _context.Uf.Any(e => e.Id == id);
        }
    }
}
