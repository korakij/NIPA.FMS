using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MNG.Models.Productions
{
    public class RawMaterial
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string MatCode { get; set; }

        public double? PigFC { get; set; }
        public double? PigFCD { get; set; }
        public double? RS { get; set; }
        public double? SS { get; set; }
        public double? RemainedMetal { get; set; }
        public double? Total { get; set; }

        public double? C_FC { get; set; }
        public double? C_FCD { get; set; }
        public double? Fe_Si { get; set; }
        public double? Fe_Mn { get; set; }
        public double? HC_Cr { get; set; }
        public double? Fe_Ni { get; set; }
        public double? Fe_Mo { get; set; }
    }
}
