using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class frmSingleMelt : Form
    {
        public FormName fmName;
        private bool IsFirst = true;
        DateTime firstTime;

        public frmLotNo fLotNo;
        public frmMaterial fAddMat;
        public frmTestChem fTestChem;
        public frmTapping fTapping;
        private Client _client;

        public string Furnace { get; set; }
        public bool Active { get; set; }

        private FormMode Mode { get; set; }

        public frmSingleMelt(string _furnace)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            Furnace = _furnace;
        }

        private async void frmSingleMelt_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            var fur = new Furnace();

            if (Furnace.Length != 0)
                fur = await _client.GetFurnaceByIdAsync(Furnace);

            frmMaterialSummary fMatSummary = new frmMaterialSummary();
            fMatSummary.TopLevel = false;
            pnSummary.Controls.Add(fMatSummary);
            fMatSummary.BringToFront();
            fMatSummary.Dock = DockStyle.Fill;
            fMatSummary.Show();

            fLotNo = new frmLotNo(fur);
            fLotNo.DisableLotUpdatedTimer();
            fLotNo.TopLevel = false;
            pnLotNo.Controls.Add(fLotNo);
            fLotNo.BringToFront();
            fLotNo.Dock = DockStyle.Fill;
            fLotNo.Show();

            fAddMat = new frmMaterial();
            fAddMat.TopLevel = false;
            this.pnCharging.Controls.Add(fAddMat);
            fAddMat.BringToFront();
            fAddMat.Dock = DockStyle.Fill;
            fAddMat.Show();

            fTestChem = new frmTestChem();
            fTestChem.DisableToolBar();
            fTestChem.EnableDGV();
            fTestChem.EnablePrint();
            fTestChem.DisableElement();
            fTestChem.DisableTestsTimer();
            fTestChem.EnableResultsTimer();
            fTestChem.TopLevel = false;
            pnChemInFur.Controls.Add(fTestChem);
            fTestChem.BringToFront();
            fTestChem.Dock = DockStyle.Fill;
            fTestChem.Show();

            fTapping = new frmTapping();
            fTapping.DisableToolBar();
            fTapping.EnableDGV();
            fTapping.EnablePrint();
            fTapping.DisableToolBar();
            fTapping.DisableProductBrowse();
            fTapping.DisableReadMeter();
            fTapping.EnablePnDetails();
            fTapping.DisableBtnTapTime();
            fTapping.EnableTapTimer();
            fTapping.DisableTestTimer();
            fTapping.EnableFilByTest();

            fTapping.TopLevel = false;
            pnTapping.Controls.Add(fTapping);
            fTapping.BringToFront();
            fTapping.Dock = DockStyle.Fill;
            fTapping.Show();

            fLotNo.LotNoChanged += fAddMat.E_LotNoChanged;
            fLotNo.LotNoChanged += fMatSummary.E_LotNoChanged;
            fLotNo.LotNoChanged += fTapping.LotNoChanged;

            fAddMat.ChargeNoChanged += fTestChem.ChargeNoChange;
            fTestChem.TestNoChanged += fTapping.TestNoChanged;

            fAddMat.SummaryUpdate += fMatSummary.SummaryUpdate;

            fLotNo.FormSelected += this.FormSelected;
            fAddMat.FormSelected += this.FormSelected;
            fTestChem.FormSelected += this.FormSelected;
            fTapping.FormSelected += this.FormSelected;

            fTapping.SummaryUpdate += fMatSummary.SummaryUpdate;
            fMatSummary.MatSumUpated += fAddMat.MatSumUpdated;

            fTestChem.StatusUpdate += FTestChem_StatusUpdate;
        }

        private void FTestChem_StatusUpdate(object sender, StatusUpdateEventArgs e)
        {
            string status = "   สถานะ : " + e.Status;
            tbxStatusBar.Text = status;
        }

        private void FormSelected(object sender, FormEventArgs e)
        {
            fmName = e.Name;
            switch (fmName)
            {
                case FormName.frmLotNo:
                    fLotNo.FormEnableSelection();
                    fAddMat.FormDisableSelection();
                    fTestChem.FormDisableSelection();
                    fTapping.FormDisableSelection();
                    break;
                case FormName.frmMaterial:
                    fLotNo.FormDisableSelection();
                    fAddMat.FormEnableSelection();
                    fTestChem.FormDisableSelection();
                    fTapping.FormDisableSelection();
                    break;
                case FormName.frmTestChem:
                    fLotNo.FormDisableSelection();
                    fAddMat.FormDisableSelection();
                    fTestChem.FormEnableSelection();
                    fTapping.FormDisableSelection();
                    break;
                case FormName.frmTapping:
                    fLotNo.FormDisableSelection();
                    fAddMat.FormDisableSelection();
                    fTestChem.FormDisableSelection();
                    fTapping.FormEnableSelection();
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            TimeSpan interval;

            if (IsFirst == true)
            {
                firstTime = time;
                IsFirst = false;
            }
            else
            {
                //lbTime.Text = time.ToString("HH:mm:ss");
                //maxTempTimeTextBox.Text = time.ToString("HH:mm:ss");
                interval = time - firstTime;
                //tbDuration.Text = $"{interval.Hours.ToString("00")}:{interval.Minutes.ToString("00")}:{interval.Seconds.ToString("00")}";
            }
        }
    }
}
