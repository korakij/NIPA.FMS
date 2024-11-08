﻿using ASRS.UI;
using Org.BouncyCastle.Bcpg.OpenPgp;
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
    public partial class frmPouringIntoMold : Form
    {
        private List<Pouring> _pourings;
        private Client _client;
        private MeltingEventArgs MeltInfo;
        private LotNo CurrentLotNo;
        private Kanban CurrentKanban;
        private Pouring CurrentPouring;
        private Pouring NewPouring;
        private ControlPlan CurrentControlPlan;
        private PourStandard CurrentPourStandard;
        private Product CurrentProduct;
        private Tooling CurrentTooling;
        private LightTower_ChemicalInLader lightChem;
        private bool checkFirstTemp;
        private bool checkLastTemp;
        private int selectedScreen = 0;
        private Point locNow;

        private EasyModbus.ModbusClient mbClient;
        private string PLine;
        public event EventHandler<MeltingEventArgs> PouringNoChanged;
        public event EventHandler<FormEventArgs> FormSelected;
        public event EventHandler<MeltingEventArgs> PouringIntoMoldChanged;
        
        public FormMode Mode { get; set; }

        public frmPouringIntoMold(string _line)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            _pourings = new List<Pouring>();
            MeltInfo = new MeltingEventArgs();
            CurrentLotNo = new LotNo();
            CurrentKanban = new Kanban();
            CurrentControlPlan = new ControlPlan();
            CurrentPouring = new Pouring();
            CurrentPourStandard = new PourStandard();
            CurrentProduct = new Product();
            CurrentTooling = new Tooling();
            PLine = _line;

            //timer1.Interval = frmSetting.RefreshRate;
            //timer1.Start();
        }

        public frmPouringIntoMold(string _line, bool connectLight)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            _pourings = new List<Pouring>();
            MeltInfo = new MeltingEventArgs();
            CurrentLotNo = new LotNo();
            CurrentKanban = new Kanban();
            CurrentControlPlan = new ControlPlan();
            CurrentPouring = new Pouring();
            CurrentPourStandard = new PourStandard();
            CurrentProduct = new Product();
            CurrentTooling = new Tooling();
            PLine = _line;

            //lightChem = new LightTower_ChemicalInLader();
        }

        public frmPouringIntoMold(string _pouringCode, string _kanbanCode, string _pLine)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            Mode = FormMode.Adding;
            NewPouring = new Pouring();
            MeltInfo = new MeltingEventArgs();
            CurrentControlPlan = new ControlPlan();
            CurrentPourStandard = new PourStandard();
            CurrentProduct = new Product();

            NewPouring.Code = _pouringCode;
            NewPouring.KanbanCode = _kanbanCode;
            NewPouring.LineCode = _pLine;
            if(NewPouring.Defect == null)
                NewPouring.Defect = new DefectCause();
            if (NewPouring.QInspect == null)
                NewPouring.QInspect = new QAInspection();

            if (NewPouring.Defect == null)
                NewPouring.Defect = new DefectCause();
            if (NewPouring.QInspect == null)
                NewPouring.QInspect = new QAInspection();

            pouringBindingSource.DataSource = NewPouring;
        }

        public frmPouringIntoMold(Pouring _currentPouring)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            Mode = FormMode.Editing;
            NewPouring = new Pouring();
            NewPouring = _currentPouring;
            this.DisableNoProduct();
            pouringBindingSource.DataSource = NewPouring;
            connectToTemperature();
        }

        public void EnableToolBar() => pnToolBar.Show();
        public void DisableToolBar() => pnToolBar.Hide();
        public void EnableDGV() => pouringDataGridView.Show();
        public void DisableDGV() => pouringDataGridView.Hide();
        public void EnablePrint() => btnPrint.Show();
        public void DisablePrint() => btnPrint.Hide();
        public void EnableProductBrowse() => btnProductBrowse.Show();
        public void DisableProductBrowse() => btnProductBrowse.Hide();
        public void EnableNavigator() => pnNavigator.Show();
        public void DisableNavigator() => pnNavigator.Hide();
        public void EnableDetails() => pnDetails.Show();
        public void DisableDetails() => pnDetails.Hide();
        public void EnableFirstMoldTime() => btnFirstTimeRetrieval.Show();
        public void DisableFirstMoldTime() => btnFirstTimeRetrieval.Hide();
        public void EnableLastMoldTime() => btnLastTimeRetrieval.Show();
        public void DisableLastMoldTime() => btnLastTimeRetrieval.Hide();
        public void EnablePouringTimer() => PouringTimer.Start();
        public void DisablePouringTimer() => PouringTimer.Stop();
        public void DisableNoProduct() => productNoTextBox.Hide();
        public void EnableNoProduct() => productNoTextBox.Show();


        public void EnableDataEntryDetails()
        {
            firstTempTextBox.ReadOnly = false;
            lastTempTextBox.ReadOnly = false;
            noOfPouredMoldTextBox.ReadOnly = false;
        }

        public void DisableDataEntryDetails()
        {
            firstTempTextBox.ReadOnly = true;
            lastTempTextBox.ReadOnly = true;
            noOfPouredMoldTextBox.ReadOnly = true;
        }

        public void FormDisableSelection()
        {
            pnBorderTop.BackColor = Color.White;
            pnBorderBottom.BackColor = Color.White;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        public void FormEnableSelection()
        {
            pnBorderTop.BackColor = Color.MidnightBlue;
            pnBorderBottom.BackColor = Color.MidnightBlue;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.Color.Black;
        }

        private void frmPouringIntoMold_Load(object sender, EventArgs e)
        {
            PouringTimer.Interval = Properties.Settings.Default.Refresh_Rate;
            selectedScreen = Properties.Settings.Default.SelectedScreen;
            var screens = Screen.AllScreens[selectedScreen];
            StartPosition = FormStartPosition.Manual;
            locNow = screens.WorkingArea.Location;
        }

        public async void CreateItem()
        {
            Pouring lastPouring = new Pouring();
            try
            {
                lastPouring = (await _client.GetPouringsByLotNoAsync((CurrentLotNo.Code).Substring(0, 7))).Where(x => x.LineCode == PLine & x.Code.Contains(CurrentLotNo.Code)).LastOrDefault();
            }
            catch (Exception) { }

            if(lastPouring != null && (lastPouring.IsCompleted == false || lastPouring.IsCompleted == null))
            {
                MessageBox.Show($"Last Pouring is not complete ({lastPouring.Code}), Please edit last pouring.", "Last Pouring not complete!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //else
            //{
            //    MessageBox.Show($"{lastPouring.Code}\n{lastPouring.IsCompleted}");
            //}

            frmVerifyInput fVerify = new frmVerifyInput("Kanban Code", "Pouring Code", PLine);
            fVerify.EnableGenPouringCode();
            fVerify.DisableGenTestCode();

            if (fVerify.ShowDialog() != DialogResult.OK)
                return;

            frmPouringIntoMold fPourIntoMold = new frmPouringIntoMold(fVerify.Code, CurrentKanban.Code, PLine);
            fPourIntoMold.StartPosition = FormStartPosition.Manual;
            fPourIntoMold.Location = new Point(locNow.X + 300, locNow.Y + 10);

            fPourIntoMold.DisableDetails();
            fPourIntoMold.Height = 357;

            if (fPourIntoMold.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //if(lightChem != null)
                    //    lightChem.ResultChem((bool)CurrentKanban.IsCompleted, (bool)CurrentKanban.IsPassed, CurrentKanban.Code);
                    await _client.PostPouringAsync(fPourIntoMold.NewPouring);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        _pourings = (await _client.GetPouringsByLotNoAsync((CurrentLotNo.Code).Substring(0, 7))).Where(x => x.LineCode == PLine).OrderByDescending(x => x.Code).ToList();
                        pouringBindingSource.DataSource = _pourings;
                    }
                    else
                    {
                        MessageBox.Show("ERROR " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    pouringBindingSource.ResetBindings(false);
                }
            }
        }

        public async void EditItem()
        {
            CurrentPouring = pouringBindingSource.Current as Pouring;

            if (CurrentPouring == null)
            {
                MessageBox.Show("Unable to Edit Current Pouring", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmPouringIntoMold fPourIntoMold = new frmPouringIntoMold(CurrentPouring);
            fPourIntoMold.StartPosition = FormStartPosition.Manual;
            fPourIntoMold.Location = new Point(locNow.X + 300, locNow.Y + 10);

            fPourIntoMold.Height = 650;

            fPourIntoMold.EnableProductBrowse();
            fPourIntoMold.DisableDGV();
            fPourIntoMold.EnableFirstMoldTime();
            fPourIntoMold.EnableLastMoldTime();
            fPourIntoMold.EnableDataEntryDetails();

            if (fPourIntoMold.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var t = (await _client.GetToolingByIdAsync(CurrentControlPlan.ToolingCode));
                    fPourIntoMold.NewPouring.ProductNo = t.Cavity * fPourIntoMold.NewPouring.NoOfPouredMold;

                    await _client.PutPouringNoAsync(fPourIntoMold.NewPouring.Code, fPourIntoMold.NewPouring, CurrentPourStandard.Code, CurrentTooling.Code);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("ERROR " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    _pourings = (await _client.GetPouringsByLotNoAsync((CurrentLotNo.Code).Substring(0, 7))).Where(x => x.LineCode == PLine).OrderByDescending(x => x.Code).ToList();
                    pouringBindingSource.DataSource = _pourings;
                }
            }
            else
            {
                try
                {
                    _pourings = (await _client.GetPouringsByLotNoAsync((CurrentLotNo.Code).Substring(0, 7))).Where(x => x.LineCode == PLine).OrderByDescending(x => x.Code).ToList();
                }
                catch { }

                pouringBindingSource.DataSource = _pourings;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            pouringBindingSource.EndEdit();
            NewPouring = pouringBindingSource.Current as Pouring;

            try
            {
                NewPouring.ProductCode = Convert.ToInt32(idTextBox.Text);
                NewPouring.LineCode = lineCodeTextBox.Text;
                NewPouring.ProductNo = NewPouring.NoOfPouredMold * (CurrentTooling.Cavity ?? 0);

                TimeSpan duration = (NewPouring.LastMoldTime ?? DateTime.Now) - (NewPouring.FirstMoldTime ?? DateTime.Now);
                var dur = new TimeSpan(duration.Hours, duration.Minutes, duration.Seconds);
                NewPouring.Duration = dur.ToString(@"mm\:ss");
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrected Information!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }

        }

        public async void DeletedItem()
        {
            if (CurrentPouring == null)
                return;

            var result = MessageBox.Show($"Do you want to delete {CurrentPouring.Code}?\nThe Entire Data Test No will be deleted", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _client.DeletePouringAsync(CurrentPouring.Code);
                    MessageBox.Show($"{CurrentPouring.Code} has been delete", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _pourings = (await _client.GetPouringsByLotNoAsync((CurrentLotNo.Code).Substring(0, 7))).Where(x => x.LineCode == PLine).OrderByDescending(x => x.Code).ToList();
                    pouringBindingSource.DataSource = _pourings;
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async void LotNoChanged(Object sender, MeltingEventArgs e)
        {
            if (e.LotNos == null)
            {
                pouringBindingSource.Clear();
                productBindingSource.Clear();
                pourStandardBindingSource.Clear();
                CurrentLotNo = null;

                return;
            }

            CurrentLotNo = e.LotNos;

            try
            {
                _pourings = (await _client.GetPouringsByLotNoAsync((CurrentLotNo.Code).Substring(0, 7))).Where(x => x.LineCode == PLine).OrderByDescending(x => x.Code).ToList();
            }
            catch { }

            if (_pourings.Count == 0)
            {
                pouringBindingSource.Clear();

                return;
            }

            pouringBindingSource.DataSource = _pourings;
        }

        public async void KanbanNoChanged(object sender, MeltingEventArgs e)
        {
            if(e.KanbanNo == null || e.KanbanNo is null)
                return;

            CurrentKanban = e.KanbanNo;

            List<Pouring> p = new List<Pouring>();
            try
            {
                p = (await _client.GetPouringByKanbanAsync(CurrentKanban.Code)).Where(x => x.KanbanCode == CurrentKanban.Code).ToList();
            }
            catch { }

            //pouringBindingSource.DataSource = p;

            for (int i = 0; i < pouringDataGridView.RowCount; i++)
            {
                var index = p.Find(x => x.Code == pouringDataGridView.Rows[i].Cells[0].Value.ToString());

                if (index != null)
                {
                    pouringDataGridView.Rows[i].Selected = true;
                }
                else
                {
                    pouringDataGridView.Rows[i].Selected = false;
                }
            }
        }

        private async void pouringBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (Mode == FormMode.Adding)
                return;

            CurrentPouring = pouringBindingSource.Current as Pouring;

            if (CurrentPouring == null || CurrentPouring.ProductCode == 0)
            {
                productBindingSource.Clear();
                pouringBindingSource.Clear();
                toolingBindingSource.Clear();
                pourStandardBindingSource.Clear();
                tbTotalPcs.Clear();

                return;
            }

            CurrentProduct = (await _client.GetProductByIdAsync(CurrentPouring.ProductCode)) as Product;
            productBindingSource.DataSource = CurrentProduct;

            CurrentControlPlan = (await _client.GetControlPlanByIdAsync(CurrentProduct.ActiveControlPlanId ?? 0));

            CurrentPourStandard = (await _client.GetPouringStandardByIdAsync(CurrentControlPlan.PouringCode));
            pourStandardBindingSource.DataSource = CurrentPourStandard;

            CurrentTooling = (await _client.GetToolingByIdAsync(CurrentControlPlan.ToolingCode));
            toolingBindingSource.DataSource = CurrentTooling;

            var totalPcs = (CurrentTooling.Cavity ?? 0) * (CurrentTooling.NoOfMoldPerLadle ?? 0);
            tbTotalPcs.Text = totalPcs.ToString();

            var meltInfo = new MeltingEventArgs();
            meltInfo.PouringNo = CurrentPouring;

            PouringIntoMoldChanged?.Invoke(this, meltInfo);
            //SetIndicator(CurrentPouring.IsPassed, CurrentPouring.IsCompleted);

            //CurrentPouring.Defect = new DefectCause();
            //MeltInfo.PouringNo = CurrentPouring;
            //PouringNoChanged?.Invoke(this, MeltInfo);
        }

        private void codeTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (codeTextBox1.Text == "")
            {
                pictureBox1.Image = null;
                nameTextBox.Text = "";
                return;
            }

            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = brCode.Draw(codeTextBox1.Text, 20);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var fName = new FormEventArgs();
            fName.Name = FormName.frmPouringIntoMold;

            FormSelected?.Invoke(this, fName);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnProductBrowse_Click(object sender, EventArgs e)
        {
            var products = (await _client.GetProductAllAsync()).Where(x => x.ActiveControlPlanId != null).ToList();
            var _currentKanban = (await _client.GetKanbanByIdAsync(NewPouring.KanbanCode));
            var productInFur = products.Where(x => x.ActiveControlPlanId == _currentKanban.ControlPlanId).FirstOrDefault().Name;

            frmProduct fProduct = new frmProduct(products, productInFur);
            fProduct.ProductBrowseDisable();
            fProduct.ToolDisable();

            var result = fProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                var p = fProduct.SelectedItem;
                var cp = await _client.GetControlPlanByIdAsync(p.ActiveControlPlanId ?? 0);
                var ChemStd = await _client.GetChemicalCompositionInFurnaceByIdAsync(cp.ChemicalCompositionInFurnaceCode);
                var pourStd = await _client.GetPouringStandardByIdAsync(cp.PouringCode);
                CurrentTooling = await _client.GetToolingByIdAsync(cp.ToolingCode);

                productBindingSource.DataSource = p;
                productBindingSource.EndEdit();
                pourStandardBindingSource.DataSource = pourStd;
                toolingBindingSource.DataSource = CurrentTooling;
            }
        }

        private void btnFirstTimeRetrieval_Click(object sender, EventArgs e)
        {
            var cp = pouringBindingSource.Current as Pouring;

            frmTimeRetrieval fTimeRetrieval;
            if (temp_Temperature() > 0)
                fTimeRetrieval = new frmTimeRetrieval(cp.FirstMoldTime, temp_Temperature());
            else
            {
                if(firstTempTextBox.Text == "-")  firstTempTextBox.Text = "0";
                fTimeRetrieval = new frmTimeRetrieval(cp.FirstMoldTime, Convert.ToInt16(firstTempTextBox.Text.Replace(",", "")));
            }

            fTimeRetrieval.StartPosition = FormStartPosition.Manual;
            fTimeRetrieval.Location = this.PointToScreen(btnFirstTimeRetrieval.Location);

            if (fTimeRetrieval.ShowDialog() == DialogResult.OK)
            {
                if(CurrentPouring.IsFirstTempOK == false)
                {
                    temp_Alarm();
                }
                CurrentPouring.FirstMoldTime = fTimeRetrieval.time;
                CurrentPouring.FirstTemp = fTimeRetrieval.temp;
                pouringBindingSource.ResetBindings(false);
                mbClient.WriteSingleRegister(100, 0);
            }
        }

        private void btnLastTimeRetrieval_Click(object sender, EventArgs e)
        {
            var cp = pouringBindingSource.Current as Pouring;

            frmTimeRetrieval fTimeRetrieval;
            if (temp_Temperature() > 0)
                fTimeRetrieval = new frmTimeRetrieval(cp.LastMoldTime, temp_Temperature());
            else
            {
                if (lastTempTextBox.Text == "-") lastTempTextBox.Text = "0";
                fTimeRetrieval = new frmTimeRetrieval(cp.LastMoldTime, Convert.ToInt16(lastTempTextBox.Text.Replace(",", "")));
            }

            fTimeRetrieval.StartPosition = FormStartPosition.Manual;
            fTimeRetrieval.Location = this.PointToScreen(btnLastTimeRetrieval.Location);

            if (fTimeRetrieval.ShowDialog() == DialogResult.OK)
            {
                if (CurrentPouring.IsLastTempOK == false)
                {
                    temp_Alarm();
                }
                CurrentPouring.LastMoldTime = fTimeRetrieval.time;
                CurrentPouring.LastTemp = fTimeRetrieval.temp;
                pouringBindingSource.ResetBindings(false);
                mbClient.WriteSingleRegister(100, 0);
            }
        }

        private async void PouringTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentPouring == null || CurrentPouring.Code == null)
                return;

            _pourings = (await _client.GetPouringsByLotNoAsync((CurrentLotNo.Code).Substring(0, 7))).Where(x => x.LineCode == PLine).OrderByDescending(x => x.Code).ToList();
            pouringBindingSource.DataSource = _pourings;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (CurrentPouring == null || CurrentPouring.Code == null)
            {
                MessageBox.Show("ใส่รายละเอียดไม่ครบ โปรดใส่ข้อมูลเพิ่มให้ครบ");
                return; 
            }

            string dateTime = CurrentPouring.FirstMoldTime.Value.ToString("dd/MM/yy  HH:mm");
            string duration = CurrentPouring.Duration.Substring(0, 5);
            frmPrintTag fPrintTag = new frmPrintTag();
            fPrintTag.Info[0] = CurrentPouring.Code;
            fPrintTag.Info[1] = $"{CurrentProduct.Code}  {CurrentProduct.Name}";
            fPrintTag.Info[2] = $"{dateTime}        duration: {duration} min.";
            fPrintTag.Info[3] = $"Temp start: {CurrentPouring.FirstTemp}      last: {CurrentPouring.LastTemp}";
            fPrintTag.Info[4] = $"No of Mold: {CurrentPouring.NoOfPouredMold}          Total pcs: {CurrentPouring.ProductNo}";
            fPrintTag.ShowDialog();
        }

        private void connectToTemperature()
        {
            var ip = Properties.Settings.Default.TempIP;
            mbClient = new EasyModbus.ModbusClient(ip, 502);
            try
            {
                mbClient.Connect();
                if(mbClient.Connected)
                    MessageBox.Show($"Connected to {ip}");
            }
            catch
            {
                MessageBox.Show($"Can not connect to {ip}");
            }
        }

        private int temp_Temperature()
        {
            if(mbClient.Connected)
            {
                return mbClient.ReadHoldingRegisters(100, 1).FirstOrDefault();
            }

            return 0;
        }

        private void temp_Alarm()
        {
            if (mbClient.Connected)
            {
                mbClient.WriteSingleCoil(110, true);
                MessageBox.Show("Temperature is out of standart !!!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mbClient.WriteSingleCoil(110, false);
            }
        }
    }
}
