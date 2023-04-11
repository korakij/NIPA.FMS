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
    public partial class frmPouring : Form
    {
        private Client _client;
        private string Line;

        public FormName fmName;
        public frmLotNo fLotNo;
        public frmTapping fTapping;
        public frmPouringIntoMold fPouring;

        public frmPouring()
        {
            InitializeComponent();
        }

        public frmPouring(string _line)
        {
            InitializeComponent();

            Line = _line;
        }

        private async void frmPouring_Load(object sender, EventArgs e)
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

            fTapping = new frmTapping();
            fTapping.DisablePrint();
            fTapping.DisableBtnTapTime();
            fTapping.DisableToolBar();
            fTapping.DisableProductBrowse();
            fTapping.DisableReadMeter();
            fTapping.DisablePnNavigator();
            fTapping.EnablePnDetails();
            fTapping.EnableTapTimer();
            fTapping.DisableTestTimer();

            fTapping.TopLevel = false;
            pnKanban.Controls.Add(fTapping);
            fTapping.BringToFront();
            fTapping.Dock = DockStyle.Fill;
            fTapping.Show();

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

            fLotNo.LotNoChanged += fTapping.LotNoChangedTapping;
            fTapping.KanbanNoChanged += fPouring.KanbanNoChanged;
            fLotNo.LotNoChanged += fPouring.LotNoChanged;

            fPouring.FormSelected += this.FormSelected;
        }

        private void FormSelected(object sender, FormEventArgs e)
        {
            fmName = e.Name;
            switch (fmName)
            {
                case FormName.frmPouringIntoMold:
                    fPouring.FormEnableSelection();
                    break;
            }
        }
    }
}
