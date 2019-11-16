using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ventasweb.Models
{
    public class tarifaEnvio
    {
        [Required]
        [Key]
        public int idTarifa { get; set; }
        [Required]
        public double valorTarifa { get; set; }
        public List<region> regiones { get; set; }
        public List<Carrito> carritos { get; set; }
    }
}
