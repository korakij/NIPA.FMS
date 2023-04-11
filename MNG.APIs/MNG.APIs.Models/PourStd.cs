using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.APIs.Models
{
    public class PourStd
    {
        [Key]
        public string Code { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        public float Inoculant { get; set; }
        public float WiredInoc { get; set; }
        public float WiredMg { get; set; }
        public float Cu { get; set; }
        public float Sn { get; set; }
        public float FirstTemp { get; set; }
        public float LastTemp { get; set; }
        public float PouringTime { get; set; }
        public int NoOfMoldPerLadle { get; set; }
    }
}
