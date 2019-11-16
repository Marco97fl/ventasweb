using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class Producto
    {
        [Required]
        [Key]
        public int productoId { get; set; }
        [Required]
        public string nombreProducto { get; set; }
        [Required]
        public string fabricante { get; set; }
        [Required]
        public string proveedor { get; set; }
        [Required]
        public double peso { get; set; }
        public double volumen { get; set; }
        [Required]
        public float precioProd { get; set; }
        [Required]
        public bool enVenta { get; set; }
        [Required]
        public string descripcionProd { get; set; }
        [Required]
        [ForeignKey("SubCategoria")]
        public int subcategoriaId { get; set; }
        public List<DetalleCarrito> detallesCarrito { get; set; }
        public List<tag_prod> tag_prods { get; set; }
        public cantidadProducto cantProducto { get; set; }
    }
}
