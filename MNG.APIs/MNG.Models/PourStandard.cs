using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{
    public class PourStandard
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public int TappingWg { get; set; }
        public float? Inoculant { get; set; }
        public float? InoculantTol { get; set; }
        public float? WiredInoc { get; set; }
        public float? WiredInocTol { get; set; }
        public float? Magnesium { get; set; }
        public float? MagnesiumTol { get; set; }
        public float? WiredMg { get; set; }
        public float? WiredMgTol { get; set; }
        public float? FeedTemp { get; set; }
        public float? FeddTempTol { get; set; }
        public float? Cu { get; set; }
        public float? CuTol { get; set; }
        public float? Sn { get; set; }
        public float? SnTol { get; set; }
        public float? ChillMax { get; set; }

        public virtual ICollection<ControlPlan> ControlPlans { get; set; }
            = new HashSet<ControlPlan>();
    }
}
