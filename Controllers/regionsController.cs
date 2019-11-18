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
    public class regionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public regionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: regions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.regiones.Include(r => r.tarifaEnvio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.regiones
                .Include(r => r.tarifaEnvio)
                .FirstOrDefaultAsync(m => m.regionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: regions/Create
        public IActionResult Create()
        {
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId");
            return View();
        }

        // POST: regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("regionId,nombreRegion,tarifaEnvioId")] region region)
        {
            if (ModelState.IsValid)
            {
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId", region.tarifaEnvioId);
            return View(region);
        }

        // GET: regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.regiones.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId", region.tarifaEnvioId);
            return View(region);
        }

        // POST: regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("regionId,nombreRegion,tarifaEnvioId")] region region)
        {
            if (id != region.regionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(region);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!regionExists(region.regionId))
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
            ViewData["tarifaEnvioId"] = new SelectList(_context.tarifaEnvios, "tarifaEnvioId", "tarifaEnvioId", region.tarifaEnvioId);
            return View(region);
        }

        // GET: regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.regiones
                .Include(r => r.tarifaEnvio)
                .FirstOrDefaultAsync(m => m.regionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var region = await _context.regiones.FindAsync(id);
            _context.regiones.Remove(region);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool regionExists(int id)
        {
            return _context.regiones.Any(e => e.regionId == id);
        }
    }
}
