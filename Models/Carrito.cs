using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventasweb.Models
{
    public class Carrito
    {
        public int carritoId { get; set; }
        public double subTotal { get; set; }
        public string lugarEntrega { get; set; }
        public List<DetalleCarrito> detalleCarritoId { get; set; }

    }
}
