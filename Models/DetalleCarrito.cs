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
        public int carritoId { get; set; }
        [Required]
        [ForeignKey("Producto")]
        public int productoId { get; set; }
        [Required]
        public int cantidadProd { get; set; }
        [Required]
        public double precioLinea { get; set; }
    }
}