using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{
    public class Tooling
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public DateTime Date { get; set; }
        public string PPId { get; set; }
        public float? PPThickness { get; set; }
        public float? PPHeight { get; set; }

        public string SPId { get; set; }
        public float? SPThickness { get; set; }
        public float? SPHeight { get; set; }

        public float? MinDistance { get; set; }

        public string CSEId { get; set; }
        public string CBId { get; set; }

        public int? Cavity { get; set; }

        public byte[] PPImage { get; set; }
        public byte[] SPImage { get; set; }
        public byte[] CSEImage { get; set; }
        public byte[] CBImage { get; set; }

        public int FirstTemp { get; set; }
        public int LastTemp { get; set; }
        public int PouringTime { get; set; }
        public int NoOfMoldPerLadle { get; set; }
        public double TotalWeight {  get; set; } 

        public virtual ICollection<ControlPlan> ControlPlans { get; set; }
            = new HashSet<ControlPlan>();
    }
}
