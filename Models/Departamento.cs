using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventasweb.Models
{
    public class Departamento
    {
        public int departamentoId { get; set; }
        public string nombreDepartamento { get; set; }

        public List<SubCategoria>  subcategorias { get; set; }
    }
}
