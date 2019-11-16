using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{

    public class Carrito
    {
        [Required]
        [Key]
        public int carritoId { get; set; }
        [Required]
        public double subTotal { get; set; }
        [Required]
        public string lugarEntrega { get; set; }
        [Required]
        public string metodoPago { get; set; }
        [Required]
        public double total { get; set; }
        [Required]
        [ForeignKey("usuario")]
        public int idUsuario { get; set; }
        [Required]
        [ForeignKey("tarifaEnvio")]
        public int idTarifa { get; set; }
        public List<DetalleCarrito> detalleCarritoId { get; set; }

    }
}

