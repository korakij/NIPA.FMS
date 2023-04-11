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
    public partial class frmMeltStd : Form
    {
        private Client _client;
        private MeltStandard _data = new MeltStandard();

        public MeltStandard SelectedItem = new MeltStandard();
        public event EventHandler<CTPEventArg> MeltStdCodeChanged;

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

        public MeltStandard Data
        {
            get { return _data; }
            set
            {
                _data = value;
                meltStandardBindingSource.DataSource = _data;
            }
        }

        public frmMeltStd()
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        public frmMeltStd(List<MeltStandard> _items)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_items.Count != 0)
                meltStandardBindingSource.DataSource = _items;
        }

        public frmMeltStd(MeltStandard _item)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_item != null)
                meltStandardBindingSource.DataSource = _item;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new MeltStandard();

            frmMeltStd fAddItem = new frmMeltStd(newItem);

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
                    await _client.PostMeltStandardAsync(fAddItem.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("Melt Std. Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var items = await _client.GetMeltStandardAllAsync();
                meltStandardBindingSource.DataSource = items;
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var item = meltStandardBindingSource.Current as MeltStandard;

            frmMeltStd fUpdate = new frmMeltStd(item);

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
                    await _client.PutMeltStandardAsync(fUpdate.SelectedItem.Code, fUpdate.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var items = await _client.GetMeltStandardAllAsync();
                    meltStandardBindingSource.DataSource = items;

                    return;
                }

                MessageBox.Show("Melt Std. saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void shotBlastStandardBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = meltStandardBindingSource.Current as MeltStandard;

            if (SelectedItem == null)
                return;
        }

        //private async void tbSearch_TextChanged(object sender, EventArgs e)
        //{
        //    //    var items = await _client.GetProductAllAsync();
        //    //    var searchItem = items.Where(x => x.Id.ToString().ToLower().Contains(tbSearch.Text.ToLower()) || 
        //    //    x.Name.ToLower().Contains(tbSearch.Text.ToLower()));

        //    //    if (searchItem.Count() == 0)
        //    //    {
        //    //        itemBindingSource.Clear();
        //    //        return;
        //    //    }

        //    //    itemBindingSource.DataSource = searchItem;
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            meltStandardBindingSource.EndEdit();
            SelectedItem = meltStandardBindingSource.Current as MeltStandard;
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

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
            var items = (await _client.GetMeltStandardAllAsync()).ToList();

            frmMeltStd _form = new frmMeltStd(items);

            _form.EnableViewMode();
            _form.ToolDisable();
            _form.MainEnable();
            _form.ItemBrowseDisable();
            _form.StartPosition = FormStartPosition.Manual;
            _form.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = _form.ShowDialog();

            if (result == DialogResult.OK)
            {
                meltStandardBindingSource.DataSource = _form.SelectedItem;
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void codeTextBox1_TextChanged(object sender, EventArgs e)
        {
            var arg = new CTPEventArg();
            arg.Code = codeTextBox1.Text;

            MeltStdCodeChanged?.Invoke(this, arg);
        }

        private async void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newId = "";
            var id = (await _client.GetMeltStandardAllAsync()).Where(x => x.Code.Contains($"ME-{cboGroup.Text}")).ToList().LastOrDefault();

            if (id == null)
            {
                newId = $"ME-{cboGroup.Text}-01";
            }
            else
            {
                newId = $"ME-{cboGroup.Text}-{(Convert.ToInt32(id.Code.Substring($"ME-{cboGroup.Text}".Length + 1)) + 1).ToString("00")}";
            }

            codeTextBox1.Text = newId;
            meltStandardBindingSource.EndEdit();
        }
    }
}
