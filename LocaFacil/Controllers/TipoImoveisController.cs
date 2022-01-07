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
    public class TipoImoveisController : Controller
    {
        private readonly LocaFacilContext _context;

        public TipoImoveisController(LocaFacilContext context)
        {
            _context = context;
        }

        // GET: TipoImoveis
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoImovel.ToListAsync());
        }

        // GET: TipoImoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImovel = await _context.TipoImovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoImovel == null)
            {
                return NotFound();
            }

            return View(tipoImovel);
        }

        // GET: TipoImoveis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoImoveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TipoImovel tipoImovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoImovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoImovel);
        }

        // GET: TipoImoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImovel = await _context.TipoImovel.FindAsync(id);
            if (tipoImovel == null)
            {
                return NotFound();
            }
            return View(tipoImovel);
        }

        // POST: TipoImoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TipoImovel tipoImovel)
        {
            if (id != tipoImovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoImovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoImovelExists(tipoImovel.Id))
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
            return View(tipoImovel);
        }

        // GET: TipoImoveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImovel = await _context.TipoImovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoImovel == null)
            {
                return NotFound();
            }

            return View(tipoImovel);
        }

        // POST: TipoImoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoImovel = await _context.TipoImovel.FindAsync(id);
            _context.TipoImovel.Remove(tipoImovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoImovelExists(int id)
        {
            return _context.TipoImovel.Any(e => e.Id == id);
        }
    }
}
