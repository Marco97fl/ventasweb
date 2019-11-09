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
    public class SubCategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubCategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubCategoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubCategoria.ToListAsync());
        }

        // GET: SubCategoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            return View(subCategoria);
        }

        // GET: SubCategoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubCategoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombreSubCategoria")] SubCategoria subCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subCategoria);
        }

        // GET: SubCategoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategoria.FindAsync(id);
            if (subCategoria == null)
            {
                return NotFound();
            }
            return View(subCategoria);
        }

        // POST: SubCategoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombreSubCategoria")] SubCategoria subCategoria)
        {
            if (id != subCategoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCategoriaExists(subCategoria.Id))
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
            return View(subCategoria);
        }

        // GET: SubCategoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategoria = await _context.SubCategoria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCategoria == null)
            {
                return NotFound();
            }

            return View(subCategoria);
        }

        // POST: SubCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCategoria = await _context.SubCategoria.FindAsync(id);
            _context.SubCategoria.Remove(subCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCategoriaExists(int id)
        {
            return _context.SubCategoria.Any(e => e.Id == id);
        }
    }
}
