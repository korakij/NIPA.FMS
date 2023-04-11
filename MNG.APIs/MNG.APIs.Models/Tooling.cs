using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.APIs.Models
{
    public class Tooling
    {
        [Key]
        public string Code { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        public DateTime Date { get; set; }
        public string PPId { get; set; }
        public float PPThickness { get; set; }
        public float PPHeight { get; set; }

        public string SPId { get; set; }
        public float SPThickness { get; set; }
        public float SPHeight { get; set; }

        public float MinDistance { get; set; }

        public string CSEId { get; set; }
        public string CBId { get; set; }
    }
}
