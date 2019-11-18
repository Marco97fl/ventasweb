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
        public int impuestoId { get; set; }
        [Required]
        public string nomImpuesto { get; set; }
        [Required]
        public double valorImpuesto { get; set; }
        [Required]
        [ForeignKey("SubCategoria")]
        public int SubCategoriaId { get; set; }
        public SubCategoria SubCategoria { get; set; }
    }
}