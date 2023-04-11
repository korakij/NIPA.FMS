using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI
{
    public partial class TestChemicalComposition
    {
        public virtual ChemicalCompositionValidation ValidateResult(ChemicalCompositionInFurnace spec)
        {
            var val = new ChemicalCompositionValidation();

            val.IsOk_CCE = IsBetween(spec.CceMax, spec.CceMax, Result.Cce);
            val.IsOk_C = IsBetween(spec.CMin, spec.CMax, Result.C);
            val.IsOk_Si = IsBetween(spec.SiMin, spec.SiMax, Result.Si);
            val.IsOk_Mn = IsBetween(spec.MnMin, spec.MnMax, Result.Mn);
            val.IsOk_Mg = IsBetween(spec.MgMin, spec.MgMax, Result.Mg);
            val.IsOk_S = IsBetween(spec.SMin, spec.SMax, Result.S);
            val.IsOk_Al = IsBetween(spec.AlMin, spec.AlMax, Result.Al);
            val.IsOk_Cu = IsBetween(spec.CuMax, spec.CuMin, Result.Cu);
            val.IsOk_Sn = IsBetween(spec.SnMax, spec.SnMin, Result.Sn);
            val.IsOk_Cr = IsBetween(spec.CrMax, spec.CrMin, Result.Cr);
            val.IsOk_P = IsBetween(spec.PMax, spec.PMin, Result.P);
            val.IsOk_Mo = IsBetween(spec.MoMax, spec.MoMin, Result.Mo);
            val.IsOk_Ni = IsBetween(spec.NiMax, spec.NiMin, Result.Ni);
            val.IsOk_V = IsBetween(spec.VMax, spec.VMin, Result.V);
            val.IsOk_Ti = IsBetween(spec.TiMax, spec.TiMin, Result.Ti);
            val.IsOk_Te = IsBetween(spec.TeMax, spec.TeMin, Result.Te);

            return val;
        }

        public bool IsBetween(double? min, double? max, double? value)
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
