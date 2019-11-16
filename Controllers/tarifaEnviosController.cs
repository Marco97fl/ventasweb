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
    public class tarifaEnviosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tarifaEnviosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tarifaEnvios
        public async Task<IActionResult> Index()
        {
            return View(await _context.tarifaEnvios.ToListAsync());
        }

        // GET: tarifaEnvios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifaEnvio = await _context.tarifaEnvios
                .FirstOrDefaultAsync(m => m.idTarifa == id);
            if (tarifaEnvio == null)
            {
                return NotFound();
            }

            return View(tarifaEnvio);
        }

        // GET: tarifaEnvios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tarifaEnvios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTarifa,valorTarifa")] tarifaEnvio tarifaEnvio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifaEnvio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarifaEnvio);
        }

        // GET: tarifaEnvios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifaEnvio = await _context.tarifaEnvios.FindAsync(id);
            if (tarifaEnvio == null)
            {
                return NotFound();
            }
            return View(tarifaEnvio);
        }

        // POST: tarifaEnvios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTarifa,valorTarifa")] tarifaEnvio tarifaEnvio)
        {
            if (id != tarifaEnvio.idTarifa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifaEnvio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tarifaEnvioExists(tarifaEnvio.idTarifa))
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
            return View(tarifaEnvio);
        }

        // GET: tarifaEnvios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifaEnvio = await _context.tarifaEnvios
                .FirstOrDefaultAsync(m => m.idTarifa == id);
            if (tarifaEnvio == null)
            {
                return NotFound();
            }

            return View(tarifaEnvio);
        }

        // POST: tarifaEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarifaEnvio = await _context.tarifaEnvios.FindAsync(id);
            _context.tarifaEnvios.Remove(tarifaEnvio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tarifaEnvioExists(int id)
        {
            return _context.tarifaEnvios.Any(e => e.idTarifa == id);
        }
    }
}
