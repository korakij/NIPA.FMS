using System;
using System.Drawing;
using System.Globalization;
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
        public Charging ResultCharge { get; set; }

        private Charging CurrentCharge;
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
                chargingBindingSource.ResetBindings(false);
                GetTimeInterval();
            }
        }

        private void btnMaxTempTimeRetrieval_Click(object sender, EventArgs e)
        {
            var temp = int.Parse(maxTempTextBox.Text, NumberStyles.AllowThousands, new CultureInfo("en-US"));

            if (temp < 1)
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
                chargingBindingSource.ResetBindings(false);

                timer1.Stop();
                CurrentCharge.Status = Status.Completed.ToString();
                CurrentCharge.Interval = intervalTextBox.Text;
                GetTimeInterval();
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
            //numTbStartKw.Text = string.Format("{0:N2}", ReadMeter());
        }

        private void btnReadMaxPower_Click(object sender, EventArgs e)
        {
            //numTbMaxTemp.Text = string.Format("{0:N2}", ReadMeter());
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
            modbusClient.ConnectionTimeout = 3000;

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

        private void startKwHrTextBox_Leave(object sender, EventArgs e)
        {
            GetPowerConsumtion();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var time = DateTime.Now;
            maxTempTimeTextBox.Text = time.ToString("dd/MM/yy  HH:mm:ss");
            CurrentCharge.MaxTempTime = time;

            GetTimeInterval();
        }

        private void GetPowerConsumtion()
        {
            var stop = Convert.ToDouble(maxTempKwHrTextBox.Text);
            var start = Convert.ToDouble(startKwHrTextBox.Text);

            var power = stop - start;

            if (power <= 0 || start == 0 || stop == 0)
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
        }


        private void maxTempNumericTextBox_TextChanged(object sender, EventArgs e)
        {
            var temp = Convert.ToInt32(maxTempTextBox.Text);

            if (temp <= 0)
                IsMaxTempOk = false;
            else
                IsMaxTempOk = true;

            SetStatus();
        }

        private void maxTempNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

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

            chargingBindingSource.ResetBindings(false);

            ResultCharge = CurrentCharge;
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

            var ttRS = Convert.ToDouble(addRS.Value) + CurrentCharge.Rs ?? 0;
            totRS.Text = string.Format("{0:N1}", ttRS);

            var ttSS = Convert.ToDouble(addSS.Value) + CurrentCharge.Ss ?? 0;
            totSS.Text = string.Format("{0:N1}", ttSS);

            var ttPigFC = Convert.ToDouble(addPigFC.Value) + CurrentCharge.PigFC ?? 0;
            totPigFC.Text = string.Format("{0:N1}", ttPigFC);

            var ttPigFCD = Convert.ToDouble(addPigFCD.Value) + CurrentCharge.PigFCD ?? 0;
            totPigFCD.Text = string.Format("{0:N1}", ttPigFCD);

            var ttCFC = Convert.ToDouble(addCFC.Value) + CurrentCharge.C_FC ?? 0;
            totCFC.Text = string.Format("{0:N1}", ttCFC);

            var ttCFCD = Convert.ToDouble(addCFCD.Value) + CurrentCharge.C_FCD ?? 0;
            totCFCD.Text = string.Format("{0:N1}", ttCFCD);

            var ttFeSi = Convert.ToDouble(addSi.Value) + CurrentCharge.Fe_Si ?? 0;
            totSi.Text = string.Format("{0:N1}", ttFeSi);

            var ttFeMn = Convert.ToDouble(addMn.Value) + CurrentCharge.Fe_Mn ?? 0;
            totMn.Text = string.Format("{0:N1}", ttFeMn);

            var ttHcCr = Convert.ToDouble(addCr.Value) + CurrentCharge.HC_Cr ?? 0;
            totCr.Text = string.Format("{0:N1}", ttHcCr);

            var ttFeMo = Convert.ToDouble(addMo.Value) + CurrentCharge.Fe_Mo ?? 0;
            totMo.Text = string.Format("{0:N1}", ttFeMo);

            var ttFeNi = Convert.ToDouble(addNi.Value) + CurrentCharge.Fe_Ni ?? 0;
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

    }
}
