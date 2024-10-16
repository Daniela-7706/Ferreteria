using Ferreteria.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ferreteria.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<OrdenCompra> OrdenCompras { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<Detalle_Factura> Detalle_Facturas { get; set; }

        public DbSet<Detalle_OrdenCompra> Detalle_OrdenCompras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Detalle_OrdenCompra>()
            .HasOne(d => d.OrdenCompra)
            .WithMany()
            .HasForeignKey(d => d.OrdenCompraId)
            .OnDelete(DeleteBehavior.SetNull);  // Si se elimina una OrdenCompra, el  en el detalle será null


            modelBuilder.Entity<Detalle_Factura>()
            .HasOne(d => d.Factura)
            .WithMany()
            .HasForeignKey(d => d.FacturaId)
            .OnDelete(DeleteBehavior.SetNull);  // Si se elimina una Factura, el  en el detalle será null

            modelBuilder.Entity<Detalle_OrdenCompra>()
            .HasOne(d => d.Producto)
            .WithMany() // No necesitas definir una colección en Producto si no la tienes
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);  // Evita eliminación en cascada

            modelBuilder.Entity<Detalle_OrdenCompra>()
            .HasOne(d => d.Producto)
            .WithMany() // No necesitas definir una colección en Producto si no la tienes
            .HasForeignKey(d => d.ProductoId)
            .OnDelete(DeleteBehavior.Restrict);  // Evita eliminación en cascada
        }





    }
}
