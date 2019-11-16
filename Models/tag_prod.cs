using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class tag_prod
    {
        [Required]
        [ForeignKey("Producto")]
        public int productoId { get; set; }
        [Required]
        [ForeignKey("tag")]
        public int tagId { get; set; }
    }
}