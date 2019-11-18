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
    public class DetalleCarritoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalleCarritoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetalleCarritoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetalleCarritos.Include(d => d.Carrito).Include(d => d.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleCarritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarrito = await _context.DetalleCarritos
                .Include(d => d.Carrito)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (detalleCarrito == null)
            {
                return NotFound();
            }

            return View(detalleCarrito);
        }

        // GET: DetalleCarritoes/Create
        public IActionResult Create()
        {
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "lugarEntrega");
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd");
            return View();
        }

        // POST: DetalleCarritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarritoId,ProductoId,cantidadProd,precioLinea")] DetalleCarrito detalleCarrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCarrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "lugarEntrega", detalleCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd", detalleCarrito.ProductoId);
            return View(detalleCarrito);
        }

        // GET: DetalleCarritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarrito = await _context.DetalleCarritos.FindAsync(id);
            if (detalleCarrito == null)
            {
                return NotFound();
            }
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "lugarEntrega", detalleCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd", detalleCarrito.ProductoId);
            return View(detalleCarrito);
        }

        // POST: DetalleCarritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarritoId,ProductoId,cantidadProd,precioLinea")] DetalleCarrito detalleCarrito)
        {
            if (id != detalleCarrito.CarritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCarrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCarritoExists(detalleCarrito.CarritoId))
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
            ViewData["CarritoId"] = new SelectList(_context.Carritos, "CarritoId", "lugarEntrega", detalleCarrito.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.productos, "ProductoId", "descripcionProd", detalleCarrito.ProductoId);
            return View(detalleCarrito);
        }

        // GET: DetalleCarritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleCarrito = await _context.DetalleCarritos
                .Include(d => d.Carrito)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (detalleCarrito == null)
            {
                return NotFound();
            }

            return View(detalleCarrito);
        }

        // POST: DetalleCarritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleCarrito = await _context.DetalleCarritos.FindAsync(id);
            _context.DetalleCarritos.Remove(detalleCarrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCarritoExists(int id)
        {
            return _context.DetalleCarritos.Any(e => e.CarritoId == id);
        }
    }
}
