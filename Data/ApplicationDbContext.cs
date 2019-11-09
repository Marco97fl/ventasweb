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
        public DbSet<Producto> productos { get; set; }
        public DbSet<ventasweb.Models.Departamento> Departamento { get; set; }
        public DbSet<ventasweb.Models.SubCategoria> SubCategoria { get; set; }
        public DbSet<ventasweb.Models.Carrito> Carrito { get; set; }
        public DbSet<ventasweb.Models.DetalleCarrito> DetalleCarrito { get; set; }
    }
}
