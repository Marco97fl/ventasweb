using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ventasweb.Models
{
    public class tag
    {
        [Required]
        [Key]
        public int tagId { get; set; }
        [Required]
        public string nomTag { get; set; }
        public List<tag_prod> tags_prods { get; set; }
    }
}
