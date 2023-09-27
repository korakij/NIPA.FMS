using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class Kanban
    {
        public Kanban()
        {
            Result = new ChemicalComposition();
            Validation = new ChemicalCompositionValidation();
            MatValidation = new MaterialQuantityValidation();
        }

        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public DateTime Time { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int? TappingTemp { get; set; }

        public float Weight { get; set; }
        public float KwHr { get; set; }
        public float? Inoculant { get; set; }
        public float? WireInoculant { get; set; }
        public float? Magnesium { get; set; }
        public float? WireMagnesium { get; set; }
        public float? Copper { get; set; }
        public float? Tin { get; set; }
        public float? FeedTemp { get; set; }
        public float? Chill { get; set; }

        public ChemicalComposition Result { get; set; }
        public ChemicalCompositionValidation Validation { get; set; }
        public MaterialQuantityValidation MatValidation { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPassed { get; set; }

        public Material Material { get; set; }
        public string MaterialCode { get; set; }

        public virtual ControlPlan ControlPlan { get; set; }
        public int? ControlPlanId { get; set; }

        public virtual TestChemicalComposition TestChemicalComposition { get; set; }
        [Required]
        [StringLength(20)]
        public string TestChemicalCompositionCode { get; set; }

        public virtual ICollection<Pouring> Kanbans { get; set; }
            = new HashSet<Pouring>();


        public virtual ChemicalCompositionValidation ValidateResult(ChemicalCompositionInLadle spec)
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

        public virtual MaterialQuantityValidation MatValidationResult(PourStandard _pourStd)
        {
            var val = new MaterialQuantityValidation();

            val.IsOk_Inoculant = IsBetween(_pourStd.Inoculant - _pourStd.InoculantTol, _pourStd.Inoculant + _pourStd.InoculantTol, Inoculant);
            val.IsOk_WireInoculant = IsBetween(_pourStd.WiredInoc - _pourStd.WiredInocTol, _pourStd.WiredInoc + _pourStd.WiredInocTol, WireInoculant);
            val.IsOk_Magnesium = IsBetween(_pourStd.Magnesium - _pourStd.MagnesiumTol, _pourStd.Magnesium + _pourStd.MagnesiumTol, Magnesium);
            val.IsOk_WireMagnesium = IsBetween(_pourStd.WiredMg - _pourStd.WiredMgTol, _pourStd.WiredMg + _pourStd.WiredMgTol, WireMagnesium);
            val.IsOk_Copper = IsBetween(_pourStd.Cu - _pourStd.CuTol, _pourStd.Cu + _pourStd.CuTol, Copper);
            val.IsOk_Tin = IsBetween(_pourStd.Sn - _pourStd.SnTol, _pourStd.Sn + _pourStd.SnTol, Tin);
            val.IsOk_FeedTemp = IsBetween(_pourStd.FeedTemp - _pourStd.FeddTempTol, _pourStd.FeedTemp + _pourStd.FeddTempTol, FeedTemp);
            val.IsOk_Chill = IsBetween(null, _pourStd.ChillMax, Chill);

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
