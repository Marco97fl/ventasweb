using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventasweb.Models
{
    public class DetalleCarrito
    {
        public int detalleCarritoId { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
    }
}
