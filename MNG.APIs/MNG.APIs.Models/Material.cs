using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.APIs.Models
{
    public class Material
    {
        [Key]
        public string Code { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }
    }
}
