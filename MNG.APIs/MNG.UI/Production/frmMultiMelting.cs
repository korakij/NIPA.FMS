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
    public partial class frmMultiMelting : Form
    {
        private bool IsFirst = true;
        DateTime firstTime;

        private frmSingleMelt fSingleMeltA;
        private frmSingleMelt fSingleMeltB;
        private frmSingleMelt fSingleMeltC;
        private frmSingleMelt fSingleMeltD;
        private frmSingleMelt fSingleMeltE;
        private frmSingleMelt fSingleMeltAll;

        private Client _client;

        private FormMode Mode { get; set; }

        public frmMultiMelting()
        {
            InitializeComponent();

            btnFurA.ForeColor = Color.Black;
            btnFurB.ForeColor = Color.Black;
            btnFurC.ForeColor = Color.Black;
            btnFurD.ForeColor = Color.Black;
            btnFurE.ForeColor = Color.Black;
            btnFurAll.ForeColor = Color.Black;
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
            var fm = ActiveMdiChild as frmSingleMelt;
            switch (fm.fmName)
            {
                case FormName.frmLotNo:
                    fm.fLotNo.EditItem();
                    break;
                case FormName.frmMaterial:
                    fm.fAddMat.EditItem();
                    break;
                case FormName.frmTestChem:
                    fm.fTestChem.EditItemHeader();
                    break;
                case FormName.frmTapping:
                    fm.fTapping.EditItemHeader();
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmSingleMelt;

            switch (fm.fmName)
            {
                case FormName.frmLotNo:
                    fm.fLotNo.CreateItem();
                    break;
                case FormName.frmMaterial:
                    fm.fAddMat.CreateItem();
                    break;
                case FormName.frmTestChem:
                    fm.fTestChem.CreateItem();
                    break;
                case FormName.frmTapping:
                    fm.fTapping.CreateItem();
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmSingleMelt;

            switch (fm.fmName)
            {
                case FormName.frmLotNo:
                    fm.fLotNo.DeleteItem();
                    break;
                case FormName.frmMaterial:
                    fm.fAddMat.DeleteItem();
                    break;
                case FormName.frmTestChem:
                    fm.fTestChem.DeleteItem();
                    break;
                case FormName.frmTapping:
                    fm.fTapping.DeleteItem();
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var fm = ActiveMdiChild as frmSingleMelt;

            switch (fm.fmName)
            {
                case FormName.frmLotNo:
                    fm.fLotNo.Export();
                    break;
                case FormName.frmMaterial:
                    fm.fAddMat.Export();
                    break;
                case FormName.frmTestChem:
                    fm.fTestChem.Export();
                    break;
                case FormName.frmTapping:
                    fm.fTapping.Export();
                    break;
            }
        }

        private void btnFurA_Click(object sender, EventArgs e)
        {
            btnFurA.ForeColor = Color.White;
            btnFurB.ForeColor = Color.Black;
            btnFurC.ForeColor = Color.Black;
            btnFurD.ForeColor = Color.Black;
            btnFurE.ForeColor = Color.Black;
            btnFurAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fSingleMeltA == null || fSingleMeltA.IsDisposed)
            {
                fSingleMeltA = new frmSingleMelt("A");
                fSingleMeltA.MdiParent = this;
                fSingleMeltA.TopLevel = false;
                fSingleMeltA.BringToFront();
                fSingleMeltA.Dock = DockStyle.Fill;
                fSingleMeltA.Show();
            }

            fSingleMeltA.BringToFront();
        }

        private void btnFurB_Click(object sender, EventArgs e)
        {
            btnFurA.ForeColor = Color.Black;
            btnFurB.ForeColor = Color.White;
            btnFurC.ForeColor = Color.Black;
            btnFurD.ForeColor = Color.Black;
            btnFurE.ForeColor = Color.Black;
            btnFurAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fSingleMeltB == null || fSingleMeltB.IsDisposed)
            {
                fSingleMeltB = new frmSingleMelt("B");
                fSingleMeltB.MdiParent = this;
                fSingleMeltB.TopLevel = false;
                fSingleMeltB.BringToFront();
                fSingleMeltB.Dock = DockStyle.Fill;
                fSingleMeltB.Show();
            }

            fSingleMeltB.BringToFront();
        }

        private void btnFurC_Click(object sender, EventArgs e)
        {
            btnFurA.ForeColor = Color.Black;
            btnFurB.ForeColor = Color.Black;
            btnFurC.ForeColor = Color.White;
            btnFurD.ForeColor = Color.Black;
            btnFurE.ForeColor = Color.Black;
            btnFurAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fSingleMeltC == null || fSingleMeltC.IsDisposed)
            {              
                fSingleMeltC = new frmSingleMelt("C");
                fSingleMeltC.MdiParent = this;
                fSingleMeltC.TopLevel = false;
                fSingleMeltC.BringToFront();
                fSingleMeltC.Dock = DockStyle.Fill;
                fSingleMeltC.Show();
            }

            fSingleMeltC.BringToFront();
        }

        private void btnFurD_Click(object sender, EventArgs e)
        {
            btnFurA.ForeColor = Color.Black;
            btnFurB.ForeColor = Color.Black;
            btnFurC.ForeColor = Color.Black;
            btnFurD.ForeColor = Color.White;
            btnFurE.ForeColor = Color.Black;
            btnFurAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fSingleMeltD == null || fSingleMeltC.IsDisposed)
            {
                fSingleMeltD = new frmSingleMelt("D");
                fSingleMeltD.MdiParent = this;
                fSingleMeltD.TopLevel = false;
                fSingleMeltD.BringToFront();
                fSingleMeltD.Dock = DockStyle.Fill;
                fSingleMeltD.Show();
            }

            fSingleMeltD.BringToFront();
        }

        private void btnFurE_Click(object sender, EventArgs e)
        {
            btnFurA.ForeColor = Color.Black;
            btnFurB.ForeColor = Color.Black;
            btnFurC.ForeColor = Color.Black;
            btnFurD.ForeColor = Color.Black;
            btnFurE.ForeColor = Color.White;
            btnFurAll.ForeColor = Color.Black;
            pnCRUD.Show();

            if (fSingleMeltE == null || fSingleMeltE.IsDisposed)
            {
                fSingleMeltE = new frmSingleMelt("E");
                fSingleMeltE.MdiParent = this;
                fSingleMeltE.TopLevel = false;
                fSingleMeltE.BringToFront();
                fSingleMeltE.Dock = DockStyle.Fill;
                fSingleMeltE.Show();
            }

            fSingleMeltE.BringToFront();
        }

        private void btnFurAll_Click(object sender, EventArgs e)
        {
            btnFurA.ForeColor = Color.Black;
            btnFurB.ForeColor = Color.Black;
            btnFurC.ForeColor = Color.Black;
            btnFurD.ForeColor = Color.Black;
            btnFurE.ForeColor = Color.Black;
            btnFurAll.ForeColor = Color.White;
            pnCRUD.Hide();

            if (fSingleMeltAll == null || fSingleMeltAll.IsDisposed)
            {
                fSingleMeltAll = new frmSingleMelt("");
                fSingleMeltAll.MdiParent = this;
                fSingleMeltAll.TopLevel = false;
                fSingleMeltAll.BringToFront();
                fSingleMeltAll.Dock = DockStyle.Fill;
                fSingleMeltAll.Show();
            }

            fSingleMeltAll.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

    }
}
