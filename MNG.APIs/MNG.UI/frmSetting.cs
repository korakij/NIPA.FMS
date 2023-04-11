using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Web;

namespace MNG.UI
{
    public partial class frmSetting : Form
    {
        private Client _client;
        private Setting SavedItem;

        public static string Path { get; set; }
        public static int RefreshRate { get; set; }
        public static string ResultPath { get; set; }
        public static string MeterIP { get; set; }

        public frmSetting(List<Setting> settings)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            settingBindingSource.DataSource = settings;
        }

        public frmSetting(Setting setting)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);
            SavedItem = new Setting();

            settingBindingSource.DataSource = setting;
        }

        public void EnableToolBar() => pnToolBar.Show();
        public void DisableToolBar() => pnToolBar.Hide();
        public void EnableSave() => btnSave.Show();
        public void DisableSave() => btnSave.Hide();
        public void EnableBtnSelect() => btnSelect.Show();
        public void DisableBtnSelect() => btnSelect.Hide();
        public void EnablePnCRUD() => pnCRUD.Show();
        public void DisablePnCRUD() => pnCRUD.Hide();
        public void EnablePnDgv() => pnDgv.Show();
        public void DisablePnDgv() => pnDgv.Hide();
        public void EnablePnDetails() => pnDetails.Show();
        public void DisablePnDetails() => pnDetails.Hide();

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var setting = new Setting();
            var lastSetting = (await _client.GetSettingAllAsync()).LastOrDefault();

            if (lastSetting == null)
            {
                setting.Code = $"S-01";
            }

            var newNo = Convert.ToInt32(lastSetting.Code.Replace("S-", "")) + 1;
            setting.Code = $"S-{newNo.ToString("00")}";

            frmSetting fSetting = new frmSetting(setting);
            fSetting.DisablePnCRUD();
            fSetting.EnableToolBar();
            fSetting.DisablePnDgv();
            fSetting.EnablePnDetails();
            fSetting.EnableSave();
            fSetting.DisableBtnSelect();
            fSetting.SetReadOnly(false);
            fSetting.StartPosition = FormStartPosition.Manual;
            var p = new Point(this.Location.X + this.Width + 20, this.Location.Y);
            fSetting.Location = p;

            var result = fSetting.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PostSettingAsync(fSetting.SavedItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("New Setting Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var s = (await _client.GetSettingAllAsync()).ToList();
                settingBindingSource.DataSource = s;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            var setting = settingBindingSource.Current as Setting;
            frmSetting fSetting = new frmSetting(setting);

            fSetting.DisablePnCRUD();
            fSetting.EnableToolBar();
            fSetting.DisablePnDgv();
            fSetting.EnablePnDetails();
            fSetting.EnableSave();
            fSetting.DisableBtnSelect();
            fSetting.SetReadOnly(false);
            fSetting.StartPosition = FormStartPosition.Manual;
            var p = new Point(this.Location.X + this.Width + 20, this.Location.Y);
            fSetting.Location = p;

            var result = fSetting.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutSettingAsync(fSetting.SavedItem.Code, fSetting.SavedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var s = (await _client.GetSettingAllAsync()).ToList();
                settingBindingSource.DataSource = s;
            }
        }

        private async void btnSelect_Click(object sender, EventArgs e)
        {
            var selectedItem = (await _client.GetSettingAllAsync()).ToList().Find(x => x.IsSelected == true);
            if (selectedItem != null)
            {
                selectedItem.IsSelected = false;

                try
                {
                    await _client.PutSettingAsync(selectedItem.Code, selectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            var item = settingBindingSource.Current as Setting;
            item.IsSelected = true;

            try
            {
                await _client.PutSettingAsync(item.Code, item);
                MessageBox.Show($"System Profile has been changed to {item.Code}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.API_URL = item.ApI_URL;
            Properties.Settings.Default.Refresh_Rate = Convert.ToInt32(item.RefreshRate);
            Properties.Settings.Default.Result_Path = item.Result_Path;
            Properties.Settings.Default.PMeter1 = item.PowerMeterIP;

            Properties.Settings.Default.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavedItem = settingBindingSource.Current as Setting;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetReadOnly(bool _isRead)
        {
            apI_URLTextBox.ReadOnly = _isRead;
            pathTextBox.ReadOnly = _isRead;
            result_PathTextBox.ReadOnly = _isRead;
            powerMeterIPTextBox.ReadOnly = _isRead;
            refreshRateTextBox.ReadOnly = _isRead;
        }

        private bool mouseDown = false;
        private Point lastLocation;
        private void lbHeader_MouseDown(object sender, MouseEventArgs e)
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

        private void lbHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - lastLocation.X + e.X, this.DesktopLocation.Y - lastLocation.Y + e.Y);
                this.Update();
            }
        }

        private void lbHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void settingBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var item = settingBindingSource.Current as Setting;

            if (item.IsSelected == true)
                btnSelect.Enabled = false;
            else
                btnSelect.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = @".\config.json";
            string jsonString = File.ReadAllText(fileName);
            Config configObj = JsonSerializer.Deserialize<Config>(jsonString);

            MessageBox.Show(configObj.APIURL + "\n" + configObj.ChemResultPath + "\n" + configObj.RefreshRate + "\n" + configObj.PMeterIP1);
        }
    }
}
