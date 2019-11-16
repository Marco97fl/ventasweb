﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class region
    {
        [Required]
        [Key]
        public int idRegion { get; set; }
        [Required]
        public string nombreRegion { get; set; }
        [Required]
        [ForeignKey("tarifaEnvio")]
        public int idTarifa { get; set; }
    }
}