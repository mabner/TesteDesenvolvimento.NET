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
    public class LocatariosController : Controller
    {
        private readonly LocaFacilContext _context;

        public LocatariosController(LocaFacilContext context)
        {
            _context = context;
        }

        // GET: Locatarios
        public async Task<IActionResult> Index()
        {
            var locaFacilContext = _context.Locatario.Include(l => l.Endereco).Include(l => l.Telefone);
            return View(await locaFacilContext.ToListAsync());
        }

        // GET: Locatarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatario = await _context.Locatario
                .Include(l => l.Endereco)
                .Include(l => l.Telefone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locatario == null)
            {
                return NotFound();
            }

            return View(locatario);
        }

        // GET: Locatarios/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro");
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "Id", "numero");
            return View();
        }

        // POST: Locatarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,TelefoneId,EnderecoId")] Locatario locatario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locatario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", locatario.EnderecoId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "Id", "numero", locatario.TelefoneId);
            return View(locatario);
        }

        // GET: Locatarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatario = await _context.Locatario.FindAsync(id);
            if (locatario == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", locatario.EnderecoId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "Id", "numero", locatario.TelefoneId);
            return View(locatario);
        }

        // POST: Locatarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,TelefoneId,EnderecoId")] Locatario locatario)
        {
            if (id != locatario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locatario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocatarioExists(locatario.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", locatario.EnderecoId);
            ViewData["TelefoneId"] = new SelectList(_context.Telefone, "Id", "numero", locatario.TelefoneId);
            return View(locatario);
        }

        // GET: Locatarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locatario = await _context.Locatario
                .Include(l => l.Endereco)
                .Include(l => l.Telefone)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locatario == null)
            {
                return NotFound();
            }

            return View(locatario);
        }

        // POST: Locatarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locatario = await _context.Locatario.FindAsync(id);
            _context.Locatario.Remove(locatario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatarioExists(int id)
        {
            return _context.Locatario.Any(e => e.Id == id);
        }
    }
}
