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
    public partial class frmQAPanel : Form
    {
        private Client _client;
        private string Line;

        public FormName fmName;
        public frmLotNo fLotNo;
        public frmPouringIntoMold fPouring;
        public frmQA fQA;

        public frmQAPanel()
        {
            InitializeComponent();
        }

        public frmQAPanel(string _line)
        {
            InitializeComponent();

            Line = _line;
        }


        private async void frmQAPanel_Load(object sender, EventArgs e)
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

            fQA = new frmQA();
            fQA.DisableToolBar();

            fQA.TopLevel = false;
            pnInspection.Controls.Add(fQA);
            fQA.BringToFront();
            fQA.Dock = DockStyle.Fill;
            fQA.Show();

            fLotNo.LotNoChanged += fPouring.LotNoChanged;
            fQA.FormSelected += this.FormSelected;
            fPouring.PouringIntoMoldChanged += fQA.PouringIntoMoldChanged;
        }

        private void FormSelected(object sender, FormEventArgs e)
        {
            fmName = e.Name;
            switch (fmName)
            {
                case FormName.frmQA:
                    fQA.FormEnableSelection();
                    break;
            }
        }
    }
}
