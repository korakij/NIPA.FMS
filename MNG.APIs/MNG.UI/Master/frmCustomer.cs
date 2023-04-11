using BarcodeLib;
using MNG.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASRS.UI
{
    public partial class frmCustomer : Form
    {
        private Client _client;
        public Customer SelectedItem;
        public FormMode Mode { get; set; }

        public void ToolEnable() => pnTool.Show();
        public void ToolDisable() => pnTool.Hide();
        public void MainEnable() => pnMain.Show();
        public void MainDiable() => pnMain.Hide();
        public void BrowseEnable() => pnBrowse.Show();
        public void BrowseDiable() => pnBrowse.Hide();
        public void SetWidth(int width) => this.Width = width;
        public void EnableEditMode() => EditMode(true);
        public void DisableEditMode() => EditMode(false);

        public frmCustomer(List<Customer> _customers)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            SelectedItem = new Customer();
            customerBindingSource.DataSource = _customers;
        }

        public frmCustomer(Customer _customers)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            SelectedItem = new Customer();

            if (_customers != null)
                customerBindingSource.DataSource = _customers;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private void EditMode(bool IsEdit)
        {
            nameTextBox.ReadOnly = !IsEdit;
            addressTextBox.ReadOnly = !IsEdit;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Customer();
            var last = (await _client.GetCustomerAllAsync()).LastOrDefault().CustomerCode.Substring(3);
            var newId = Convert.ToInt32(last) + 1;
            var newCode = $"CL-{newId.ToString("0000")}";
            newItem.CustomerCode = newCode;

            frmCustomer fAddCust = new frmCustomer(newItem);

            fAddCust.EnableEditMode();
            fAddCust.ToolDisable();
            fAddCust.MainDiable();
            fAddCust.BrowseEnable();
            fAddCust.SetWidth(545);
            fAddCust.StartPosition = FormStartPosition.Manual;
            fAddCust.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fAddCust.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PostCustomerAsync(fAddCust.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("Customer Added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var customer = customerBindingSource.Current as Customer;

            frmCustomer fUpdate = new frmCustomer(customer);

            fUpdate.EnableEditMode();
            fUpdate.ToolDisable();
            fUpdate.MainDiable();
            fUpdate.BrowseEnable();
            fUpdate.StartPosition = FormStartPosition.Manual;
            fUpdate.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fUpdate.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutCustomerAsync(Convert.ToInt32(fUpdate.SelectedItem.Id), fUpdate.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Material saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            customerBindingSource.EndEdit();
            SelectedItem = customerBindingSource.Current as Customer;
        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = customerBindingSource.Current as Customer;
        }

        private bool mouseDown = false;
        private Point lastLocation;

        private void label5_MouseDown_1(object sender, MouseEventArgs e)
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

        private void label5_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - lastLocation.X + e.X, this.DesktopLocation.Y - lastLocation.Y + e.Y);
                this.Update();
            }
        }

        private void label5_MouseUp_1(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void customerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOk_Click(this, EventArgs.Empty);
        }
    }
}
