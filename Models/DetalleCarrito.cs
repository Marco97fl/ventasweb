using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class DetalleCarrito
    {
        [Required]
        [ForeignKey("Carrito")]
        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }
        [Required]
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        [Required]
        public int cantidadProd { get; set; }
        [Required]
        public double precioLinea { get; set; }
    }
}