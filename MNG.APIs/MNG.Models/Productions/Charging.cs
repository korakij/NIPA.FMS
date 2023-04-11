using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class Charging
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string ChargeNo { get; set; }

        public string Status { get; set; }
        public float? PigFC { get; set; }
        public float? PigFCD { get; set; }
        public float? RS { get; set; }
        public float? SS { get; set; }
        public double? RemainedMetal { get; set; }
        public double? Total { get; set; }

        public float? C_FC { get; set; }
        public float? C_FCD { get; set; }
        public float? Fe_Si { get; set; }
        public float? Fe_Mn { get; set; }
        public float? HC_Cr { get; set; }
        public float? Fe_Ni { get; set; }
        public float? Fe_Mo { get; set; }
        
        public double StartKwHr { get; set; }
        public double MaxTempKwHr { get; set; }
        public int? MaxTemp { get; set; }
        public double PowerComp { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime ChargeTime { get; set; }
        public DateTime MaxTempTime { get; set; }
        public TimeSpan Interval { get; set; }

        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }

        public virtual ControlPlan ControlPlan { get; set; }
        public int? ControlPlanId { get; set; }

        public virtual LotNo LotNo { get; set; }
        [Required]
        public string LotNoCode { get; set; }

        public virtual ICollection<TestChemicalComposition> TestChemicalCompositions { get; set; }
            = new HashSet<TestChemicalComposition>();

        public TimeSpan GetTimeInteval()
        {
            return  MaxTempTime - ChargeTime;
        }

        public double GetPowerConsumption()
        {
            return MaxTempKwHr - StartKwHr;
        }

        public int GetHourIntervalChargeTime()
        {
            return (MaxTempTime - ChargeTime).Hours;
        }

    }
}
