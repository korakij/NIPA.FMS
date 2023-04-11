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
    public partial class frmShotBlastStd : Form
    {
        private Client _client;
        public ShotBlastStandard _data = new ShotBlastStandard();

        public ShotBlastStandard SelectedItem = new ShotBlastStandard();
        public event EventHandler<CTPEventArg> CodeChanged;

        public FormMode Mode { get; set; }

        public void ToolEnable() => pnTool.Show();
        public void ToolDisable() => pnTool.Hide();
        public void MainEnable() => pnMain.Show();
        public void MainDiable() => pnMain.Hide();
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

        public ShotBlastStandard Data
        {
            get { return _data; }
            set
            {
                _data = value;
                shotBlastStandardBindingSource.DataSource = _data;
            }
        }

        public frmShotBlastStd()
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        public frmShotBlastStd(List<ShotBlastStandard> _items)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_items.Count != 0)
                shotBlastStandardBindingSource.DataSource = _items;
        }

        public frmShotBlastStd(ShotBlastStandard _item)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_item != null)
                shotBlastStandardBindingSource.DataSource = _item;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new ShotBlastStandard();
            frmShotBlastStd fAddItem = new frmShotBlastStd(newItem);

            fAddItem.EnableCreateMode();
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
                    await _client.PostShotBlastStandardAsync(fAddItem.SelectedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("ShotBlast Std. Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var items = await _client.GetShotBlastStandardAllAsync();
                shotBlastStandardBindingSource.DataSource = items;
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var item = shotBlastStandardBindingSource.Current as ShotBlastStandard;

            frmShotBlastStd fUpdate = new frmShotBlastStd(item);

            fUpdate.EnableEditMode();
            fUpdate.ToolDisable();
            fUpdate.MainDiable();
            fUpdate.DisableGroupHeader();
            fUpdate.ItemBrowseDisable();
            fUpdate.StartPosition = FormStartPosition.Manual;
            fUpdate.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fUpdate.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutShotBlastStandardAsync(fUpdate.SelectedItem.Code, fUpdate.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    var items = await _client.GetShotBlastStandardAllAsync();
                    shotBlastStandardBindingSource.DataSource = items;

                    return;
                }

                MessageBox.Show("Chem In Ladle saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void shotBlastStandardBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedItem = shotBlastStandardBindingSource.Current as ShotBlastStandard;

            if (SelectedItem == null)
                return;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            shotBlastStandardBindingSource.EndEdit();
            SelectedItem = shotBlastStandardBindingSource.Current as ShotBlastStandard;
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
            var items = (await _client.GetShotBlastStandardAllAsync()).ToList();

            frmShotBlastStd _form = new frmShotBlastStd(items);

            _form.EnableViewMode();
            _form.ToolDisable();
            _form.MainEnable();
            _form.ItemBrowseDisable();
            _form.StartPosition = FormStartPosition.Manual;
            _form.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = _form.ShowDialog();

            if (result == DialogResult.OK)
            {
                shotBlastStandardBindingSource.DataSource = _form.SelectedItem;
            }
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            var arg = new CTPEventArg();
            arg.Code = codeTextBox.Text;

            CodeChanged?.Invoke(this, arg);
        }

        private async void cboGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mtype, newId;

            if (cboGroup.Text == "Apron")
                mtype = "AP";
            else
                mtype = "HG";


            var id = (await _client.GetShotBlastStandardAllAsync()).Where(x => x.Code.Contains($"SB-{mtype}")).ToList().LastOrDefault();

            if (id == null)
            {
                newId = $"SB-{mtype}-01";
            }
            else
            {
                newId = $"SB-{mtype}-{(Convert.ToInt32(id.Code.Substring($"SB-{mtype}-".Length)) + 1).ToString("00")}";
            }

            codeTextBox.Text = newId;
            shotBlastStandardBindingSource.EndEdit();

        }
    }
}
