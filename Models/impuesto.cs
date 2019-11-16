using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class impuesto
    {
        [Required]
        [Key]
        public int idImpuesto { get; set; }
        [Required]
        public string nomImpuesto { get; set; }
        [Required]
        public double valorImpuesto { get; set; }
        [Required]
        [ForeignKey("SubCategoria")]
        public int subcategoriaId { get; set; }
    }
}