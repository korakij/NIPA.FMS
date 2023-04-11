using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{
    public class MeltStandard
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float? PigFC { get; set; }

        public float? PigFCD { get; set; }

        /// <summary>
        /// Return scraps
        /// </summary>
        public float? RS { get; set; }

        public float? SS { get; set; }
        public float? C_FC { get; set; }
        public float? C_FCD { get; set; }
        public float? Fe_Si { get; set; }
        public float? Fe_Mn { get; set; }
        public float? HC_Cr { get; set; }
        public float? Fe_Ni { get; set; }
        public float? Fe_Mo { get; set; }

        public virtual ICollection<ControlPlan> ControlPlans { get; set; }
            = new HashSet<ControlPlan>();
    }
}
