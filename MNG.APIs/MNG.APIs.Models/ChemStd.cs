using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.APIs.Models
{
    public class ChemStd
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(150)]
        public string Desc { get; set; }

        public float? CMaxF { get; set; }
        public float? CMinF { get; set; }
        public float? SiMaxF { get; set; }
        public float? SiMinF { get; set; }
        public float? MnMaxF { get; set; }
        public float? MnMinF { get; set; }
        public float? MgMaxF { get; set; }
        public float? MgMinF { get; set; }
        public float? SMaxF { get; set; }
        public float? SMinF { get; set; }
        public float? AlMaxF { get; set; }
        public float? AlMinF { get; set; }
        public float? CuMaxF { get; set; }
        public float? CuMinF { get; set; }
        public float? SnMaxF { get; set; }
        public float? SnMinF { get; set; }
        public float? CrMaxF { get; set; }
        public float? CrMinF { get; set; }
        public float? PMaxF { get; set; }
        public float? PMinF { get; set; }
        public float? MoMaxF { get; set; }
        public float? MoMinF { get; set; }
        public float? NiMaxF { get; set; }
        public float? NiMinF { get; set; }
        public float? VMaxF { get; set; }
        public float? VMinF { get; set; }
        public float? TiMaxF { get; set; }
        public float? TiMinF { get; set; }
        public float? TeMaxF { get; set; }
        public float? TeMinF { get; set; }

        public float? CMaxL { get; set; }
        public float? CMinL { get; set; }
        public float? SiMaxL { get; set; }
        public float? SiMinL { get; set; }
        public float? MnMaxL { get; set; }
        public float? MnMinL { get; set; }
        public float? MgMaxL { get; set; }
        public float? MgMinL { get; set; }
        public float? SMaxL { get; set; }
        public float? SMinL { get; set; }
        public float? AlMaxL { get; set; }
        public float? AlMinL { get; set; }
        public float? CuMaxL { get; set; }
        public float? CuMinL { get; set; }
        public float? SnMaxL { get; set; }
        public float? SnMinL { get; set; }
        public float? CrMaxL { get; set; }
        public float? CrMinL { get; set; }
        public float? PMaxL { get; set; }
        public float? PMinL { get; set; }
        public float? MoMaxL { get; set; }
        public float? MoMinL { get; set; }
        public float? NiMaxL { get; set; }
        public float? NiMinL { get; set; }
        public float? VMaxL { get; set; }
        public float? VMinL { get; set; }
        public float? TiMaxL { get; set; }
        public float? TiMinL { get; set; }
        public float? TeMaxL { get; set; }
        public float? TeMinL { get; set; }
    }
}
