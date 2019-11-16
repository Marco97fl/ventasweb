using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class SubCategoria
    {
        [Required]
        [Key]
        public int subcategoriaId { get; set; }
        [Required]
        public string nombreSubCategoria { get; set; }
        [Required]
        [ForeignKey("Departamento")]
        public int departamentoId { get; set; }
        public List<impuesto> impuestos { get; set; }
        public List<Producto> productos { get; set; }

    }
}
