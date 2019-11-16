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
            return View(await _context.impuestos.ToListAsync());
        }

        // GET: impuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impuesto = await _context.impuestos
                .FirstOrDefaultAsync(m => m.idImpuesto == id);
            if (impuesto == null)
            {
                return NotFound();
            }

            return View(impuesto);
        }

        // GET: impuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: impuestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idImpuesto,nomImpuesto,valorImpuesto,subcategoriaId")] impuesto impuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(impuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(impuesto);
        }

        // POST: impuestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idImpuesto,nomImpuesto,valorImpuesto,subcategoriaId")] impuesto impuesto)
        {
            if (id != impuesto.idImpuesto)
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
                    if (!impuestoExists(impuesto.idImpuesto))
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
                .FirstOrDefaultAsync(m => m.idImpuesto == id);
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
            return _context.impuestos.Any(e => e.idImpuesto == id);
        }
    }
}
