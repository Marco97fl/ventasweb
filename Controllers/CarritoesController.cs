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
    public class CarritoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carritoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carritos.Include(c => c.tarifaEnvio).Include(c => c.usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Carritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.tarifaEnvio)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carritoes/Create
        public IActionResult Create()
        {
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId");
            ViewData["usuarioId"] = new SelectList(_context.usuarios, "usuarioId", "direccion");
            return View();
        }

        // POST: Carritoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarritoId,subTotal,lugarEntrega,metodoPago,total,usuarioId,tarifaEnvioId")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId", carrito.tarifaEnvioId);
            ViewData["usuarioId"] = new SelectList(_context.usuarios, "usuarioId", "direccion", carrito.usuarioId);
            return View(carrito);
        }

        // GET: Carritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId", carrito.tarifaEnvioId);
            ViewData["usuarioId"] = new SelectList(_context.usuarios, "usuarioId", "direccion", carrito.usuarioId);
            return View(carrito);
        }

        // POST: Carritoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarritoId,subTotal,lugarEntrega,metodoPago,total,usuarioId,tarifaEnvioId")] Carrito carrito)
        {
            if (id != carrito.CarritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.CarritoId))
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
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId", carrito.tarifaEnvioId);
            ViewData["usuarioId"] = new SelectList(_context.usuarios, "usuarioId", "direccion", carrito.usuarioId);
            return View(carrito);
        }

        // GET: Carritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.tarifaEnvio)
                .Include(c => c.usuario)
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);
            _context.Carritos.Remove(carrito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.CarritoId == id);
        }
    }
}
