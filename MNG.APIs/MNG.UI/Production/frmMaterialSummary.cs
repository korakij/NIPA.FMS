using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class frmMaterialSummary : Form
    {
        private List<Charging> _chargings;
        private List<Kanban> _kanbans;

        private Client _client;

        public event EventHandler<MatSummaryEventArgs> MatSumUpated;

        public frmMaterialSummary()
        {
            InitializeComponent();
        }

        private void frmMaterialSummary_Load(object sender, EventArgs e)
        {
            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        public void SummaryUpdate(object sender, MeltingEventArgs e)
        {
            E_LotNoChanged(this, e);
        }

        public async void E_LotNoChanged(object sender, MeltingEventArgs e)
        {
            if (e.LotNos == null)
            {
                ClearUI();
                return;
            }

            _chargings = (await _client.GetChargingsByLotNoAsync(e.LotNos.Code)).OrderByDescending(x => x.ChargeNo).ToList();
            _kanbans = (await _client.GetKanbansByLotNoAsync(e.LotNos.Code)).OrderByDescending(x => x.Code).ToList();

            if (_chargings.Count == 0)
            {
                ClearUI();
                return;
            }

            UpdateMatSummary(_chargings, _kanbans);
        }

        private void UpdateMatSummary(List<Charging> _c, List<Kanban> _k)
        {
            
            MaterialSummary MatSum = new MaterialSummary(_c, _k);

            tbSummarySS.Text = MatSum.SS.Value.ToString("#,##0.0");
            tbSummaryRS.Text = MatSum.RS.Value.ToString("#,##0.0");
            tbSummaryPIGFC.Text = MatSum.PigFC.Value.ToString("#,##0.0");
            tbSummaryPIGFCD.Text = MatSum.PigFCD.Value.ToString("#,##0.0");
            tbSummaryCFC.Text = MatSum.C_FC.Value.ToString("#,##0.0");
            tbSummaryCFCD.Text = MatSum.C_FCD.Value.ToString("#,##0.0");
            tbSummarySi.Text = MatSum.Fe_Si.Value.ToString("#,##0.0");
            tbSummaryMn.Text = MatSum.Fe_Mn.Value.ToString("#,##0.0");
            tbSummaryCr.Text = MatSum.HC_Cr.Value.ToString("#,##0.0");
            tbSummaryMo.Text = MatSum.Fe_Mo.Value.ToString("#,##0.0");
            tbSummaryNi.Text = MatSum.Fe_Ni.Value.ToString("#,##0.0");
            tbMatSummary.Text = MatSum.MatSummary.Value.ToString("#,##0.0");

            tbPouringSummary.Text = MatSum.Pouring.Value.ToString("#,##0.0");
            tbFCDSummary.Text = MatSum.PouringFCD.Value.ToString("#,##0.0");
            tbFCSummary.Text = MatSum.PouringFC.Value.ToString("#,##0.0");

            tbRemainWeight.Text = MatSum.Remained.Value.ToString("#,##0.0");
            tbStartTime.Text = MatSum.StartTime.Value.ToString("dd/MM/yy HH:mm");
            tbStopTime.Text = MatSum.StopTime.Value.ToString("dd/MM/yy HH:mm");
            tbIntervalHr.Text = MatSum.Interval.Value.TotalHours.ToString("#0.0");
            tbIntervalMin.Text = MatSum.Interval.Value.Minutes.ToString("#0.0");

            var matSum = new MatSummaryEventArgs();
            matSum.MatSum = MatSum;

            MatSumUpated?.Invoke(this, matSum);
        }

        private void ClearUI()
        {
            tbSummarySS.Text = "-";
            tbSummaryRS.Text = "-";
            tbSummaryPIGFC.Text = "-";
            tbSummaryPIGFCD.Text = "-";
            tbSummaryCFC.Text = "-";
            tbSummaryCFCD.Text = "-";
            tbSummarySi.Text = "-";
            tbSummaryMn.Text = "-";
            tbSummaryCr.Text = "-";
            tbSummaryMo.Text = "-";
            tbSummaryNi.Text = "-";
            tbMatSummary.Text = "-";

            tbPouringSummary.Text = "-";
            tbFCDSummary.Text = "-";
            tbFCSummary.Text = "-";

            tbRemainWeight.Text = "-";
            tbStartTime.Text = "-";
            tbStopTime.Text = "-";
            tbIntervalHr.Text = "-";
            tbIntervalMin.Text = "-";
        }
    }
}
