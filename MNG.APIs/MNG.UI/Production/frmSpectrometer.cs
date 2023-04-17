using MNG.UI.Production;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI
{
    public partial class frmSpectrometer : Form
    {
        private Client _client;

        private FormName fmName;
        private frmLotNo fLotNo;
        private frmTestChem fTestChem;
        private frmTapping fTapping;

        public frmSpectrometer()
        {
            InitializeComponent();
        }

        private async void frmSpectrometer_Load(object sender, EventArgs e)
        {
            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            var fur = await _client.GetFurnaceByIdAsync("All");

            fLotNo = new frmLotNo(fur);
            fLotNo.EnableLotUpdatedTimer();
            fLotNo.Show();
            fLotNo.TopLevel = false;
            pnLotNo.Controls.Add(fLotNo);
            fLotNo.BringToFront();
            fLotNo.Dock = DockStyle.Fill;

            fTestChem = new frmTestChem();
            fTestChem.DisableToolBar();
            fTestChem.EnableDGV();
            fTestChem.DisablePrint();
            fTestChem.DisableElement();
            fTestChem.EnableTestsTimer();
            fTestChem.DisableResultsTimer();
            fTestChem.Show();
            fTestChem.TopLevel = false;
            pnTestChem.Controls.Add(fTestChem);
            fTestChem.BringToFront();
            fTestChem.Dock = DockStyle.Fill;

            fTapping = new frmTapping();
            fTapping.EnablePrint();
            fTapping.DisableToolBar();
            fTapping.DisableProductBrowse();
            fTapping.DisableReadMeter();
            fTapping.DisableBtnTapTime();
            fTapping.DisablePnNavigator();
            fTapping.EnablePnDetails();
            fTapping.EnableTapTimer();
            fTapping.DisableTestTimer();
            fTapping.EnableFilByTest();

            fTapping.TopLevel = false;
            pnKanban.Controls.Add(fTapping);
            fTapping.BringToFront();
            fTapping.Dock = DockStyle.Fill;
            fTapping.Show();

            //fLotNo.LotNoChanged += fMaterial.E_LotNoChanged;
            fLotNo.LotNoChanged += fTapping.LotNoChanged;
            fLotNo.LotNoChanged += fTestChem.LotNoChanged;
            fTestChem.TestNoChanged += fTapping.TestNoChanged;

            fTestChem.FormSelected += this.FormSelected;
            fTapping.FormSelected += this.FormSelected;
            //fMaterial.ChargeNoChanged += fTestChem.ChargeNoChange;
        }

        private void KanbanFormOnCreating(object sender, MeltingEventArgs e)
        {
            
        }

        private void FormSelected(object sender, FormEventArgs e)
        {
            fmName = e.Name;
            switch (fmName)
            {
                case FormName.frmTestChem:
                    fLotNo.FormDisableSelection();
                    fTestChem.FormEnableSelection();
                    fTapping.FormDisableSelection();
                    break;
                case FormName.frmTapping:
                    fLotNo.FormDisableSelection();
                    fTestChem.FormDisableSelection();
                    fTapping.FormEnableSelection();
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            switch (fmName)
            {
                case FormName.frmTestChem:
                    fTestChem.EditItem();
                    break;
                case FormName.frmTapping:
                    fTapping.EditChemItem();
                    break;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
