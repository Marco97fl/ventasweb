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
    public class tag_prodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tag_prodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tag_prod
        public async Task<IActionResult> Index()
        {
            return View(await _context.tag_prods.ToListAsync());
        }

        // GET: tag_prod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag_prod = await _context.tag_prods
                .FirstOrDefaultAsync(m => m.productoId == id);
            if (tag_prod == null)
            {
                return NotFound();
            }

            return View(tag_prod);
        }

        // GET: tag_prod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tag_prod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productoId,tagId")] tag_prod tag_prod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tag_prod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tag_prod);
        }

        // GET: tag_prod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag_prod = await _context.tag_prods.FindAsync(id);
            if (tag_prod == null)
            {
                return NotFound();
            }
            return View(tag_prod);
        }

        // POST: tag_prod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productoId,tagId")] tag_prod tag_prod)
        {
            if (id != tag_prod.productoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tag_prod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tag_prodExists(tag_prod.productoId))
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
            return View(tag_prod);
        }

        // GET: tag_prod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag_prod = await _context.tag_prods
                .FirstOrDefaultAsync(m => m.productoId == id);
            if (tag_prod == null)
            {
                return NotFound();
            }

            return View(tag_prod);
        }

        // POST: tag_prod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag_prod = await _context.tag_prods.FindAsync(id);
            _context.tag_prods.Remove(tag_prod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tag_prodExists(int id)
        {
            return _context.tag_prods.Any(e => e.productoId == id);
        }
    }
}
