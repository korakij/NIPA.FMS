using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{
    public class MaterialSpecification
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        // Both Max and Min required
        public int? HBMax { get; set; }
        public int? HBMin { get; set; }

        public float? FerriteMax { get; set; }
        public float? FerriteMin { get; set; }

        public float? PearliteMax { get; set; }
        public float? PearliteMin { get; set; }

        public float? CementiteMax { get; set; }
        public float? CementiteMin { get; set; }

        public float? SizeMax { get; set; }
        public float? SizeMin { get; set; }

        // Only Min value required
        public float? NodularityMax { get; set; }
        public float? NodularityMin { get; set; }
        public int? TensileMax { get; set; }
        public int? TensileMin { get; set; }
        public float? SizeTensileMax { get; set; }
        public float? SizeTensileMin { get; set; }
        public float? ElongationMax { get; set; }
        public float? ElongationMin { get; set; }
        public float? YieldMax { get; set; }
        public float? YieldMin { get; set; }
        public float? GraphiteAMax { get; set; }
        public float? GraphiteAMin { get; set; }
        public float? NoduleCount { get; set; }

        public ICollection<ControlPlan> ControlPlans { get; set; }
            = new HashSet<ControlPlan>();
    }
}
