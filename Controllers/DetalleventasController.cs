using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DetalleventasController : Controller
    {
        private readonly SistemaVentaContext _context;

        public DetalleventasController(SistemaVentaContext context)
        {
            _context = context;
        }

        // GET: Detalleventas
        public async Task<IActionResult> Index()
        {
            var sistemaVentaContext = _context.Detalleventa.Include(d => d.IdnumdocumentoNavigation).Include(d => d.IdproductoNavigation);
            return View(await sistemaVentaContext.ToListAsync());
        }

        // GET: Detalleventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalleventa == null)
            {
                return NotFound();
            }

            var detalleventa = await _context.Detalleventa
                .Include(d => d.IdnumdocumentoNavigation)
                .Include(d => d.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Idnumdocumento == id);
            if (detalleventa == null)
            {
                return NotFound();
            }

            return View(detalleventa);
        }

        // GET: Detalleventas/Create
        public IActionResult Create()
        {
            ViewData["Idnumdocumento"] = new SelectList(_context.Venta, "Idnumdocumento", "Idnumdocumento");
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto");
            return View();
        }

        // POST: Detalleventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnumdocumento,Serie,Idproducto,Cantidad,Precio")] Detalleventa detalleventa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleventa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idnumdocumento"] = new SelectList(_context.Venta, "Idnumdocumento", "Idnumdocumento", detalleventa.Idnumdocumento);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", detalleventa.Idproducto);
            return View(detalleventa);
        }

        // GET: Detalleventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalleventa == null)
            {
                return NotFound();
            }

            var detalleventa = await _context.Detalleventa.FindAsync(id);
            if (detalleventa == null)
            {
                return NotFound();
            }
            ViewData["Idnumdocumento"] = new SelectList(_context.Venta, "Idnumdocumento", "Idnumdocumento", detalleventa.Idnumdocumento);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", detalleventa.Idproducto);
            return View(detalleventa);
        }

        // POST: Detalleventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnumdocumento,Serie,Idproducto,Cantidad,Precio")] Detalleventa detalleventa)
        {
            if (id != detalleventa.Idnumdocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleventa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleventaExists(detalleventa.Idnumdocumento))
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
            ViewData["Idnumdocumento"] = new SelectList(_context.Venta, "Idnumdocumento", "Idnumdocumento", detalleventa.Idnumdocumento);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", detalleventa.Idproducto);
            return View(detalleventa);
        }

        // GET: Detalleventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalleventa == null)
            {
                return NotFound();
            }

            var detalleventa = await _context.Detalleventa
                .Include(d => d.IdnumdocumentoNavigation)
                .Include(d => d.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Idnumdocumento == id);
            if (detalleventa == null)
            {
                return NotFound();
            }

            return View(detalleventa);
        }

        // POST: Detalleventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalleventa == null)
            {
                return Problem("Entity set 'SistemaVentaContext.Detalleventa'  is null.");
            }
            var detalleventa = await _context.Detalleventa.FindAsync(id);
            if (detalleventa != null)
            {
                _context.Detalleventa.Remove(detalleventa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleventaExists(int id)
        {
          return (_context.Detalleventa?.Any(e => e.Idnumdocumento == id)).GetValueOrDefault();
        }
    }
}
