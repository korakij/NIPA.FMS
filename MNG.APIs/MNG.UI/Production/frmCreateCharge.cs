using ASRS.UI;
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
    public partial class frmCreateCharge : Form
    {
        private Client _client;

        public Charging ChargeItem { get; set; }

        public frmCreateCharge(Charging _chargeItem)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            ChargeItem = new Charging();
            ChargeItem = _chargeItem;
            chargingBindingSource.DataSource = ChargeItem;
        }

        private void frmCreateCharge_Load(object sender, EventArgs e)
        {
            timer1.Start();
            chargeTimeTextBox.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chargeTimeTextBox.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            chargingBindingSource.EndEdit();
            ChargeItem = chargingBindingSource.Current as Charging;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            chargingBindingSource.CancelEdit();

            this.Close();
        }
    }
}
