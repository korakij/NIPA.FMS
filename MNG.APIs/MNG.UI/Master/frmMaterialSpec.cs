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
    public partial class frmMaterialSpec : Form
    {
        private Client _client;
        private MaterialSpecification _data = new MaterialSpecification();

        public MaterialSpecification SelectedItem = new MaterialSpecification();
        public event EventHandler<CTPEventArg> MatCodeChanged;

        public FormMode Mode { get; set; }

        public void ToolEnable() => pnTool.Show();
        public void ToolDisable() => pnTool.Hide();
        public void MainEnable() => pnMain.Show();
        public void MainDiable() => pnMain.Hide();
        public void SetWidth(int width) => this.Width = width;
        public void ToolBarEnable() => pnToolBar.Show();
        public void ToolBarDisable() => pnToolBar.Hide();
        public void EnableMatType() => pnGroupHeader.Show();
        public void DisableMatType() => pnGroupHeader.Hide();
        public void EnableEditMode() => EditMode(true);
        public void DisableEditMode() => EditMode(false);
        public void ItemBrowseEnable() => btnItemBrowse.Show();
        public void ItemBrowseDisable() => btnItemBrowse.Hide();
        public void EnableGroupHeader() => pnGroupHeader.Show();
        public void DisableGroupHeader() => pnGroupHeader.Hide();

        public MaterialSpecification Data
        {
            get { return _data; }
            set
            {
                _data = value;
                if (_data == null)
                    materialSpecificationBindingSource.Clear();
                else
                    materialSpecificationBindingSource.DataSource = _data;
            }
        }

        public frmMaterialSpec()
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }
        public frmMaterialSpec(List<MaterialSpecification> _items)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_items.Count != 0)
                materialSpecificationBindingSource.DataSource = _items;
        }

        public frmMaterialSpec(MaterialSpecification _item)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_item != null)
                materialSpecificationBindingSource.DataSource = _item;
        }

        private void EditMode(bool IsEdit)
        {
            descriptionTextBox.ReadOnly = !IsEdit;
            hbMaxTextBox.ReadOnly = !IsEdit;
            hbMinTextBox.ReadOnly = !IsEdit;
            sizeTensileMaxTextBox.ReadOnly = !IsEdit;
            sizeTensileMinTextBox.ReadOnly = !IsEdit;
            tensileMaxTextBox.ReadOnly = !IsEdit;
            tensileMinTextBox.ReadOnly = !IsEdit;
            elongationMaxTextBox.ReadOnly = !IsEdit;
            elongationMinTextBox.ReadOnly = !IsEdit;
            yieldMaxTextBox.ReadOnly = !IsEdit;
            yieldMinTextBox.ReadOnly = !IsEdit;
            graphiteAMaxTextBox.ReadOnly = !IsEdit;
            graphiteAMinTextBox.ReadOnly = !IsEdit;
            nodularityMaxTextBox.ReadOnly = !IsEdit;
            nodularityMinTextBox.ReadOnly = !IsEdit;
            noduleCountTextBox.ReadOnly = !IsEdit;
            sizeMaxTextBox.ReadOnly = !IsEdit;
            sizeMinTextBox.ReadOnly = !IsEdit;
            ferriteMaxTextBox.ReadOnly = !IsEdit;
            ferriteMinTextBox.ReadOnly = !IsEdit;
            pearliteMaxTextBox.ReadOnly = !IsEdit;
            pearliteMinTextBox.ReadOnly = !IsEdit;
            cementiteMaxTextBox.ReadOnly = !IsEdit;
            cementiteMinTextBox.ReadOnly = !IsEdit;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new MaterialSpecification();
            var cnt = (await _client.GetMaterialSpecificationAllAsync()).ToList().Count();

            frmMaterialSpec fAddItem = new frmMaterialSpec(newItem);

            fAddItem.EnableEditMode();
            fAddItem.EnableMatType();
            fAddItem.ToolDisable();
            fAddItem.MainDiable();
            fAddItem.ItemBrowseDisable();
            fAddItem.StartPosition = FormStartPosition.Manual;
            fAddItem.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fAddItem.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PostMaterialSpecificationAsync(fAddItem.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("Material Spec Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var items = await _client.GetMaterialSpecificationAllAsync();
                materialSpecificationBindingSource.DataSource = items;
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var item = materialSpecificationBindingSource.Current as MaterialSpecification;

            frmMaterialSpec fUpdate = new frmMaterialSpec(item);

            fUpdate.EnableEditMode();
            fUpdate.DisableMatType();
            fUpdate.ToolDisable();
            fUpdate.MainDiable();
            fUpdate.ItemBrowseDisable();
            fUpdate.StartPosition = FormStartPosition.Manual;
            fUpdate.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fUpdate.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutMaterialSpecificationAsync(fUpdate.SelectedItem.Code, fUpdate.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Material saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void itemDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOk_Click(this, EventArgs.Empty);
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            materialSpecificationBindingSource.EndEdit();
            SelectedItem = materialSpecificationBindingSource.Current as MaterialSpecification;
        }

        private void materialSpecificationBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = materialSpecificationBindingSource.Current as MaterialSpecification;

            if (SelectedItem == null)
                return;
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

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            var arg = new CTPEventArg();
            arg.Code = codeTextBox.Text;
            MatCodeChanged?.Invoke(this, arg);
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newId = "";
            var id = (await _client.GetMaterialSpecificationAllAsync()).Where(x => x.Code.Contains(comboBox1.Text)).ToList().LastOrDefault();

            if (id == null)
            {
                newId = $"{comboBox1.Text}-01";
            }
            else
            {
                newId = $"{comboBox1.Text}-{(Convert.ToInt32(id.Code.Substring(comboBox1.Text.Length + 1)) + 1).ToString("00")}";
            }

            codeTextBox.Text = newId;
            materialSpecificationBindingSource.EndEdit();
        }

        private async void btnItemBrowse_Click(object sender, EventArgs e)
        {
            var items = (await _client.GetMaterialSpecificationAllAsync()).ToList();

            frmMaterialSpec _form = new frmMaterialSpec(items);

            _form.EnableEditMode();
            _form.ToolDisable();
            _form.MainEnable();
            _form.ItemBrowseDisable();
            _form.StartPosition = FormStartPosition.Manual;
            _form.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = _form.ShowDialog();

            if (result == DialogResult.OK)
            {
                materialSpecificationBindingSource.DataSource = _form.SelectedItem;
            }
        }
    }
}
