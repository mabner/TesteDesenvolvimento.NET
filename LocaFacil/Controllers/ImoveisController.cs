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
    public class ImoveisController : Controller
    {
        private readonly LocaFacilContext _context;

        public ImoveisController(LocaFacilContext context)
        {
            _context = context;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index()
        {
            var locaFacilContext = _context.Imovel.Include(i => i.Endereco).Include(i => i.Locatario).Include(i => i.Proprietario).Include(i => i.TipoImovel);
            return View(await locaFacilContext.ToListAsync());
        }

        // GET: Imoveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .Include(i => i.Endereco)
                .Include(i => i.Locatario)
                .Include(i => i.Proprietario)
                .Include(i => i.TipoImovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imoveis/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro");
            ViewData["LocatarioId"] = new SelectList(_context.Locatario, "Id", "Nome");
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome");
            ViewData["TipoImovelId"] = new SelectList(_context.TipoImovel, "Id", "Descricao");
            return View();
        }

        // POST: Imoveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoImovelId,EnderecoId,ValorAluguel,ValorCondominio,ValorIPTU,VagaGaragem,Descricao,ProprietarioId,LocatarioId")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", imovel.EnderecoId);
            ViewData["LocatarioId"] = new SelectList(_context.Locatario, "Id", "Nome", imovel.LocatarioId);
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", imovel.ProprietarioId);
            ViewData["TipoImovelId"] = new SelectList(_context.TipoImovel, "Id", "Descricao", imovel.TipoImovelId);
            return View(imovel);
        }

        // GET: Imoveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", imovel.EnderecoId);
            ViewData["LocatarioId"] = new SelectList(_context.Locatario, "Id", "Nome", imovel.LocatarioId);
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", imovel.ProprietarioId);
            ViewData["TipoImovelId"] = new SelectList(_context.TipoImovel, "Id", "Descricao", imovel.TipoImovelId);
            return View(imovel);
        }

        // POST: Imoveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoImovelId,EnderecoId,ValorAluguel,ValorCondominio,ValorIPTU,VagaGaragem,Descricao,ProprietarioId,LocatarioId")] Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Bairro", imovel.EnderecoId);
            ViewData["LocatarioId"] = new SelectList(_context.Locatario, "Id", "Nome", imovel.LocatarioId);
            ViewData["ProprietarioId"] = new SelectList(_context.Proprietario, "Id", "Nome", imovel.ProprietarioId);
            ViewData["TipoImovelId"] = new SelectList(_context.TipoImovel, "Id", "Descricao", imovel.TipoImovelId);
            return View(imovel);
        }

        // GET: Imoveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .Include(i => i.Endereco)
                .Include(i => i.Locatario)
                .Include(i => i.Proprietario)
                .Include(i => i.TipoImovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imovel.FindAsync(id);
            _context.Imovel.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
