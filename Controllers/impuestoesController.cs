using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ventasweb.Data;
using ventasweb.Models;

namespace ventasweb.Controllers
{
    public class impuestoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public impuestoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: impuestoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.impuestos.Include(i => i.SubCategoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: impuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impuesto = await _context.impuestos
                .Include(i => i.SubCategoria)
                .FirstOrDefaultAsync(m => m.impuestoId == id);
            if (impuesto == null)
            {
                return NotFound();
            }

            return View(impuesto);
        }

        // GET: impuestoes/Create
        public IActionResult Create()
        {
            ViewData["SubCategoriaId"] = new SelectList(_context.SubCategorias, "SubCategoriaId", "nombreSubCategoria");
            return View();
        }

        // POST: impuestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("impuestoId,nomImpuesto,valorImpuesto,SubCategoriaId")] impuesto impuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(impuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCategoriaId"] = new SelectList(_context.SubCategorias, "SubCategoriaId", "nombreSubCategoria", impuesto.SubCategoriaId);
            return View(impuesto);
        }

        // GET: impuestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impuesto = await _context.impuestos.FindAsync(id);
            if (impuesto == null)
            {
                return NotFound();
            }
            ViewData["SubCategoriaId"] = new SelectList(_context.SubCategorias, "SubCategoriaId", "nombreSubCategoria", impuesto.SubCategoriaId);
            return View(impuesto);
        }

        // POST: impuestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("impuestoId,nomImpuesto,valorImpuesto,SubCategoriaId")] impuesto impuesto)
        {
            if (id != impuesto.impuestoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(impuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!impuestoExists(impuesto.impuestoId))
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
            ViewData["SubCategoriaId"] = new SelectList(_context.SubCategorias, "SubCategoriaId", "nombreSubCategoria", impuesto.SubCategoriaId);
            return View(impuesto);
        }

        // GET: impuestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impuesto = await _context.impuestos
                .Include(i => i.SubCategoria)
                .FirstOrDefaultAsync(m => m.impuestoId == id);
            if (impuesto == null)
            {
                return NotFound();
            }

            return View(impuesto);
        }

        // POST: impuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var impuesto = await _context.impuestos.FindAsync(id);
            _context.impuestos.Remove(impuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool impuestoExists(int id)
        {
            return _context.impuestos.Any(e => e.impuestoId == id);
        }
    }
}
