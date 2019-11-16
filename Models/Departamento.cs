using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class Departamento
    {
        [Required]
        [Key]
        public int departamentoId { get; set; }
        [Required]
        public string nombreDepartamento { get; set; }
        public List<SubCategoria> subcategorias { get; set; }
    }
}

