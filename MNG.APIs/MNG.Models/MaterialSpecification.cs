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
        public float? NodularityMin { get; set; }
        public int? Tensile { get; set; }
        public float? Elongation { get; set; }
        public float? Yield { get; set; }
        public float? GraphiteA { get; set; }
        public float? NoduleCount { get; set; }

        public ICollection<ControlPlan> ControlPlans { get; set; }
            = new HashSet<ControlPlan>();
    }
}
