using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class usuario
    {
        [Required]
        [Key]
        public int usuarioId { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string primerNomb { get; set; }
        [Required]
        public string primerApell { get; set; }
        [Required]
        public string direccion { get; set; }
        [Required]
        public string telefono { get; set; }
        [Required]
        public string pais { get; set; }
        public List<Carrito> carritos { get; set; }
    }
}