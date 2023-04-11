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
    public partial class frmMaterialType : Form
    {
        private Client _client;
        public Material SelectedItem;

        public void ToolEnable() => pnTool.Show();
        public void ToolDisable() => pnTool.Hide();
        public void MainEnable() => pnMain.Show();
        public void MainDiable() => pnMain.Hide();
        public void BrowseEnable() => pnBrowse.Show();
        public void BrowseDiable() => pnBrowse.Hide();
        public void SetWidth(int width) => this.Width = width;
        public void EnableMatType() => pnMatType.Show();
        public void DisableMatType() => pnMatType.Hide();
        public void EnableEditMode() => descriptionTextBox.ReadOnly = false;
        public void DisableEditMode() => descriptionTextBox.ReadOnly = true;

        public frmMaterialType(List<Material> _materials)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            SelectedItem = new Material();
            materialBindingSource.DataSource = _materials;
        }

        public frmMaterialType(Material _materials)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            SelectedItem = new Material();

            if (_materials != null)
                materialBindingSource.DataSource = _materials;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Material();
            frmMaterialType fAddMat = new frmMaterialType(newItem);

            fAddMat.EnableEditMode();
            fAddMat.EnableMatType();
            fAddMat.ToolDisable();
            fAddMat.MainDiable();
            fAddMat.BrowseEnable();
            fAddMat.EnableEditMode();
            fAddMat.SetWidth(545);
            fAddMat.StartPosition = FormStartPosition.Manual;
            fAddMat.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fAddMat.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PostMaterialAsync(fAddMat.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("Material Added", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var material = materialBindingSource.Current as Material;

            frmMaterialType fUpdate = new frmMaterialType(material);

            fUpdate.DisableMatType();
            fUpdate.ToolDisable();
            fUpdate.MainDiable();
            fUpdate.BrowseEnable();
            fUpdate.EnableEditMode();
            fUpdate.StartPosition = FormStartPosition.Manual;
            fUpdate.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fUpdate.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutMaterialAsync(fUpdate.SelectedItem.Code, fUpdate.SelectedItem);
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
            materialBindingSource.EndEdit();
            SelectedItem = materialBindingSource.Current as Material;
        }

        private void materialBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = materialBindingSource.Current as Material;
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

        private void materialDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOk_Click(this, EventArgs.Empty);
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newId = "";
            var id = (await _client.GetMaterialAllAsync()).Where(x => x.Code.Contains(comboBox1.Text)).ToList().LastOrDefault();

            if (id == null)
            {
                newId = $"{comboBox1.Text}-01";
            }
            else
            {
                newId = $"{comboBox1.Text}-{(Convert.ToInt32(id.Code.Substring(comboBox1.Text.Length + 1)) + 1).ToString("00")}";
            }

            codeTextBox.Text = newId;
        }
    }
}
