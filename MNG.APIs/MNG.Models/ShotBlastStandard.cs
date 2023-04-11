using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{
    public class ShotBlastStandard
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public float BallSize { get; set; }
        public int Current { get; set; }
        public int Duration { get; set; }
        public int? ShakeOutTemp { get; set; }
        public int? UltraSonic { get; set; }

        public virtual ICollection<ControlPlan> ControlPlans { get; set; }
             = new HashSet<ControlPlan>();
    }
}
