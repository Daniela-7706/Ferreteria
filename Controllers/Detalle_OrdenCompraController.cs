using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ferreteria.Data;
using Ferreteria.Models;

namespace Ferreteria.Controllers
{
    public class Detalle_OrdenCompraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Detalle_OrdenCompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Detalle_OrdenCompra
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Detalle_OrdenCompras.Include(d => d.OrdenCompra).Include(d => d.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Detalle_OrdenCompra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_OrdenCompra = await _context.Detalle_OrdenCompras
                .Include(d => d.OrdenCompra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalle_OrdenCompra == null)
            {
                return NotFound();
            }

            return View(detalle_OrdenCompra);
        }

        // GET: Detalle_OrdenCompra/Create
        public IActionResult Create()
        {
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "Id", "CodOrdenCompra");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre");
            return View();
        }

        // POST: Detalle_OrdenCompra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodDetalleFactura,OrdenCompraId,ProductoId,CantidadP,PrecioUnitario")] Detalle_OrdenCompra detalle_OrdenCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_OrdenCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "Id", "CodOrdenCompra", detalle_OrdenCompra.OrdenCompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", detalle_OrdenCompra.ProductoId);
            return View(detalle_OrdenCompra);
        }

        // GET: Detalle_OrdenCompra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_OrdenCompra = await _context.Detalle_OrdenCompras.FindAsync(id);
            if (detalle_OrdenCompra == null)
            {
                return NotFound();
            }
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "Id", "CodOrdenCompra", detalle_OrdenCompra.OrdenCompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", detalle_OrdenCompra.ProductoId);
            return View(detalle_OrdenCompra);
        }

        // POST: Detalle_OrdenCompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodDetalleFactura,OrdenCompraId,ProductoId,CantidadP,PrecioUnitario")] Detalle_OrdenCompra detalle_OrdenCompra)
        {
            if (id != detalle_OrdenCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_OrdenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_OrdenCompraExists(detalle_OrdenCompra.Id))
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
            ViewData["OrdenCompraId"] = new SelectList(_context.OrdenCompras, "Id", "CodOrdenCompra", detalle_OrdenCompra.OrdenCompraId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", detalle_OrdenCompra.ProductoId);
            return View(detalle_OrdenCompra);
        }

        // GET: Detalle_OrdenCompra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_OrdenCompra = await _context.Detalle_OrdenCompras
                .Include(d => d.OrdenCompra)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalle_OrdenCompra == null)
            {
                return NotFound();
            }

            return View(detalle_OrdenCompra);
        }

        // POST: Detalle_OrdenCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle_OrdenCompra = await _context.Detalle_OrdenCompras.FindAsync(id);
            if (detalle_OrdenCompra != null)
            {
                _context.Detalle_OrdenCompras.Remove(detalle_OrdenCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_OrdenCompraExists(int id)
        {
            return _context.Detalle_OrdenCompras.Any(e => e.Id == id);
        }
    }
}
