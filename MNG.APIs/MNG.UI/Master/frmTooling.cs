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
    public partial class frmTooling : Form
    {
        private Client _client;
        private Tooling _data = new Tooling();

        public Tooling SelectedItem = new Tooling();
        public event EventHandler<CTPEventArg> CodeChanged;

        public FormMode Mode { get; set; }

        public void ToolEnable() => pnTool.Show();
        public void ToolDisable() => pnTool.Hide();
        public void MainEnable() => pnMain.Show();
        public void MainDisable() => pnMain.Hide();
        public void SetWidth(int width) => this.Width = width;
        public void EnableViewMode() => Mode = FormMode.Displaying;
        public void EnableEditMode() => Mode = FormMode.Editing;
        public void EnableCreateMode() => Mode = FormMode.Adding;
        public void ItemBrowseEnable() => btnItemBrowse.Show();
        public void ItemBrowseDisable() => btnItemBrowse.Hide();
        public void ToolBarEnable() => pnToolBar.Show();
        public void ToolBarDisable() => pnToolBar.Hide();
        public void EnableGroupHeader() => pnGroupHeader.Show();
        public void DisableGroupHeader() => pnGroupHeader.Hide();

        public Tooling Data
        {
            get { return _data; }
            set
            {
                _data = value;
                toolingBindingSource.DataSource = _data;
            }
        }

        public frmTooling()
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        public frmTooling(List<Tooling> _items)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_items.Count != 0)
                toolingBindingSource.DataSource = _items;
        }

        public frmTooling(Tooling _item)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_item != null)
                toolingBindingSource.DataSource = _item;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Tooling();

            frmTooling fAddItem = new frmTooling(newItem);

            fAddItem.EnableCreateMode();
            fAddItem.EnableGroupHeader();
            fAddItem.ToolDisable();
            fAddItem.MainDisable();
            fAddItem.ItemBrowseDisable();
            fAddItem.StartPosition = FormStartPosition.Manual;
            fAddItem.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fAddItem.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PostToolingAsync(fAddItem.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("Tooling Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var items = await _client.GetToolingAllAsync();
                toolingBindingSource.DataSource = items;
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var item = toolingBindingSource.Current as Tooling;

            frmTooling fUpdate = new frmTooling(item);

            fUpdate.EnableEditMode();
            fUpdate.ToolDisable();
            fUpdate.DisableGroupHeader();
            fUpdate.MainDisable();
            fUpdate.ItemBrowseDisable();
            fUpdate.StartPosition = FormStartPosition.Manual;
            fUpdate.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fUpdate.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutToolingAsync(fUpdate.SelectedItem.Code, fUpdate.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var items = await _client.GetToolingAllAsync();
                    toolingBindingSource.DataSource = items;

                    return;
                }

                MessageBox.Show("Tooling saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolingBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = toolingBindingSource.Current as Tooling;

            if (SelectedItem == null)
                return;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            toolingBindingSource.EndEdit();
            SelectedItem = toolingBindingSource.Current as Tooling;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
                return;

            var result = MessageBox.Show($"Do you want to delete {SelectedItem.Code}?\nThe Entire Data Lot No will be deleted", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _client.DeleteToolingAsync(SelectedItem.Code);
                    MessageBox.Show($"{SelectedItem.Code} has been delete", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var _toolings = (await _client.GetToolingAllAsync()).OrderByDescending(x => x.Code).ToList();
                    toolingBindingSource.DataSource = _toolings;
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private async void btnItemBrowse_Click(object sender, EventArgs e)
        {
            var items = (await _client.GetToolingAllAsync()).ToList();

            frmTooling _form = new frmTooling(items);

            _form.EnableViewMode();
            _form.ToolDisable();
            _form.MainEnable();
            _form.ItemBrowseDisable();
            _form.DisableGroupHeader();
            _form.StartPosition = FormStartPosition.Manual;
            _form.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = _form.ShowDialog();

            if (result == DialogResult.OK)
            {
                toolingBindingSource.DataSource = _form.SelectedItem;
            }
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            var arg = new CTPEventArg();
            arg.Code = codeTextBox.Text;

            CodeChanged?.Invoke(this, arg);
        }

        private async void dateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string newId = "";
            var date = $"{dateDateTimePicker.Value.ToString("yy")}{dateDateTimePicker.Value.ToString("MM")}" +
                $"{dateDateTimePicker.Value.ToString("dd")}";

            var id = (await _client.GetToolingAllAsync()).Where(x => x.Code.Contains(date)).ToList().LastOrDefault();

            if (id == null)
            {
                newId = $"TL-{date}-01";
            }
            else
            {
                var c = Convert.ToInt32(id.Code.Substring(10,2)) + 1;
                newId = $"TL-{date}-{c.ToString("00")}";
            }

            codeTextBox.Text = newId;
            toolingBindingSource.EndEdit();
        }


    }
}
