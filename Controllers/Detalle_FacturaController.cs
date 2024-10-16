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
    public class Detalle_FacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Detalle_FacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Detalle_Factura
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Detalle_Facturas.Include(d => d.Factura).Include(d => d.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Detalle_Factura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Factura = await _context.Detalle_Facturas
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalle_Factura == null)
            {
                return NotFound();
            }

            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Cliente");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre");
            return View();
        }

        // POST: Detalle_Factura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodDetalleFactura,FacturaId,ProductoId,CantidadP,NombreProducto,PrecioUnitario")] Detalle_Factura detalle_Factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Cliente", detalle_Factura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", detalle_Factura.ProductoId);
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Factura = await _context.Detalle_Facturas.FindAsync(id);
            if (detalle_Factura == null)
            {
                return NotFound();
            }
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Cliente", detalle_Factura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", detalle_Factura.ProductoId);
            return View(detalle_Factura);
        }

        // POST: Detalle_Factura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodDetalleFactura,FacturaId,ProductoId,CantidadP,NombreProducto,PrecioUnitario")] Detalle_Factura detalle_Factura)
        {
            if (id != detalle_Factura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_FacturaExists(detalle_Factura.Id))
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
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Cliente", detalle_Factura.FacturaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Nombre", detalle_Factura.ProductoId);
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalle_Factura = await _context.Detalle_Facturas
                .Include(d => d.Factura)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalle_Factura == null)
            {
                return NotFound();
            }

            return View(detalle_Factura);
        }

        // POST: Detalle_Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalle_Factura = await _context.Detalle_Facturas.FindAsync(id);
            if (detalle_Factura != null)
            {
                _context.Detalle_Facturas.Remove(detalle_Factura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_FacturaExists(int id)
        {
            return _context.Detalle_Facturas.Any(e => e.Id == id);
        }
    }
}
