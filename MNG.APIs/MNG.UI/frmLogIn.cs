using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MNG.UI
{
    public partial class frmLogIn : Form
    {
        private Client _client;
        private int timeout;
        private string status;
        public User User { get; set; }
        public frmLogIn()
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
            status = "";
        }

        public async void LogOn(string name, string password)
        {
            try
            {
                User = await _client.LogInAsync(name, password);
                status = "OK";
                return;
            }
            catch (Exception ex)
            {
                User = null;
                status = "Error";
                return;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            timer1.Start();          
            status = "";
            timeout = 0;
            LogOn(tbxName.Text, tbxPassword.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeout++;

            if (status == "OK")
            {
                Close();
                timer1.Stop();
            }
            else if (status == "Error")
            {
                lblText.ForeColor = Color.Red;
                lblText.Text = "User name or Password is wrong.";
                timer1.Stop();
            }

            if (timeout >= 15)
            {
                timer1.Stop();
                lblText.Text = "LogIn timeout";
            }
        }

        private void tbxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnLogIn_Click(null, null);
            }
        }
    }
}
