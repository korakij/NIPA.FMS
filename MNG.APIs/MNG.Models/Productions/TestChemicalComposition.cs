using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class TestChemicalComposition
    {
        public TestChemicalComposition()
        {
            Result = new ChemicalComposition();
            Validation = new ChemicalCompositionValidation();
        }

        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public DateTime Time { get; set; }
        public DateTime UpdatedTime { get; set; }

        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }

        public ChemicalComposition Result { get; set; }
        public ChemicalCompositionValidation Validation { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPassed { get; set; }

        public virtual Charging Charging { get; set; }
        [Required]
        [ForeignKey(nameof(Charging))]
        public string ChargingCode { get; set; }

        public virtual ICollection<Kanban> Kanbans { get; set; }
            = new HashSet<Kanban>();

        public virtual ChemicalCompositionValidation ValidateResult(ChemicalCompositionInFurnace spec)
        {
            var val = new ChemicalCompositionValidation();

            val.IsOk_CCE = IsBetween(spec.CCEMin, spec.CCEMax, Result.CCE);
            val.IsOk_C = IsBetween(spec.CMin, spec.CMax, Result.C);
            val.IsOk_Si = IsBetween(spec.SiMin, spec.SiMax, Result.Si);
            val.IsOk_Mn = IsBetween(spec.MnMin, spec.MnMax, Result.Mn);
            val.IsOk_Mg = IsBetween(spec.MgMin, spec.MgMax, Result.Mg);
            val.IsOk_S = IsBetween(spec.SMin, spec.SMax, Result.S);
            val.IsOk_Al = IsBetween(spec.AlMin, spec.AlMax, Result.Al);
            val.IsOk_Cu = IsBetween(spec.CuMin, spec.CuMax, Result.Cu);
            val.IsOk_Sn = IsBetween(spec.SnMin, spec.SnMax, Result.Sn);
            val.IsOk_Cr = IsBetween(spec.CrMin, spec.CrMax, Result.Cr);
            val.IsOk_P = IsBetween(spec.PMin, spec.PMax, Result.P);
            val.IsOk_Mo = IsBetween(spec.MoMin, spec.MoMax, Result.Mo);
            val.IsOk_Ni = IsBetween(spec.NiMin, spec.NiMax, Result.Ni);
            val.IsOk_V = IsBetween(spec.VMin, spec.VMax, Result.V);
            val.IsOk_Ti = IsBetween(spec.TiMin, spec.TiMax, Result.Ti);
            val.IsOk_Te = IsBetween(spec.TeMin, spec.TeMax, Result.Te);

            return val;
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
