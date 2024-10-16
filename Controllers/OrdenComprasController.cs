using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ferreteria.Data;
using Ferreteria.Models;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Ferreteria.Controllers
{
    public class OrdenComprasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenComprasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdenCompras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrdenCompras.Include(o => o.Proveedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdenCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompras
                .Include(o => o.Proveedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // GET: OrdenCompras/Create
        public IActionResult Create()
        {
           

            var proveedores = _context.Proveedores
             .Select(p => new { p.Id, p.Nombre, p.Nit })
             .ToList();

            ViewBag.ProveedorId = new SelectList(proveedores, "Id", "Nombre");
            ViewBag.ProveedoresData = JsonConvert.SerializeObject(proveedores);

          
            return View();
        }

        // POST: OrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodOrdenCompra,FechaPedOrdCom,FechaEntOrdCom,ProveedorId,NombreProveedor")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var proveedores = _context.Proveedores
         .Select(p => new { p.Id, p.Nombre, p.Nit })
         .ToList();

            ViewBag.ProveedorId = new SelectList(proveedores, "Id", "Nombre");
            ViewBag.ProveedoresData = JsonConvert.SerializeObject(proveedores);



            return View(ordenCompra);
        }

        // GET: OrdenCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompras.FindAsync(id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            var proveedores = _context.Proveedores
         .Select(p => new { p.Id, p.Nombre, p.Nit })
         .ToList();

            ViewBag.ProveedorId = new SelectList(proveedores, "Id", "Nombre");
            ViewBag.ProveedoresData = JsonConvert.SerializeObject(proveedores);

            return View(ordenCompra);
        }

        // POST: OrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodOrdenCompra,FechaPedOrdCom,FechaEntOrdCom,ProveedorId,NombreProveedor")] OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraExists(ordenCompra.Id))
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

            var proveedores = _context.Proveedores
         .Select(p => new { p.Id, p.Nombre, p.Nit })
         .ToList();

            ViewBag.ProveedorId = new SelectList(proveedores, "Id", "Nombre");
            ViewBag.ProveedoresData = JsonConvert.SerializeObject(proveedores);

            return View(ordenCompra);

        }

        // GET: OrdenCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompras
                .Include(o => o.Proveedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // POST: OrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenCompra = await _context.OrdenCompras.FindAsync(id);
            if (ordenCompra != null)
            {
                _context.OrdenCompras.Remove(ordenCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenCompraExists(int id)
        {
            return _context.OrdenCompras.Any(e => e.Id == id);
        }
    }
}
