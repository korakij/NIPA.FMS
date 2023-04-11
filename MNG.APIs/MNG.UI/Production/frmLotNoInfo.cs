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
    public partial class frmLotNoInfo : Form
    {
        private string _lotNo;
        private string _shift;
        private string _furnace;
        private DateTime _date;

        public string LotNo
        {
            get => _lotNo;
            set
            {
                _lotNo = value;
                tbLotNo.Text = _lotNo;
            }
        }
        public string Shift
        {
            get => _shift;
            set
            {
                _shift = value;
                cboShift.Text = _shift;
            }
        }
        public string Furnace
        {
            get => _furnace;
            set
            {
                _furnace = value;
                cboFurnace.Text = _furnace;
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                dateTimePicker1.Value = _date;
            }
        }

        public frmLotNoInfo()
        {
            InitializeComponent();

            cboShift.Items.Add("A");
            cboShift.Items.Add("B");
            cboFurnace.Items.Add("A");
            cboFurnace.Items.Add("B");
            cboFurnace.Items.Add("C");
            cboFurnace.Items.Add("D");
            cboFurnace.Items.Add("E");
        }

        private void frmCreateLotNo_Load(object sender, EventArgs e)
        {
            tbLotNo.Text = dateTimePicker1.Value.ToString("yyMMdd");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CreateLot();
        }

        private void cboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateLot();
        }

        private void cboFurnace_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateLot();
        }

        private void CreateLot()
        {
            Date = dateTimePicker1.Value;
            Shift = cboShift.SelectedItem?.ToString();
            Furnace = cboFurnace.SelectedItem?.ToString();
            LotNo = Date.ToString("yyMMdd") + Shift + Furnace;

            tbLotNo.Text = LotNo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool mouseDown = false;
        private Point lastLocation;

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDown == false && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //contextMenuStrip1.Show(this.DesktopLocation.X + e.X, this.DesktopLocation.Y + e.Y);	
            }
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - lastLocation.X + e.X, this.DesktopLocation.Y - lastLocation.Y + e.Y);
                this.Update();
            }
        }

        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
