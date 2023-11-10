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
    public partial class frmQAProc : Form
    {
        private bool IsFirst = true;
        DateTime firstTime;

        private frmQAPanel fQAPanel1;
        private frmQAPanel fQAPanel2;
        private frmQAPanel fQAPanelAll;

        private Client _client;

        private FormMode Mode { get; set; }

        public frmQAProc()
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
            var fm = ActiveMdiChild as frmQAPanel;
            switch (fm.fmName)
            {
                case FormName.frmQA:
                    fm.fQA.EditItem();
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmQAPanel;

            switch (fm.fmName)
            {
                case FormName.frmQA:
                    fm.fQA.DeletedItem();
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

            if (fQAPanel1 == null || fQAPanel1.IsDisposed)
            {
                fQAPanel1 = new frmQAPanel("1");
                fQAPanel1.MdiParent = this;
                fQAPanel1.TopLevel = false;
                fQAPanel1.BringToFront();
                fQAPanel1.Dock = DockStyle.Fill;
                fQAPanel1.Show();
            }

            fQAPanel1.BringToFront();
        }

        private void btnL2_Click(object sender, EventArgs e)
        {
            btnL1.ForeColor = Color.Black;
            btnL2.ForeColor = Color.White;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fQAPanel2 == null || fQAPanel2.IsDisposed)
            {    
                fQAPanel2 = new frmQAPanel("2");
                fQAPanel2.MdiParent = this;
                fQAPanel2.TopLevel = false;
                fQAPanel2.BringToFront();
                fQAPanel2.Dock = DockStyle.Fill;
                fQAPanel2.Show();
            }

            fQAPanel2.BringToFront();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnL1.ForeColor = Color.Black;
            btnL2.ForeColor = Color.Black;
            btnL3.ForeColor = Color.Black;
            btnAll.ForeColor = Color.White;
            pnCRUD.Hide();

            if (fQAPanelAll == null || fQAPanelAll.IsDisposed)
            {
                fQAPanelAll = new frmQAPanel("");
                fQAPanelAll.MdiParent = this;
                fQAPanelAll.TopLevel = false;
                fQAPanelAll.BringToFront();
                fQAPanelAll.Dock = DockStyle.Fill;
                fQAPanelAll.Show();
            }

            fQAPanelAll.BringToFront();
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
