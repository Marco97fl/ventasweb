using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ventasweb.Models;

namespace ventasweb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        public DbSet<cantidadProducto> cantidadProductos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DetalleCarrito> DetalleCarritos { get; set; }
        public DbSet<impuesto> impuestos { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<region> regiones { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<tag_prod> tag_prods { get; set; }
        public DbSet<tarifaEnvio> tarifaEnvios { get; set; }
        public DbSet<usuario> usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DetalleCarrito>().HasKey(o => new { o.CarritoId, o.ProductoId });
            modelBuilder.Entity<tag_prod>().HasKey(o => new { o.ProductoId, o.tagId });
        }
    }
}