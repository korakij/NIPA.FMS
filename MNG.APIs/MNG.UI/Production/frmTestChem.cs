using ASRS.UI;
using NPOI.OpenXmlFormats.Dml.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen;

namespace MNG.UI.Production
{
    public partial class frmTestChem : Form
    {
        private List<TestChemicalComposition> _testChemicalCompositions;
        private MeltingEventArgs MeltInfo;

        private Client _client;
        private Charging CurrentChargeNo;
        private LotNo CurrentLotNo;
        private ChemicalCompositionInFurnace ChemInFurnaceSpec;
        private TestChemicalComposition CurrentTestResult;
        private ControlPlan CurrentControlPlan;

        public event EventHandler<MeltingEventArgs> TestNoChanged;
        public event EventHandler<FormEventArgs> FormSelected;
        public event EventHandler<StatusUpdateEventArgs> StatusUpdate;
        StatusUpdateEventArgs statusUpdateEventArgs;

        public TestChemicalComposition SavedItem { get; set; }

        public frmTestChem()
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            MeltInfo = new MeltingEventArgs();
            CurrentLotNo = new LotNo();
            CurrentChargeNo = new Charging();
            ChemInFurnaceSpec = new ChemicalCompositionInFurnace();
            CurrentTestResult = new TestChemicalComposition();
            _testChemicalCompositions = new List<TestChemicalComposition>();
            CurrentControlPlan = new ControlPlan();
            fileSystemWatcher1.Path = frmSetting.ResultPath;
            statusUpdateEventArgs = new StatusUpdateEventArgs();

            //timer1.Interval = frmSetting.RefreshRate;
            TestTimer.Start();
            ResultTimer.Start();
        }

        public frmTestChem(TestChemicalComposition _test)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CurrentTestResult = new TestChemicalComposition();
            testChemicalCompositionBindingSource.DataSource = _test;
        }

        public void EnableToolBar() => pnToolBar.Show();
        public void DisableToolBar() => pnToolBar.Hide();
        public void EnableDGV() => testChemicalCompositionDataGridView.Show();
        public void DisableDGV() => testChemicalCompositionDataGridView.Hide();
        public void EnablePrint() => btnPrint.Show();
        public void DisablePrint() => btnPrint.Hide();
        public void EnableTestsTimer() => TestTimer.Enabled = true;
        public void DisableTestsTimer() => TestTimer.Enabled = false;
        public void EnableResultsTimer() => ResultTimer.Enabled = true;
        public void DisableResultsTimer() => ResultTimer.Enabled = false;

        public void FormDisableSelection()
        {
            pnBorderTop.BackColor = Color.White;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.SystemColors.ControlDark;
        }

        public void FormEnableSelection()
        {
            pnBorderTop.BackColor = Color.MidnightBlue;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.Color.Black;
        }

        public void EnableElement()
        {
            cTextBox1.ReadOnly = false;
            siTextBox1.ReadOnly = false;
            mnTextBox1.ReadOnly = false;
            mgTextBox1.ReadOnly = false;
            sTextBox1.ReadOnly = false;
            cuTextBox1.ReadOnly = false;
            alTextBox1.ReadOnly = false;
            snTextBox1.ReadOnly = false;
            pTextBox1.ReadOnly = false;
            moTextBox1.ReadOnly = false;
            crTextBox1.ReadOnly = false;
            niTextBox1.ReadOnly = false;
            tiTextBox1.ReadOnly = false;
            teTextBox.ReadOnly = false;
            vTextBox.ReadOnly = false;
        }

        public void DisableElement()
        {
            cceTextBox1.ReadOnly = true;
            cTextBox1.ReadOnly = true;
            siTextBox1.ReadOnly = true;
            mnTextBox1.ReadOnly = true;
            mgTextBox1.ReadOnly = true;
            sTextBox1.ReadOnly = true;
            cuTextBox1.ReadOnly = true;
            alTextBox1.ReadOnly = true;
            snTextBox1.ReadOnly = true;
            pTextBox1.ReadOnly = true;
            moTextBox1.ReadOnly = true;
            crTextBox1.ReadOnly = true;
            niTextBox1.ReadOnly = true;
            tiTextBox1.ReadOnly = true;
            teTextBox.ReadOnly = true;
            vTextBox.ReadOnly = true;
        }

        public void Export()
        {
        }

        private void frmTestChem_Load(object sender, EventArgs e)
        {
            
        }

        public async void LotNoChanged(object sender, MeltingEventArgs e)
        {
            if (e.LotNos == null)
            {
                testChemicalCompositionBindingSource.Clear();
                return;
            }

            CurrentLotNo = e.LotNos;
            _testChemicalCompositions = (await _client.GetTestsByLotNoAsync(e.LotNos.Code)).OrderByDescending(x => x.Code).ToList();
            testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;
        }

        public async void ChargeNoChange(object sender, MeltingEventArgs e)
        {
            if (e.ChargeNo.ChargeNo == null)
            {
                testChemicalCompositionBindingSource.Clear();
                CurrentTestResult = null;
                return;
            }

            CurrentChargeNo = e.ChargeNo;
            CurrentLotNo.Code = CurrentChargeNo.LotNoCode;

            try
            {
                _testChemicalCompositions = (await _client.GetTestNoByChargeNoAsync(e.ChargeNo.ChargeNo)).OrderByDescending(x => x.Code).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load Test Result", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;

        }

        private async void testChemicalCompositionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ControlPlan ctp = new ControlPlan();
            Product prod = new Product();

            CurrentTestResult = testChemicalCompositionBindingSource.Current as TestChemicalComposition;

            if (CurrentTestResult == null)
            {
                controlPlanBindingSource.Clear();
                chemicalCompositionInFurnaceBindingSource.Clear();
                productBindingSource.Clear();

                return;
            }

            try
            {
                ctp = (await _client.GetControlPlanByIdAsync(CurrentTestResult.ControlPlanId ?? 0));
                prod = (await _client.GetProductByIdAsync(ctp.ProductId));
                ChemInFurnaceSpec = (await _client.GetChemicalCompositionInFurnaceByIdAsync(ctp.ChemicalCompositionInFurnaceCode));
            }
            catch (Exception)
            {
                string message = "Connection error.";
                if(prod.ControlPlans.Count == 0)
                {
                    message = "not have ControlPlans.";
                }
                MessageBox.Show($"Unable to Load Data becuase {message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            controlPlanBindingSource.DataSource = ctp;
            chemicalCompositionInFurnaceBindingSource.DataSource = ChemInFurnaceSpec;
            productBindingSource.DataSource = prod;

            var MeltInfo = new MeltingEventArgs();

            if (CurrentTestResult == null)
            {
                testChemicalCompositionBindingSource.Clear();
                chemicalCompositionInFurnaceBindingSource.Clear();
                productBindingSource.Clear();

                pictureBox1.Image = null;
                tbProcessInd1.Hide();

                TestNoChanged?.Invoke(this, MeltInfo);
                return;
            }

            tbProcessInd1.Show();

            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = brCode.Draw(CurrentTestResult.Code, 20);

            MeltInfo.TestNo = CurrentTestResult;

            if (testChemicalCompositionBindingSource.Position == 0)
                MeltInfo.IsFirstRow = true;
            else
                MeltInfo.IsFirstRow = false;

            TestNoChanged?.Invoke(this, MeltInfo);
        }

        public async void CreateItem()
        {
            if (CurrentChargeNo == null)
            {
                MessageBox.Show("Cannot Create New Test because of last charge not exits");
                return;
            }

            var lastTest = (await _client.GetTestChemicalCompositionAllAsync()).ToList().Where(x => x.ChargingCode == CurrentChargeNo.ChargeNo).LastOrDefault();
            var lastCharge = (await _client.GetChargingAllAsync()).ToList().Where(x => x.LotNoCode == CurrentLotNo.Code).LastOrDefault();

            if (lastCharge.Total == null || lastCharge.Total == 0)
            {
                MessageBox.Show("Cannot Create New Test because of last charge not added");
                return;
            }

            if (lastTest != null)
            {
                var cnt = (await _client.GetKanbanByTestNoAsync(lastTest.Code)).Count;

                if (cnt == 0)
                {
                    MessageBox.Show("Cannot Create New Test because of last test not used");
                    return;
                }
            }

            var testNo = testChemicalCompositionBindingSource.Current as TestChemicalComposition;
            var count = testChemicalCompositionBindingSource.Count;

            count++;
            var newTestNo = $"T{lastCharge.ChargeNo}-{count.ToString("00")}";

            var fCreateNewTest = new frmCreateNewTest(newTestNo);
            fCreateNewTest.StartPosition = FormStartPosition.Manual;
            fCreateNewTest.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height / 3);

            if (fCreateNewTest.ShowDialog() == DialogResult.OK)
            {
                productIdTextBox.Text = fCreateNewTest.PartNo.ToString();

                var newTest = new TestChemicalComposition();
                var t = fCreateNewTest.PartNo;

                newTest.Code = newTestNo;
                newTest.ProductId = fCreateNewTest.PartNo ?? default(int);
                newTest.Time = DateTime.Now;
                newTest.ChargingCode = CurrentChargeNo.ChargeNo;
                newTest.ControlPlanId = fCreateNewTest.TestChem.ControlPlanId;

                try
                {
                    await _client.PostTestChemicalCompositionAsync(newTest);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        _testChemicalCompositions = (await _client.GetTestNoByChargeNoAsync(CurrentChargeNo.ChargeNo)).OrderByDescending(x => x.Code).ToList();
                        testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;

                        testChemicalCompositionBindingSource.Position = 0;
                    }
                    else
                    {
                        MessageBox.Show("ERROR " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    testChemicalCompositionBindingSource.ResetBindings(false);
                }
            }
        }

        public async void DeleteItem()
        {
            if (CurrentTestResult == null)
                return;

            var result = MessageBox.Show($"Do you want to delete {CurrentTestResult.Code}?\nThe Entire Data Test No will be deleted", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                var cnt = (await _client.GetKanbanByTestNoAsync(CurrentTestResult.Code)).Count;

                if (cnt != 0)
                {
                    MessageBox.Show("Unable to Delete because this test has already been tapping", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    await _client.DeleteTestChemicalCompositionAsync(CurrentTestResult.Code);
                    MessageBox.Show($"{CurrentTestResult.Code} has been delete", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _testChemicalCompositions = (await _client.GetTestNoByChargeNoAsync(CurrentChargeNo.ChargeNo)).OrderByDescending(x => x.Code).ToList();
                    testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async void EditItem()
        {
            frmVerifyInput fVerify = new frmVerifyInput("Test Code", "Confirmed Code");
            fVerify.EnableGenTestCode();
            fVerify.DisableGenPouringCode();

            if (fVerify.ShowDialog() != DialogResult.OK)
                return;

            CurrentTestResult = await _client.GetTestChemicalCompositionByIdAsync(fVerify.Code);

            if (CurrentTestResult == null)
            {
                MessageBox.Show("Unable to Edit Current Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTestChem fTest = new frmTestChem(CurrentTestResult);
            fTest.FormEnableSelection();
            fTest.EnableToolBar();
            fTest.EnableElement();
            fTest.DisableDGV();
            fTest.StartPosition = FormStartPosition.Manual;
            fTest.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 3, 30);

            var result = fTest.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutTestChemicalCompositionAsync(fTest.SavedItem.Code, fTest.SavedItem, ChemInFurnaceSpec.Code);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _testChemicalCompositions = (await _client.GetTestsByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();
                testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;
            }
        }

        public async void EditItemHeader()
        {
            CurrentTestResult = testChemicalCompositionBindingSource.Current as TestChemicalComposition;

            if (CurrentTestResult == null)
            {
                MessageBox.Show("Unable to Edit Current Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var prod = await _client.GetProductByIdAsync(CurrentTestResult.ProductId ?? 0);
            int controlPlanId = prod.ActiveControlPlanId ?? default(int);
            var ctp = (await _client.GetControlPlanByIdAsync(controlPlanId)) as ControlPlan;
            var chemInFur = (await _client.GetChemicalCompositionInFurnaceByIdAsync(ctp.ChemicalCompositionInFurnaceCode));

            frmCreateNewTest fTest = new frmCreateNewTest(CurrentTestResult.Code, prod, chemInFur, CurrentTestResult, ctp);

            fTest.StartPosition = FormStartPosition.Manual;
            fTest.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 3, Screen.PrimaryScreen.WorkingArea.Height / 3);

            var result = fTest.ShowDialog();

            if (result == DialogResult.OK)
            {
                var test = fTest.TestChem;

                if (test == null)
                    return;

                try
                {
                    await _client.PutTestChemicalCompositionAsync(test.Code, test, chemInFur.Code);
                }
                catch (Exception ex)
                {

                    if (ex.Message.Contains("201"))
                    {
                        testChemicalCompositionBindingSource.CancelEdit();
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    _testChemicalCompositions = (await _client.GetTestsByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();
                    testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;
                }
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            var p = await _client.GetProductByIdAsync(CurrentTestResult.ProductId ?? 0);

            frmPrintTag fPrintTag = new frmPrintTag();
            fPrintTag.Info[0] = CurrentTestResult.Code;
            fPrintTag.Info[1] = $"{p.Code}   {p.Name}";
            fPrintTag.Info[2] = CurrentTestResult.Time.Value.ToString("dd/MM/yy  HH:mm");
            fPrintTag.ShowDialog();
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
                var test = testChemicalCompositionBindingSource.Current as TestChemicalComposition;
                test.Result = chem;

                if (test == null)
                    return;

                testChemicalCompositionBindingSource.DataSource = test;
                testChemicalCompositionBindingSource.ResetBindings(false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            testChemicalCompositionBindingSource.EndEdit();
            SavedItem = testChemicalCompositionBindingSource.Current as TestChemicalComposition;
            this.Close();
        }

        private async void btnAnalysis_Click(object sender, EventArgs e)
        {
            Spectrometer sp = new Spectrometer(@"F:\Mango.Solutions\MNG.FMS\ChemResult\Results_2276.txt");
            var chem = sp.ChemResult;
            var test = testChemicalCompositionBindingSource.Current as TestChemicalComposition;
            test.Result = chem;

            if (test == null)
                return;

            try
            {
                await _client.PutTestChemicalCompositionAsync(test.Code, test, ChemInFurnaceSpec.Code);
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("201"))
                {
                    testChemicalCompositionBindingSource.CancelEdit();
                }
                else
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                _testChemicalCompositions = (await _client.GetTestsByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();
                testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;
            }
        }

        private async void ResultTimer_Tick(object sender, EventArgs e)
        {
            if (CurrentTestResult == null || CurrentTestResult.Code == null)
                return;

            var dbTests = (await _client.GetTestNoByChargeNoAsync(CurrentChargeNo.ChargeNo)).OrderByDescending(x => x.Code).ToList();

            _testChemicalCompositions = dbTests;
            testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;

            //if (CurrentTestResult == null || CurrentTestResult.Code == null)
            //    return;

            //var lastUpdate = (await _client.GetTestChemicalCompositionByIdAsync(CurrentTestResult.Code));

            //if (lastUpdate.UpdatedTime > CurrentTestResult.UpdatedTime)
            //{
            //    var dbTests = (await _client.GetTestNoByChargeNoAsync(CurrentChargeNo.ChargeNo)).OrderByDescending(x => x.Code).ToList();

            //    _testChemicalCompositions = dbTests;
            //    testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;
            //}
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (CurrentLotNo.Code == null)
                return;

            var dbTests = (await _client.GetTestNoByLotNoFilterAsync(CurrentLotNo.Code)).OrderByDescending(x => x.Code).ToList();

            if (dbTests.Count == 0)
                testChemicalCompositionBindingSource.Clear();

            _testChemicalCompositions = dbTests;
            testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;

            //if (_testChemicalCompositions.Count < dbTests.Count)
            //{
            //    _testChemicalCompositions = dbTests;
            //    testChemicalCompositionBindingSource.DataSource = _testChemicalCompositions;
            //}
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var fName = new FormEventArgs();
            fName.Name = FormName.frmTestChem;

            FormSelected?.Invoke(this, fName);
            statusUpdateEventArgs.Status = "เลือกหน้าทดสอบค่าเคมี";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendStatusUpdate()
        {
            if (statusUpdateEventArgs.Status != "")
            {
                StatusUpdate?.Invoke(this, statusUpdateEventArgs);
                statusUpdateEventArgs.Status = "";
            }
        }
    }
}

