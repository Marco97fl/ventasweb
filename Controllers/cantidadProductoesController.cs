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
    public class cantidadProductoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public cantidadProductoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: cantidadProductoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.cantidadProductos.Include(c => c.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: cantidadProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cantidadProducto = await _context.cantidadProductos
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.cantidadProductoId == id);
            if (cantidadProducto == null)
            {
                return NotFound();
            }

            return View(cantidadProducto);
        }

        // GET: cantidadProductoes/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd");
            return View();
        }

        // POST: cantidadProductoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cantidadProductoId,stockProd,ProductoId")] cantidadProducto cantidadProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cantidadProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd", cantidadProducto.ProductoId);
            return View(cantidadProducto);
        }

        // GET: cantidadProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cantidadProducto = await _context.cantidadProductos.FindAsync(id);
            if (cantidadProducto == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd", cantidadProducto.ProductoId);
            return View(cantidadProducto);
        }

        // POST: cantidadProductoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cantidadProductoId,stockProd,ProductoId")] cantidadProducto cantidadProducto)
        {
            if (id != cantidadProducto.cantidadProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cantidadProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cantidadProductoExists(cantidadProducto.cantidadProductoId))
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
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd", cantidadProducto.ProductoId);
            return View(cantidadProducto);
        }

        // GET: cantidadProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cantidadProducto = await _context.cantidadProductos
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.cantidadProductoId == id);
            if (cantidadProducto == null)
            {
                return NotFound();
            }

            return View(cantidadProducto);
        }

        // POST: cantidadProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cantidadProducto = await _context.cantidadProductos.FindAsync(id);
            _context.cantidadProductos.Remove(cantidadProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cantidadProductoExists(int id)
        {
            return _context.cantidadProductos.Any(e => e.cantidadProductoId == id);
        }
    }
}
