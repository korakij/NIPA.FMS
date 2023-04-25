using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ASRS.UI;
using EasyModbus;
using NPOI.OpenXmlFormats.Dml.Diagram;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MNG.UI.Production
{
    public partial class frmEditMatCharging : Form
    {
        public Charging CurrentCharge { get; set; }

        private Client _client;
        private Furnace CurrentFurnace;
        private bool IsPowerOk;
        private bool IsTimeIntervalOk;
        private bool IsMaxTempOk;
        private bool IsPartIdOk = false;
        private bool IsPass = true;

        public frmEditMatCharging(Charging _currentCharge)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CurrentCharge = new Charging();
            CurrentFurnace = new Furnace();
            CurrentCharge = _currentCharge;
        }

        private async void frmEditMatCharging_Load(object sender, EventArgs e)
        {
            var furnaceCode = CurrentCharge.LotNoCode.Substring(CurrentCharge.LotNoCode.Length - 1);

            try
            {
                var ctp = (await _client.GetControlPlanByIdAsync(CurrentCharge.ControlPlanId ?? 0));
                var chemInFur = (await _client.GetChemicalCompositionInFurnaceByIdAsync(ctp.ChemicalCompositionInFurnaceCode));

                controlPlanBindingSource.DataSource = ctp;
                chemicalCompositionInFurnaceBindingSource.DataSource = chemInFur;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load Control Plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            CurrentFurnace = await _client.GetFurnaceByIdAsync(furnaceCode);
            furnaceBindingSource.DataSource = CurrentFurnace;
            chargingBindingSource.DataSource = CurrentCharge;

            tbCurrentRS.Text = string.Format("{0:N1}", CurrentCharge.Rs);
            tbCurrentSS.Text = string.Format("{0:N1}", CurrentCharge.Ss);
            tbCurrentPigFC.Text = string.Format("{0:N1}", CurrentCharge.PigFC);
            tbCurrentPigFCD.Text = string.Format("{0:N1}", CurrentCharge.PigFCD);
            tbCurrentCFC.Text = string.Format("{0:N1}", CurrentCharge.C_FC);
            tbCurrentCFCD.Text = string.Format("{0:N1}", CurrentCharge.C_FCD);
            tbCurrentFeSi.Text = string.Format("{0:N1}", CurrentCharge.Fe_Si);
            tbCurrentFeMn.Text = string.Format("{0:N1}", CurrentCharge.Fe_Mn);
            tbCurrentHcCr.Text = string.Format("{0:N1}", CurrentCharge.HC_Cr);
            tbCurrentFeMo.Text = string.Format("{0:N1}", CurrentCharge.Fe_Mo);
            tbCurrentFeNi.Text = string.Format("{0:N1}", CurrentCharge.Fe_Ni);
            tbCurrentTotal.Text = string.Format("{0:N1}", CurrentCharge.Total);

            actRemainMetal_ValueChanged(this, EventArgs.Empty);

            if (CurrentCharge.ProductId != null)
            {
                var p = await _client.GetProductByIdAsync(CurrentCharge.ProductId ?? 0);
                productBindingSource.DataSource = p;
            }

            if (CurrentCharge.Status == Status.Running.ToString())
                timer1.Start();
        }

        private void btnChargeTimeRetrieval_Click(object sender, EventArgs e)
        {
            frmTimeRetrieval fTimeRetrieval = new frmTimeRetrieval(CurrentCharge.ChargeTime);
            fTimeRetrieval.StartPosition = FormStartPosition.Manual;
            fTimeRetrieval.Location = this.PointToScreen(btnChargeTimeRetrieval.Location);

            if (fTimeRetrieval.ShowDialog() == DialogResult.OK)
            {
                CurrentCharge.ChargeTime = fTimeRetrieval.time;
                GetTimeInterval();
                chargingBindingSource.ResetBindings(false);
            }
        }

        private void btnMaxTempTimeRetrieval_Click(object sender, EventArgs e)
        {
            if (maxTempNumericUpDown.Value < 1)
            {
                MessageBox.Show("Max Temp is required!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //var dateString = maxTempTimeTextBox.Text;
            //DateTime date1 = DateTime.Parse(dateString,
            //                          System.Globalization.CultureInfo.InvariantCulture);

            frmTimeRetrieval fTimeRetrieval = new frmTimeRetrieval(CurrentCharge.MaxTempTime);
            fTimeRetrieval.StartPosition = FormStartPosition.Manual;
            fTimeRetrieval.Location = this.PointToScreen(btnMaxTempTimeRetrieval.Location);

            if (fTimeRetrieval.ShowDialog() == DialogResult.OK)
            {
                CurrentCharge.MaxTempTime = fTimeRetrieval.time;
                maxTempTimeTextBox.Text = fTimeRetrieval.time.ToString();

                timer1.Stop();
                CurrentCharge.Status = Status.Completed.ToString();
                CurrentCharge.Interval = intervalTextBox.Text;
                GetTimeInterval();
                chargingBindingSource.ResetBindings(false);
            }
        }

        private void GetTimeInterval()
        {
            TimeSpan interval = (CurrentCharge.MaxTempTime ?? DateTime.Now) - (CurrentCharge.ChargeTime ?? DateTime.Now);

            if (CurrentCharge.MaxTempTime < CurrentCharge.ChargeTime)
            {
                intervalTextBox.BackColor = Color.Red;
                intervalTextBox.ForeColor = Color.White;
                IsTimeIntervalOk = false;
            }
            else
            {
                intervalTextBox.BackColor = Color.White;
                intervalTextBox.ForeColor = Color.Black;
                IsTimeIntervalOk = true;
            }

            CurrentCharge.Interval = interval.ToString(@"hh\:mm\:ss");
            intervalTextBox.Text = CurrentCharge.Interval;

            SetStatus();
        }

        private void SetStatus()
        {
            //IsPartIdOk = CurrentCharge.ProductId != null ? true : false;
            //CurrentCharge.IsCompleted = IsTimeIntervalOk && IsPowerOk && IsMaxTempOk && IsPartIdOk;

            //if (CurrentCharge.IsCompleted ?? false)
            //    btnSaved.Enabled = true;
            //else
            //    btnSaved.Enabled = false;
        }

        private void btnReadFirstPower_Click(object sender, EventArgs e)
        {
            tbStartKwH.Text = string.Format("{0:N2}", ReadMeter());
        }

        private void btnReadMaxPower_Click(object sender, EventArgs e)
        {
            maxTempKwHrNumericUpDown.Text = string.Format("0:N2", ReadMeter());
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            chargingBindingSource.CancelEdit();
            this.Close();
        }

        private double ReadMeter()
        {
            //var ip = Properties.Settings.Default.PMeter1;
            var ip = "192.168.2.108";
            ModbusClient modbusClient = new ModbusClient();
            modbusClient.ConnectionTimeout = 2000;

            try
            {
                modbusClient.Connect(ip, 502);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connected");
                return 0;
            }

            modbusClient.UnitIdentifier = 1;

            var data = modbusClient.ReadHoldingRegisters(801, 4);
            var result = ModbusClient.ConvertRegistersToDouble(data, ModbusClient.RegisterOrder.HighLow);

            return result / 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            maxTempTimeTextBox.Text = time.ToString("dd/MM/yy  HH:mm:ss");
            CurrentCharge.MaxTempTime = time;

            GetTimeInterval();
        }

        private void startKwHrNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GetPowerConsumtion();
        }

        private void maxTempKwHrNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GetPowerConsumtion();
        }

        private void GetPowerConsumtion()
        {
            chargingBindingSource.EndEdit();
            var power = CurrentCharge.MaxTempKwHr - CurrentCharge.StartKwHr;

            if (power <= 0 || CurrentCharge.MaxTempKwHr == 0 || CurrentCharge.StartKwHr == 0)

            {
                powerCompTextBox.BackColor = Color.Red;
                powerCompTextBox.ForeColor = Color.White;
                IsPowerOk = false;
            }
            else
            {
                powerCompTextBox.BackColor = Color.White;
                powerCompTextBox.ForeColor = Color.Black;
                IsPowerOk = true;
            }

            CurrentCharge.PowerComp = Convert.ToDouble(power);

            SetStatus();
            chargingBindingSource.ResetBindings(false);
        }

        private void maxTempNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (maxTempNumericUpDown.Value <= 0)
                IsMaxTempOk = false;
            else
                IsMaxTempOk = true;

            SetStatus();
        }

        private async void btnBrowse_Click(object sender, EventArgs e)
        {
            var products = (await _client.GetProductAllAsync()).Where(x => x.ActiveControlPlanId != null).ToList();

            frmProduct fProduct = new frmProduct(products);
            fProduct.ProductBrowseDisable();
            fProduct.ToolDisable();

            var result = fProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                var p = fProduct.SelectedItem;
                var cp = await _client.GetControlPlanByIdAsync(p.ActiveControlPlanId ?? 0);
                var ChemStd = await _client.GetChemicalCompositionInFurnaceByIdAsync(cp.ChemicalCompositionInFurnaceCode);

                if (CurrentCharge.ControlPlanId != cp.Id)
                {
                    var IsConfirm = MessageBox.Show("Current Control Plan Not Match with the Selected Control Plan\nDo you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (IsConfirm == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {

                    }
                }

                controlPlanIdTextBox.Text = cp.Id.ToString();

                productBindingSource.DataSource = p;
                tbProductId.Text = p.Id.ToString();
                controlPlanBindingSource.DataSource = cp;
                chemicalCompositionInFurnaceBindingSource.DataSource = ChemStd;
            }
        }

        private void btnSaved_Click_1(object sender, EventArgs e)
        {
            IsPartIdOk = CurrentCharge.ProductId != null ? true : false;
            GetTimeInterval();

            CurrentCharge.MoltenMetal = totMetal.Text == "" ? 0 : Convert.ToDouble(totMetal.Text);
            CurrentCharge.Rs = totRS.Text == "" ? 0 : Convert.ToDouble(totRS.Text);
            CurrentCharge.Ss = totSS.Text == "" ? 0 : Convert.ToDouble(totSS.Text);
            CurrentCharge.PigFC = totPigFC.Text == "" ? 0 : Convert.ToDouble(totPigFC.Text);
            CurrentCharge.PigFCD = totPigFCD.Text == "" ? 0 : Convert.ToDouble(totPigFCD.Text);
            CurrentCharge.C_FC = totCFC.Text == "" ? 0 : Convert.ToDouble(totCFC.Text);
            CurrentCharge.C_FCD = totCFCD.Text == "" ? 0 : Convert.ToDouble(totCFCD.Text);
            CurrentCharge.Fe_Si = totSi.Text == "" ? 0 : Convert.ToDouble(totSi.Text);
            CurrentCharge.Fe_Mn = totMn.Text == "" ? 0 : Convert.ToDouble(totMn.Text);
            CurrentCharge.HC_Cr = totCr.Text == "" ? 0 : Convert.ToDouble(totCr.Text);
            CurrentCharge.Fe_Mo = totMo.Text == "" ? 0 : Convert.ToDouble(totMo.Text);
            CurrentCharge.Fe_Ni = totNi.Text == "" ? 0 : Convert.ToDouble(totNi.Text);
            CurrentCharge.Total = totTotal.Text == "" ? 0 : Convert.ToDouble(totTotal.Text);
            CurrentCharge.IsCompleted = IsTimeIntervalOk && IsPowerOk && IsMaxTempOk && IsPartIdOk;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnSaved_Click_1(this, EventArgs.Empty);
            this.Close();
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

        private void actRemainMetal_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentCharge == null)
                return;

            CurrentCharge.Total = CurrentCharge.Rs ?? 0 + CurrentCharge.Ss ?? 0+ CurrentCharge.PigFC ?? 0+
                    CurrentCharge.PigFCD ?? 0 + CurrentCharge.C_FC ?? 0 + CurrentCharge.C_FCD ?? 0 + CurrentCharge.Fe_Si ?? 0 + CurrentCharge.Fe_Mn ?? 0 +
                    CurrentCharge.HC_Cr ?? 0 + CurrentCharge.Fe_Mo ?? 0 + CurrentCharge.Fe_Ni ?? 0;

            tbCurrentTotal.Text = string.Format("{0:N1}", CurrentCharge.Total);

            var addMat = addMetal.Value + addRS.Value + addSS.Value + addPigFC.Value + addPigFCD.Value + addCFC.Value + addCFCD.Value +
                    addSi.Value + addMn.Value + addCr.Value + addMo.Value + addNi.Value;

            addTotal.Text = string.Format("{0:N1}", addMat);

            var ttMetal = Convert.ToDouble(addMetal.Value);
            totMetal.Text = string.Format("{0:N1}", ttMetal);

            var ttRS = CurrentCharge.Rs ?? 0 + Convert.ToDouble(addRS.Value);
            totRS.Text = string.Format("{0:N1}", ttRS);

            var ttSS = CurrentCharge.Ss ?? 0 + Convert.ToDouble(addSS.Value);
            totSS.Text = string.Format("{0:N1}", ttSS);

            var ttPigFC = CurrentCharge.PigFC ?? 0 + Convert.ToDouble(addPigFC.Value);
            totPigFC.Text = string.Format("{0:N1}", ttPigFC);

            var ttPigFCD = CurrentCharge.PigFCD ?? 0 + Convert.ToDouble(addPigFCD.Value);
            totPigFCD.Text = string.Format("{0:N1}", ttPigFCD);

            var ttCFC = CurrentCharge.C_FC ?? 0 + Convert.ToDouble(addCFC.Value);
            totCFC.Text = string.Format("{0:N1}", ttCFC);

            var ttCFCD = CurrentCharge.C_FCD ?? 0 + Convert.ToDouble(addCFCD.Value);
            totCFCD.Text = string.Format("{0:N1}", ttCFCD);

            var ttFeSi = CurrentCharge.Fe_Si ?? 0 + Convert.ToDouble(addSi.Value);
            totSi.Text = string.Format("{0:N1}", ttFeSi);

            var ttFeMn = CurrentCharge.Fe_Mn ?? 0 + Convert.ToDouble(addMn.Value);
            totMn.Text = string.Format("{0:N1}", ttFeMn);

            var ttHcCr = CurrentCharge.HC_Cr ?? 0 + Convert.ToDouble(addCr.Value);
            totCr.Text = string.Format("{0:N1}", ttHcCr);

            var ttFeMo = CurrentCharge.Fe_Mo ?? 0 + Convert.ToDouble(addMo.Value);
            totMo.Text = string.Format("{0:N1}", ttFeMo);

            var ttFeNi = CurrentCharge.Fe_Ni ?? 0 + Convert.ToDouble(addNi.Value);
            totNi.Text = string.Format("{0:N1}", ttFeNi);

            var ttMat = ttMetal + ttRS + ttSS + ttPigFC + ttPigFCD + ttCFC + ttCFCD +
            ttFeSi + ttFeMn + ttHcCr + ttFeMo + ttFeNi;

            totTotal.Text = string.Format("{0:N1}", ttMat);
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            if (tbProductId.Text == null || tbProductId.Text == "")
            {
                MessageBox.Show("Please Set Target Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmCalculator fcal = new frmCalculator(CurrentCharge, CurrentFurnace, controlPlanIdTextBox.Text);
            var result = fcal.ShowDialog();

            if (result == DialogResult.OK)
            {
                addMetal.Value = Convert.ToDecimal(fcal.Material.RemainedMetal);
                addRS.Value = Convert.ToDecimal(fcal.Material.Rs);
                addSS.Value = Convert.ToDecimal(fcal.Material.Ss);
                addPigFC.Value = Convert.ToDecimal(fcal.Material.PigFC);
                addPigFCD.Value = Convert.ToDecimal(fcal.Material.PigFCD);
                addCFC.Value = Convert.ToDecimal(fcal.Material.C_FC);
                addCFCD.Value = Convert.ToDecimal(fcal.Material.C_FCD);
                addSi.Value = Convert.ToDecimal(fcal.Material.Fe_Si);
                addMn.Value = Convert.ToDecimal(fcal.Material.Fe_Mn);
                addCr.Value = Convert.ToDecimal(fcal.Material.HC_Cr);
                addMo.Value = Convert.ToDecimal(fcal.Material.Fe_Mo);
                addNi.Value = Convert.ToDecimal(fcal.Material.Fe_Ni);
                addTotal.Text = Convert.ToDecimal(fcal.Material.Total).ToString("#,##0.0");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
