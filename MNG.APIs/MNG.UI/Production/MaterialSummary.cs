using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI.Production
{
    public class MaterialSummary
    {
        private List<Charging> _chargings;
        private List<Kanban> _kanbans;

        public MaterialSummary()
        {
            _chargings = new List<Charging>();
            _kanbans = new List<Kanban>();
        }

        public MaterialSummary(List<Charging> _c, List<Kanban> _k)
        {
            _chargings = _c;
            _kanbans = _k;
        }

        public double? PigFC => _chargings.Select(x => x.PigFC).Sum();
        public double? PigFCD => _chargings.Select(x => x.PigFCD).Sum();
        public double? RS => _chargings.Select(x => x.Rs).Sum();
        public double? SS => _chargings.Select(x => x.Ss).Sum();

        public double? C_FC => _chargings.Select(x => x.C_FC).Sum();
        public double? C_FCD => _chargings.Select(x => x.C_FCD).Sum();
        public double? Fe_Si => _chargings.Select(x => x.Fe_Si).Sum();
        public double? Fe_Mn => _chargings.Select(x => x.Fe_Mn).Sum();
        public double? HC_Cr => _chargings.Select(x => x.HC_Cr).Sum();
        public double? Fe_Ni => _chargings.Select(x => x.Fe_Ni).Sum();
        public double? Fe_Mo => _chargings.Select(x => x.Fe_Mo).Sum();
        public double? MatSummary => PigFC + PigFCD + RS + SS + C_FC + C_FCD + Fe_Si + Fe_Mn + HC_Cr + Fe_Ni +
            + HC_Cr + Fe_Ni + Fe_Mo;

        public double? Pouring => _kanbans.Select(x => x.Weight).Sum();
        public double? PouringFCD => (_kanbans.Where(x => x.MaterialCode.Contains("FCD")).ToList()).Sum(y => y.Weight);
        public double? PouringFC => Pouring - PouringFCD;

        public double? Remained => MatSummary - Pouring;

        public float? StartKwHr { get; set; }
        public float? MaxTempKwHr { get; set; }

        public DateTime? StartTime => _chargings.FirstOrDefault().ChargeTime;
        public DateTime? StopTime => _chargings.LastOrDefault().ChargeTime;
        public TimeSpan? Interval => StartTime - StopTime;

        public DateTime? MaxTempTime { get; set; }
    }
}
