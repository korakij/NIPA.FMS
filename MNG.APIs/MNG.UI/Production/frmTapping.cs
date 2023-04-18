using ASRS.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class frmTapping : Form
    {
        private List<Kanban> _kanbans;
        private Kanban SavedItem = new Kanban();
        private Client _client;
        private MeltingEventArgs MeltInfo;
        private Kanban CurrentKanban;
        private LotNo CurrentLotNo;
        private TestChemicalComposition CurrentTestNo;
        private ChemicalCompositionInLadle CurrentChemInLadleSpec;
        private PourStandard CurrentPourStandard;

        public event EventHandler<MeltingEventArgs> KanbanNoChanged;
        public event EventHandler<FormEventArgs> FormSelected;
        public event EventHandler<MeltingEventArgs> SummaryUpdate;

        public frmTapping()
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            _kanbans = new List<Kanban>();
            MeltInfo = new MeltingEventArgs();
            CurrentKanban = new Kanban();
            CurrentLotNo = new LotNo();
            CurrentTestNo = new TestChemicalComposition();
            CurrentChemInLadleSpec = new ChemicalCompositionInLadle();
            CurrentPourStandard = new PourStandard();

            fileSystemWatcher1.Path = frmSetting.ResultPath;
            //timer1.Interval = frmSetting.RefreshRate;
            //timer1.Start();
        }

        public frmTapping(Kanban _currentKanban)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            kanbanBindingSource.DataSource = _currentKanban;
            EnableEditMode(false);
        }

        public frmTapping(List<Kanban> kanbans)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            kanbanBindingSource.DataSource = kanbans;
            EnableEditMode(true);
        }

        public void EnableToolBar() => pnToolBar.Show();
        public void DisableToolBar() => pnToolBar.Hide();
        public void EnableDGV() => kanbanDataGridView1.Show();
        public void DisableDGV() => kanbanDataGridView1.Hide();
        public void EnablePrint() => btnPrint.Show();
        public void DisablePrint() => btnPrint.Hide();
        public void EnablePnDetails() => pnDetails.Show();
        public void DisablePnDetails() => pnDetails.Hide();
        public void EnablePnNavigator() => pnNavigator.Show();
        public void DisablePnNavigator() => pnNavigator.Hide();
        public void EnableProductBrowse() => btnProductBrowse.Show();
        public void DisableProductBrowse() => btnProductBrowse.Hide();
        public void EnableReadMeter() => btnReadPower.Show();
        public void DisableReadMeter() => btnReadPower.Hide();
        public void EnablePnDGV() => pnDgv.Show();
        public void DisablePnDGV() => pnDgv.Hide();
        public void EnablePnTreatDetail() => pnTreatDetail.Show();
        public void DisablePnTreatDetail() => pnTreatDetail.Hide();
        public void EnablePnChemDetail() => pnChemDetail.Show();
        public void DisablePnChemDetail() => pnChemDetail.Hide();
        public void EnableBtnTapTime() => btnGetTapTime.Show();
        public void DisableBtnTapTime() => btnGetTapTime.Hide();
        public void EnableTapTimer() => TappingTimer.Enabled = true;
        public void DisableTapTimer() => TappingTimer.Enabled = false;
        public void EnableTestTimer() => TestTimer.Enabled = true;
        public void DisableTestTimer() => TestTimer.Enabled = false;
        public void EnableSpark() => btnSpark.Show();
        public void DisableSpark() => btnSpark.Hide();
        public void EnableFilByTest() => chkTestNo.Show();
        public void DisableFilByTest() => chkTestNo.Hide();

        private void frmKanban_Load(object sender, EventArgs e)
        {
        }

        private void EnableEditMode(bool IsEdit)
        {
            weightTextBox.ReadOnly = IsEdit;
            inoculantTextBox1.ReadOnly = IsEdit;
            magnesiumTextBox1.ReadOnly = IsEdit;
            wireInoculantTextBox.ReadOnly = IsEdit;
            wireMagnesiumTextBox.ReadOnly = IsEdit;
            feedTempTextBox1.ReadOnly = IsEdit;
            copperTextBox.ReadOnly = IsEdit;
            tinTextBox.ReadOnly = IsEdit;
            chillTextBox.ReadOnly = IsEdit;

            kwHrTextBox.ReadOnly = IsEdit;

            cTextBox.ReadOnly = IsEdit;
            siTextBox.ReadOnly = IsEdit;
            mnTextBox.ReadOnly = IsEdit;
            mgTextBox.ReadOnly = IsEdit;
            sTextBox.ReadOnly = IsEdit;
            cuTextBox.ReadOnly = IsEdit;
            alTextBox.ReadOnly = IsEdit;
            snTextBox.ReadOnly = IsEdit;
            pTextBox.ReadOnly = IsEdit;
            moTextBox.ReadOnly = IsEdit;
            crTextBox.ReadOnly = IsEdit;
            niTextBox.ReadOnly = IsEdit;
            tiTextBox.ReadOnly = IsEdit;
            teTextBox.ReadOnly = IsEdit;
            vTextBox.ReadOnly = IsEdit;
        }

        public async void CreateItem()
        {
            if (CurrentTestNo.Code == null)
            {
                MessageBox.Show("Unable to Create New Tap", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CurrentTestNo.IsPassed == false)
            {
                DialogResult IsNo = MessageBox.Show("The Chemical Composition in Furnace is not passed. Do you want to continue?", "Are you Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (IsNo == DialogResult.No)
                    return;
            }

            int newNo;
            var last = (await _client.GetKanbanAllAsync()).Where(x => x.Code.Contains(CurrentLotNo.Code)).LastOrDefault();

            if (last == null)
                newNo = 1;
            else
                newNo = Convert.ToInt32(last.Code.Substring(11, 2)) + 1;

            var newKanbanNo = $"K-{CurrentLotNo.Code}-{newNo.ToString("00")}";

            DialogResult result = MessageBox.Show($"Do you want to create new Kanban to {newKanbanNo}", "Create New Test", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                var pId = CurrentTestNo.ProductId ?? default(int);
                var p = (await _client.GetProductByIdAsync(pId)) as Product;

                var ControlPlanId = p.ActiveControlPlanId;
                var c = (await _client.GetControlPlanByIdAsync(ControlPlanId ?? default(int))) as ControlPlan;

                var ChemInLadleSpec = (await _client.GetChemicalCompositionInLadleByIdAsync(c.ChemicalCompositionInLadleCode));
                chemicalCompositionInLadleBindingSource.DataSource = ChemInLadleSpec;

                var newKanban = new Kanban();
                newKanban.Code = newKanbanNo;
                newKanban.TestChemicalCompositionCode = CurrentTestNo.Code;
                newKanban.Time = DateTime.Now;
                newKanban.MaterialCode = p.MaterialCode;
                newKanban.ControlPlanId = ControlPlanId;

                try
                {
                    await _client.PostKanbanAsync(newKanban);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        _kanbans = (await _client.GetKanbansByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();
                        kanbanBindingSource.DataSource = _kanbans;

                        kanbanBindingSource.Position = 0;
                    }
                    else
                    {
                        MessageBox.Show("ERROR " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    kanbanBindingSource.ResetBindings(false);
                }
            }
        }

        public void Export()
        {
        }

        public async void DeleteItem()
        {
            if (CurrentKanban == null)
                return;

            var result = MessageBox.Show($"Do you want to delete {CurrentKanban.Code}?\nThe Entire Data Lot No will be deleted", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                var lastK = (await _client.GetKanbansByLotNoAsync(CurrentLotNo.Code)).ToList().LastOrDefault();

                if (lastK == null || lastK.Code != CurrentKanban.Code)
                {
                    MessageBox.Show($"Kanban cannnot be deleted neither {CurrentKanban.Code} does not the last one or does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    await _client.DeleteKanbanAsync(CurrentKanban.Code);
                    MessageBox.Show($"{CurrentKanban.Code} has been delete", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    productBindingSource.Clear();
                    pourStandardBindingSource.Clear();
                    chemicalCompositionInLadleBindingSource.Clear();

                    _kanbans = (await _client.GetKanbansByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();
                    kanbanBindingSource.DataSource = _kanbans;
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MeltingEventArgs ln = new MeltingEventArgs();
            MeltInfo.LotNos.Code = CurrentLotNo.Code;

            SummaryUpdate?.Invoke(this, MeltInfo);
        }

        public async void EditChemItem()
        {
            if (CurrentKanban.Code == null)
            {
                MessageBox.Show("Unable to Edit Current Tap", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTapping fTapping = new frmTapping(CurrentKanban);

            fTapping.StartPosition = FormStartPosition.Manual;
            fTapping.Location = new Point(340, 100);
            fTapping.Size = new Size(550, 900);
            fTapping.FormEnableSelection();
            fTapping.EnableToolBar();
            fTapping.DisableProductBrowse();
            fTapping.DisableReadMeter();
            fTapping.DisablePrint();
            fTapping.DisablePnNavigator();
            fTapping.EnablePnDetails();
            fTapping.DisablePnDGV();
            fTapping.DisablePnTreatDetail();
            fTapping.EnablePnChemDetail();
            fTapping.DisableBtnTapTime();
            fTapping.EnableSpark();

            var result = fTapping.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutKanbanAsync(fTapping.SavedItem.Code, fTapping.SavedItem, CurrentChemInLadleSpec.Code, CurrentPourStandard.Code);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        kanbanBindingSource.CancelEdit();
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                var _kanbans = (await _client.GetKanbansByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();
                kanbanBindingSource.DataSource = _kanbans;


                MeltingEventArgs ln = new MeltingEventArgs();
                MeltInfo.LotNos.Code = CurrentLotNo.Code;

                SummaryUpdate?.Invoke(this, MeltInfo);
            }
        }

        public async void EditItemHeader()
        {
            CurrentKanban = kanbanBindingSource.Current as Kanban;

            if (CurrentKanban == null)
            {
                MessageBox.Show("Unable to Edit Current Tap", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTapping fTapping = new frmTapping(CurrentKanban);

            fTapping.StartPosition = FormStartPosition.Manual;
            fTapping.Location = new Point(340, 100);
            fTapping.Size = new Size(550, 900);
            fTapping.FormEnableSelection();
            fTapping.EnableToolBar();
            fTapping.DisableProductBrowse();
            fTapping.EnableReadMeter();
            fTapping.DisablePnNavigator();
            fTapping.EnablePnDetails();
            fTapping.DisablePnDGV();
            fTapping.EnablePnTreatDetail();
            fTapping.DisablePnChemDetail();
            fTapping.EnableBtnTapTime();
            fTapping.DisableSpark();

            var result = fTapping.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutKanbanAsync(fTapping.SavedItem.Code, fTapping.SavedItem, CurrentChemInLadleSpec.Code, CurrentPourStandard.Code);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        kanbanBindingSource.CancelEdit();
                    }
                    else
                    {
                        MessageBox.Show($"ERROR {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            var _kanbans = (await _client.GetKanbansByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();

            kanbanBindingSource.DataSource = _kanbans;
            tbProcessInd1.Update();

            MeltingEventArgs ln = new MeltingEventArgs();
            MeltInfo.LotNos.Code = CurrentLotNo.Code;

            SummaryUpdate?.Invoke(this, MeltInfo);
        }

        public void FormEnableSelection()
        {
            pnBorderTop.BackColor = Color.MidnightBlue;
            pnBorderBottom.BackColor = Color.MidnightBlue;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.Color.Black;
        }

        public void FormDisableSelection()
        {
            pnBorderTop.BackColor = Color.White;
            pnBorderBottom.BackColor = Color.White;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        public void TestNoChanged(Object sender, MeltingEventArgs e)
        {
            if (e.TestNo.Code == null)
            {
                kanbanBindingSource.Clear();
                controlPlanBindingSource.Clear();
                chemicalCompositionInLadleBindingSource.Clear();
                testChemicalCompositionBindingSource.Clear();
                productBindingSource.Clear();
                pourStandardBindingSource.Clear();
                CurrentLotNo = null;
                return;
            }

            CurrentTestNo = e.TestNo;
            chkTestNo_CheckedChanged(this, EventArgs.Empty);
        }

        public async void LotNoChanged(Object sender, MeltingEventArgs e)
        {
            if (e.LotNos == null)
            {
                kanbanBindingSource.Clear();
                controlPlanBindingSource.Clear();
                chemicalCompositionInLadleBindingSource.Clear();
                testChemicalCompositionBindingSource.Clear();
                productBindingSource.Clear();
                pourStandardBindingSource.Clear();
                CurrentLotNo = null;
                return;
            }

            CurrentLotNo = e.LotNos;
            chkTestNo_CheckedChanged(this, EventArgs.Empty);
        }

        private async void chkTestNo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTestNo.Checked)
                    _kanbans = (await _client.GetKanbanByTestNoAsync(CurrentTestNo.Code)).OrderByDescending(x => x.Code).ToList();
                else
                    _kanbans = (await _client.GetKanbansByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Load Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_kanbans.Count == 0)
            {
                kanbanBindingSource.Clear();
                productBindingSource.Clear();
                controlPlanBindingSource.Clear();
                chemicalCompositionInLadleBindingSource.Clear();
                testChemicalCompositionBindingSource.Clear();
                pourStandardBindingSource.Clear();
                return;
            }

            kanbanBindingSource.DataSource = _kanbans;
        }

        public async void LotNoChangedTapping(object sender, MeltingEventArgs e)
        {
            if (e.LotNos == null)
            {
                kanbanBindingSource.Clear();
                chemicalCompositionInLadleBindingSource.Clear();
                testChemicalCompositionBindingSource.Clear();
                productBindingSource.Clear();
                pourStandardBindingSource.Clear();
                CurrentLotNo = null;
                return;
            }

            CurrentLotNo = e.LotNos;

            try
            {
                var lotNo = CurrentLotNo.Code.Substring(0, 6);
                _kanbans = (await _client.GetKanbansByLotNoAsync(lotNo)).OrderByDescending(x => x.Code).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Load Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_kanbans.Count == 0)
            {
                kanbanBindingSource.Clear();
                return;
            }

            kanbanBindingSource.DataSource = _kanbans;
        }

        private async void kanbanBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ControlPlan ctp = new ControlPlan();
            Product prod = new Product();

            CurrentKanban = kanbanBindingSource.Current as Kanban;

            if (CurrentKanban == null)
                return;

            try
            {
                ctp = (await _client.GetControlPlanByIdAsync(CurrentKanban.ControlPlanId ?? default(int)));
                prod = (await _client.GetProductByIdAsync(ctp.ProductId));
                CurrentChemInLadleSpec = (await _client.GetChemicalCompositionInLadleByIdAsync(ctp.ChemicalCompositionInLadleCode));
                CurrentPourStandard = (await _client.GetPouringStandardByIdAsync(ctp.PouringCode));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load Data xxx", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            controlPlanBindingSource.DataSource = ctp;
            productBindingSource.DataSource = prod;
            chemicalCompositionInLadleBindingSource.DataSource = CurrentChemInLadleSpec;
            pourStandardBindingSource.DataSource = CurrentPourStandard;

            var meltInfo = new MeltingEventArgs();
            meltInfo.KanbanNo = CurrentKanban;

            KanbanNoChanged?.Invoke(this, meltInfo);
        }

        private void btnGetTapTime_Click(object sender, EventArgs e)
        {
            DateTime? date1;

            if (CurrentKanban == null)
                return;

            var k = kanbanBindingSource.Current as Kanban;

            date1 = k.Time;

            //var dateString = timeTextBox.Text;

            //if (dateString == "")
            //    date1 = DateTime.Now;
            //else
            //    date1 = DateTime.Parse(dateString,
            //                          System.Globalization.CultureInfo.InvariantCulture);

            frmTimeRetrieval fTimeRetrieval = new frmTimeRetrieval(date1);
            fTimeRetrieval.StartPosition = FormStartPosition.Manual;
            fTimeRetrieval.Location = this.PointToScreen(btnGetTapTime.Location);

            var result = fTimeRetrieval.ShowDialog();
            if (result == DialogResult.OK)
            {
                timeTextBox.Text = fTimeRetrieval.time.ToString("dd/MM/yy HH:mm");
                kanbanBindingSource.EndEdit();
            }
        }

        private async void TestTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentKanban == null || CurrentKanban.Code == null)
                return;
        }

        private void TappingTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentLotNo == null || CurrentLotNo.Code == null)
                return;

            chkTestNo_CheckedChanged(this, EventArgs.Empty);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var fName = new FormEventArgs();
            fName.Name = FormName.frmTapping;

            FormSelected?.Invoke(this, fName);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpark_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt";
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Spectrometer sp = new Spectrometer(openFileDialog1.FileName);

                var chem = sp.ChemResult;
                var test = kanbanBindingSource.Current as Kanban;
                test.Result = chem;

                if (test == null)
                    return;

                kanbanBindingSource.DataSource = test;
                kanbanBindingSource.ResetBindings(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            kanbanBindingSource.EndEdit();
            SavedItem = kanbanBindingSource.Current as Kanban;

            SavedItem.IsCompleted = SavedItem.Time != null ? true : false && SavedItem.Weight != null ? true : false &&
                SavedItem.KwHr != null ? true : false;

            if (SavedItem == null)
                return;

            this.Close();
        }

        private async void btnProductBrowse_Click(object sender, EventArgs e)
        {
            var products = (await _client.GetProductAllAsync()).ToList();

            frmProduct fProduct = new frmProduct(products);
            fProduct.ProductBrowseDisable();
            fProduct.ToolDisable();

            var result = fProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                var p = fProduct.SelectedItem;
                var cp = await _client.GetControlPlanByIdAsync(p.ActiveControlPlanId ?? 0);
                var ChemStd = await _client.GetChemicalCompositionInFurnaceByIdAsync(cp.ChemicalCompositionInFurnaceCode);
                var pourStd = await _client.GetPouringStandardByIdAsync(cp.PouringCode);

                productBindingSource.DataSource = p;
                materialCodeTextBox.Text = p.MaterialCode;

                pourStandardBindingSource.DataSource = pourStd;
            }
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (codeTextBox.Text == "")
            {
                pictureBox1.Image = null;
                return;
            }

            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = brCode.Draw(CurrentKanban.Code, 20);
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

        private void kanbanBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            if (kanbanBindingSource.Count == 0)
                tbProcessInd1.Disable();
            else
                tbProcessInd1.Enable();
        }

        private void btnReadPower_Click(object sender, EventArgs e)
        {

        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            var p = await _client.GetProductByIdAsync(CurrentTestNo.ProductId ?? 0);

            frmPrintTag fPrintTag = new frmPrintTag();
            fPrintTag.Info[0] = CurrentKanban.Code;
            fPrintTag.Info[1] = $"{p.Code}   {p.Name}";
            fPrintTag.Info[2] = CurrentKanban.Time.Value.ToString("dd/MM/yy  HH:mm");
            fPrintTag.ShowDialog();
        }

    }
}
