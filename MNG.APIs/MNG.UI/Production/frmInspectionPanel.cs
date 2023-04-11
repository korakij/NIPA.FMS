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
    public partial class frmInspectionPanel : Form
    {
        private Client _client;
        private string Line;

        public FormName fmName;
        public frmLotNo fLotNo;
        public frmPouringIntoMold fPouring;
        public frmInspection fInspection;

        public frmInspectionPanel()
        {
            InitializeComponent();
        }

        public frmInspectionPanel(string _line)
        {
            InitializeComponent();

            Line = _line;
        }

        private async void frmInspectionPanel_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            var fur = await _client.GetFurnaceByIdAsync("All");

            fLotNo = new frmLotNo(fur);
            fLotNo.TopLevel = false;
            pnLotNo.Controls.Add(fLotNo);
            fLotNo.BringToFront();
            fLotNo.Dock = DockStyle.Fill;
            fLotNo.Show();

            fPouring = new frmPouringIntoMold(Line);
            fPouring.EnablePrint();
            fPouring.DisableToolBar();
            fPouring.DisableProductBrowse();
            fPouring.DisableFirstMoldTime();
            fPouring.DisableLastMoldTime();
            fPouring.DisableDataEntryDetails();
            fPouring.DisablePouringTimer();

            fPouring.TopLevel = false;
            pnPouring.Controls.Add(fPouring);
            fPouring.BringToFront();
            fPouring.Dock = DockStyle.Fill;
            fPouring.Show();

            fInspection = new frmInspection();
            fInspection.DisableToolBar();

            fInspection.TopLevel = false;
            pnInspection.Controls.Add(fInspection);
            fInspection.BringToFront();
            fInspection.Dock = DockStyle.Fill;
            fInspection.Show();

            fLotNo.LotNoChanged += fPouring.LotNoChanged;
            fInspection.FormSelected += this.FormSelected;
            fPouring.PouringIntoMoldChanged += fInspection.PouringIntoMoldChanged;
        }

        private void FormSelected(object sender, FormEventArgs e)
        {
            fmName = e.Name;
            switch (fmName)
            {
                case FormName.frmInspection:
                    fInspection.FormEnableSelection();
                    break;
            }
        }
    }
}
