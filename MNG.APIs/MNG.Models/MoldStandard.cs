using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{
    public class MoldStandard
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public int MoldHBMin { get; set; }
        public int CompressiveMax { get; set; }
        public int CompressiveMin { get; set; }
        public int MoldSizeMax { get; set; }
        public int MoldSizeMin { get; set; }

        public float MoldThicknessCorr { get; set; }
        public float MoldPositionCorr { get; set; }
        public float ShotPressure { get; set; }
        public float ShotTimeCorr { get; set; }
        public float SqueezePressure { get; set; }
        public float ExtendedSqueezeTime { get; set; }
        public float PPStrippingDist { get; set; }
        public float PPStrippingAcc { get; set; }
        public float SPStrippingDist { get; set; }
        public float SPStrippingAcc { get; set; }
        public int CSE { get; set; }
        public float CoreSettingTime { get; set; }

        public virtual ICollection<ControlPlan> ControlPlans { get; set; }
             = new HashSet<ControlPlan>();
    }
}
