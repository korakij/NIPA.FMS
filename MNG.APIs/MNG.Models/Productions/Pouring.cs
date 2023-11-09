using MNG.Models.Productions.Defects;
using MNG.Models.Productions.QA;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class Pouring
    {
        public Pouring()
        {
            Defect = new DefectCause();
        }

        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public DateTime? FirstMoldTime { get; set; }
        public DateTime? LastMoldTime { get; set; }
        public TimeSpan? Duration { get; set; }

        public virtual Line Line { get; set; }
        [Required]
        public string LineCode { get; set; }

        public int? FirstTemp { get; set; }
        public int? LastTemp { get; set; }
        public int? NoOfPouredMold { get; set; }

        public bool? IsDurationOK { get; set; }
        public bool? IsFirstTempOK { get; set; }
        public bool? IsLastTempOK { get; set; }
        public bool? IsNoOfMoldOK { get; set; }

        public bool? IsPassed { get; set; }
        public bool? IsCompleted { get; set; }

        public int ProductNo { get; set; }
        public decimal PouredWeight { get; set; }
        public DefectCause Defect { get; set; }
        public QAInspection QInspect { get; set; }

        public virtual Product Product { get; set; }
        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductCode { get; set; }

        public virtual Kanban Kanban { get; set; }
        [Required]
        public string KanbanCode { get; set; }

        public virtual Molding Molding { get; set; }
        public string MoldingCode { get; set; }

        public void ValidateResult(PourStandard pourStd, Tooling tooling)
        {
            TimeSpan interval;

            if (LastMoldTime != null || FirstMoldTime != null)
            {
                var _lastMoldTime = (DateTime)(LastMoldTime);
                var _FirstMoldTime = (DateTime)(FirstMoldTime);

                interval = _lastMoldTime - _FirstMoldTime;

                if (interval.TotalMinutes <= tooling.PouringTime)
                    IsDurationOK = true;
                else
                    IsDurationOK = false;
            }

            IsFirstTempOK = IsBetween(null, tooling.FirstTemp, FirstTemp);
            IsLastTempOK = IsBetween(tooling.LastTemp, null, LastTemp);
            IsNoOfMoldOK = IsBetween(null, tooling.NoOfMoldPerLadle, NoOfPouredMold);

            IsPassed = (IsDurationOK ?? false) && (IsFirstTempOK ?? false) &&
                        (IsLastTempOK ?? false) && (IsNoOfMoldOK ?? false);

            IsCompleted = (FirstMoldTime == null ? false : true) &&
                          (LastMoldTime == null ? false : true) &&
                          (Duration == null ? false : true) &&
                          (LineCode == null ? false : true) &&
                          (FirstTemp == null ? false : true) &&
                          (LastTemp == null ? false : true) &&
                          (NoOfPouredMold == null ? false : true);
        }

        public bool IsBetween(Single? min, Single? max, Single? value)
        {
            if (min == null && max == null) return true;
            if (value == null) return false;

            if (min == null) { min = 0.0f; }
            if (max == null)
            {
                return value >= min;
            }

            return min <= value && value <= max;
        }

    }

}
