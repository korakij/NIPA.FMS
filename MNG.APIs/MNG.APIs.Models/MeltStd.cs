using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.APIs.Models
{
    public class MeltStd
    {
        [Key]
        public string Code { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        public float? PigFC { get; set; }
        public float? PigFCD { get; set; }
        public float? RS { get; set; }
        public float? SS { get; set; }
        public float? C_FC { get; set; }
        public float? C_FCD { get; set; }
        public float? Fe_Si { get; set; }
        public float? Fe_Mn { get; set; }
        public float? HC_Cr { get; set; }
        public float? Fe_Ni { get; set; }
        public float? Fe_Mo { get; set; }
    }
}
