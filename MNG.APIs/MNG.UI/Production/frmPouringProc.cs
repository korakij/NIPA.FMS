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
    public partial class frmPouringProc : Form
    {
        private bool IsFirst = true;
        DateTime firstTime;

        private frmPouring fPouringL1;
        private frmPouring fPouringL2;
        private frmPouring fPouringAll;

        private Client _client;

        private FormMode Mode { get; set; }

        public frmPouringProc()
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
            var fm = ActiveMdiChild as frmPouring;
            switch (fm.fmName)
            {
                case FormName.frmPouringIntoMold:
                    fm.fPouring.EditItem();
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmPouring;

            switch (fm.fmName)
            {
                case FormName.frmPouringIntoMold:
                    fm.fPouring.CreateItem();
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmPouring;

            switch (fm.fmName)
            {
                case FormName.frmPouringIntoMold:
                    fm.fPouring.DeletedItem();
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

            if (fPouringL1 == null || fPouringL1.IsDisposed)
            {
                fPouringL1 = new frmPouring("1");
                fPouringL1.MdiParent = this;
                fPouringL1.TopLevel = false;
                fPouringL1.BringToFront();
                fPouringL1.Dock = DockStyle.Fill;
                fPouringL1.Show();
            }

            fPouringL1.BringToFront();
        }

        private void btnL2_Click(object sender, EventArgs e)
        {
            btnL1.ForeColor = Color.Black;
            btnL2.ForeColor = Color.White;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fPouringL2 == null || fPouringL2.IsDisposed)
            {
                fPouringL2 = new frmPouring("2");
                fPouringL2.MdiParent = this;
                fPouringL2.TopLevel = false;
                fPouringL2.BringToFront();
                fPouringL2.Dock = DockStyle.Fill;
                fPouringL2.Show();
            }

            fPouringL2.BringToFront();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnL1.ForeColor = Color.Black;
            btnL2.ForeColor = Color.Black;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.White;
            pnCRUD.Hide();

            if (fPouringAll == null || fPouringAll.IsDisposed)
            {
                fPouringAll = new frmPouring("");
                fPouringAll.MdiParent = this;
                fPouringAll.TopLevel = false;
                fPouringAll.BringToFront();
                fPouringAll.Dock = DockStyle.Fill;
                fPouringAll.Show();
            }

            fPouringAll.BringToFront();
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
