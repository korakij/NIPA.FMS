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
    public partial class frmMoldStd : Form
    {
        private Client _client;
        private MoldStandard _data = new MoldStandard();

        public MoldStandard SelectedItem = new MoldStandard();
        public event EventHandler<CTPEventArg> MoldStdCodeChanged;

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

        public MoldStandard Data
        {
            get { return _data; }
            set
            {
                _data = value;
                moldStandardBindingSource.DataSource = _data;
            }
        }

        public frmMoldStd()
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        public frmMoldStd(List<MoldStandard> _items)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_items.Count != 0)
                moldStandardBindingSource.DataSource = _items;
        }

        public frmMoldStd(MoldStandard _item)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_item != null)
                moldStandardBindingSource.DataSource = _item;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new MoldStandard();
            var last = (await _client.GetMoldStandardAllAsync()).Where(x => x.Code.Contains("MD")).LastOrDefault();

            if (last == null)
            {
                newItem.Code = $"MD-00";
            }
            else
            {
                var newCode = Convert.ToInt32(last.Code.ToString().Substring(3,2)) + 1;
                newItem.Code = $"MD-{newCode.ToString("00")}";
            }

            frmMoldStd fAddItem = new frmMoldStd(newItem);

            fAddItem.EnableCreateMode();
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
                    await _client.PostMoldStandardAsync(fAddItem.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("Molding Std. Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var items = await _client.GetMoldStandardAllAsync();
                moldStandardBindingSource.DataSource = items;
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var item = moldStandardBindingSource.Current as MoldStandard;

            frmMoldStd fUpdate = new frmMoldStd(item);

            fUpdate.EnableEditMode();
            fUpdate.ToolDisable();
            fUpdate.MainDisable();
            fUpdate.ItemBrowseDisable();
            fUpdate.StartPosition = FormStartPosition.Manual;
            fUpdate.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fUpdate.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutMoldStandardAsync(fUpdate.SelectedItem.Code, fUpdate.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var items = await _client.GetMoldStandardAllAsync();
                    moldStandardBindingSource.DataSource = items;

                    return;
                }

                MessageBox.Show("Chem In Ladle saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chemicalCompositionInLadleBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = moldStandardBindingSource.Current as MoldStandard;

            if (SelectedItem == null)
                return;
        }

        private void materialSpecificationDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOk_Click(this, EventArgs.Empty);
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
            moldStandardBindingSource.EndEdit();
            SelectedItem = moldStandardBindingSource.Current as MoldStandard;
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
            var items = (await _client.GetMoldStandardAllAsync()).ToList();

            frmMoldStd _form = new frmMoldStd(items);

            _form.EnableViewMode();
            _form.ToolDisable();
            _form.MainEnable();
            _form.ItemBrowseDisable();
            _form.StartPosition = FormStartPosition.Manual;
            _form.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = _form.ShowDialog();

            if (result == DialogResult.OK)
            {
                moldStandardBindingSource.DataSource = _form.SelectedItem;
            }
        }

        private void codeTextBox1_TextChanged(object sender, EventArgs e)
        {
            var arg = new CTPEventArg();
            arg.Code = codeTextBox1.Text;

            MoldStdCodeChanged?.Invoke(this, arg);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
