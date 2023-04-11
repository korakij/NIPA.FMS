using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MNG.UI.Production
{
    public partial class frmInspectionProc : Form
    {
        private bool IsFirst = true;
        DateTime firstTime;

        private frmInspectionPanel fInspectionPanel1;
        private frmInspectionPanel fInspectionPanel2;
        private frmInspectionPanel fInspectionPanelAll;

        private Client _client;

        private FormMode Mode { get; set; }

        public frmInspectionProc()
        {
            InitializeComponent();

            btnL1.ForeColor = Color.Black;
            btnL2.ForeColor = Color.Black;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.Black;
        }

        public void EnableViewMode() => Mode = FormMode.Displaying;
        public void EnableEditMode() => Mode = FormMode.Editing;
        public void EnableCreateMode() => Mode = FormMode.Adding;
        public void EnableToolBar() => pnCRUD.Show();
        public void DisableToolbar() => pnCRUD.Hide();
        public void EnableNavigatorTool() => pnNavigator.Show();
        public void DiableNavigatorTool() => pnNavigator.Hide();
        public void EnableExitTool() => pnExit.Show();
        public void DisableExitTool() => pnExit.Hide();
        public void EnableSaveExitTool() => pnSaveExit.Show();
        public void DisableSaveExitTool() => pnSaveExit.Hide();

        public int Count => chargingBindingSource.Count;
        public int Current => chargingBindingSource.Position;

        private void frmCharging_Load(object sender, EventArgs e)
        {
            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmInspectionPanel;
            switch (fm.fmName)
            {
                case FormName.frmInspection:
                    fm.fInspection.EditItem();
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmInspectionPanel;

            switch (fm.fmName)
            {
                case FormName.frmInspection:
                    fm.fInspection.DeletedItem();
                    break;
            }
        }

        private void btnL1_Click(object sender, EventArgs e)
        {
            btnL1.ForeColor = Color.White;
            btnL2.ForeColor = Color.Black;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fInspectionPanel1 == null || fInspectionPanel1.IsDisposed)
            {
                fInspectionPanel1 = new frmInspectionPanel("1");
                fInspectionPanel1.MdiParent = this;
                fInspectionPanel1.TopLevel = false;
                fInspectionPanel1.BringToFront();
                fInspectionPanel1.Dock = DockStyle.Fill;
                fInspectionPanel1.Show();
            }

            fInspectionPanel1.BringToFront();
        }

        private void btnL2_Click(object sender, EventArgs e)
        {
            btnL1.ForeColor = Color.Black;
            btnL2.ForeColor = Color.White;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fInspectionPanel2 == null || fInspectionPanel2.IsDisposed)
            {
                fInspectionPanel2 = new frmInspectionPanel("2");
                fInspectionPanel2.MdiParent = this;
                fInspectionPanel2.TopLevel = false;
                fInspectionPanel2.BringToFront();
                fInspectionPanel2.Dock = DockStyle.Fill;
                fInspectionPanel2.Show();
            }

            fInspectionPanel2.BringToFront();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnL1.ForeColor = Color.Black;
            btnL2.ForeColor = Color.Black;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.White;
            pnCRUD.Hide();

            if (fInspectionPanelAll == null || fInspectionPanelAll.IsDisposed)
            {
                fInspectionPanelAll = new frmInspectionPanel("");
                fInspectionPanelAll.MdiParent = this;
                fInspectionPanelAll.TopLevel = false;
                fInspectionPanelAll.BringToFront();
                fInspectionPanelAll.Dock = DockStyle.Fill;
                fInspectionPanelAll.Show();
            }

            fInspectionPanelAll.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
