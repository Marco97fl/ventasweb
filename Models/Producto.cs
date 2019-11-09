using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventasweb.Models
{
    public class Producto
    {

        public int Id { get; set; }
        public string nombreProducto { get; set; }
        public string fabricante { get; set; }
        public float precio { get; set; }
        public bool enVenta { get; set; }
        public float descuento { get; set; }

        public int SubCategoriaId { get; set; }

    }
}
