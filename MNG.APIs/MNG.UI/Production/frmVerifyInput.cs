using ASRS.UI;
using NPOI.OpenXmlFormats.Vml;
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
    public partial class frmVerifyInput : Form
    {
        private Client _client;
        private string _line;

        public string Code { get; set; }

        public void EnableGenPouringCode() => btnGenPouringCode.Show();
        public void DisableGenPouringCode() => btnGenPouringCode.Hide();
        public void EnableGenTestCode() => btnGenTestCode.Show();
        public void DisableGenTestCode() => btnGenTestCode.Hide();

        public frmVerifyInput(string _lbInput, string _lbOutput)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            //var x = Screen.PrimaryScreen.Bounds.Width;
            //var y = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(x, y);

            tbInput.Select();
            lbInput.Text = _lbInput;
            lbOutput.Text = _lbOutput;
        }

        public frmVerifyInput(string _lbInput, string _lbOutput, string Line)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            //var x = Screen.PrimaryScreen.Bounds.Width;
            //var y = Screen.PrimaryScreen.Bounds.Height;
            //this.Location = new Point(x, y);

            tbInput.Select();
            lbInput.Text = _lbInput;
            lbOutput.Text = _lbOutput;
            _line = Line;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            Code = tbOutput.Text;
        }

        private async void btnGenTestCode_Click(object sender, EventArgs e)
        {
            var p = new TestChemicalComposition();

            try
            {
                p = (await _client.GetTestChemicalCompositionByIdAsync(tbInput.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Test Code No Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (p == null)
            {
                MessageBox.Show("Test Code No Found!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                tbOutput.Text = p.Code;
            }
        }

        private async void btnGenPouringCode_Click(object sender, EventArgs e)
        {
            int cnt = 0;

            if (tbInput.Text == "")
                return;

            var p = (await _client.GetPouringByKanbanAsync(tbInput.Text)).LastOrDefault();

            if (p == null)
                cnt = 0;
            else
            {
                var s = p.Code.Substring(16, 2);
                cnt = Convert.ToInt32(s);
            }

            cnt++;

            if(_line == "")
                tbOutput.Text = $"P-{tbInput.Text}-{cnt.ToString("00")}";
            else
                tbOutput.Text = $"P{_line}-{tbInput.Text}-{cnt.ToString("00")}";
        }
    }
}
