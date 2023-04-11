using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class Molding
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public DateTime Time { get; set; }

        public virtual Line Line { get; set; }
        public string LineCode { get; set; }

        //public virtual Tooling Tooling { get; set; }
        //public string  ToolingCode { get; set; }

        public int NoOfMold { get; set; }
        public float? Compressibility { get; set; }

        public virtual ICollection<Pouring> Kanbans { get; set; }
            = new HashSet<Pouring>();
    }
}
