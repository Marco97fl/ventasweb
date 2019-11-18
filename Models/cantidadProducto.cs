using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class cantidadProducto
    {
        [Required]
        [Key]
        public int cantidadProductoId { get; set; }
        [Required]
        public int stockProd { get; set; }
        [Required]
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}