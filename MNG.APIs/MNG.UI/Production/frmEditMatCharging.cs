using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ASRS.UI;
using EasyModbus;
using NPOI.OpenXmlFormats.Dml.Diagram;
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

            actRemainMetal.Value = Convert.ToDecimal(CurrentCharge.RemainedMetal);
            actRS.Value = Convert.ToDecimal(CurrentCharge.Rs);
            actSS.Value = Convert.ToDecimal(CurrentCharge.Ss);
            actPigFC.Value = Convert.ToDecimal(CurrentCharge.PigFC);
            actPigFCD.Value = Convert.ToDecimal(CurrentCharge.PigFCD);
            actCFC.Value = Convert.ToDecimal(CurrentCharge.C_FC);
            actCFCD.Value = Convert.ToDecimal(CurrentCharge.C_FCD);
            actSi.Value = Convert.ToDecimal(CurrentCharge.Fe_Si);
            actMn.Value = Convert.ToDecimal(CurrentCharge.Fe_Mn);
            actCr.Value = Convert.ToDecimal(CurrentCharge.HC_Cr);
            actMo.Value = Convert.ToDecimal(CurrentCharge.Fe_Mo);
            actNi.Value = Convert.ToDecimal(CurrentCharge.Fe_Ni);
            actTotal.Text = Convert.ToDecimal(CurrentCharge.Total).ToString("#,##0.0");

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
            startKwHrNumericUpDown.Text = ReadMeter().ToString("###,##0.00");
        }

        private void btnReadMaxPower_Click(object sender, EventArgs e)
        {
            btnReadMaxPower.Text = ReadMeter().ToString("###,##0.00");
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            chargingBindingSource.CancelEdit();
            this.Close();
        }

        private int ReadMeter()
        {
            var ip = Properties.Settings.Default.PMeter1;
            ModbusClient modbusClient = new ModbusClient();

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

            var data = modbusClient.ReadHoldingRegisters(26, 2);
            var leftBit = Convert.ToString(data[0], 2);
            var rightBit = Convert.ToString(data[1], 2);

            rightBit = rightBit.PadLeft(4, '0');
            var x = rightBit;
            if (rightBit.Length > 16)
            {
                x = rightBit.Substring(rightBit.Length - 16, 16);
            }

            var leftDec = Convert.ToInt32(leftBit + "0000000000000000", 2);
            var rightDec = Convert.ToInt32(x, 2);
            var result = (leftDec + rightDec) / 100;

            modbusClient.Disconnect();

            return result;
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

            chargingBindingSource.EndEdit();
            CurrentCharge = chargingBindingSource.Current as Charging;

            CurrentCharge.RemainedMetal = totRemainMetal.Text == "" ? 0 : Convert.ToDouble(totRemainMetal.Text);
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
            totRemainMetal.Text = Convert.ToDouble(actRemainMetal.Value + addRemainMetal.Value).ToString("#,##0.0");
            totRS.Text = Convert.ToDouble(actRS.Value + addRS.Value).ToString("#,##0.0");
            totSS.Text = Convert.ToDouble(actSS.Value + addSS.Value).ToString("#,##0.0");
            totPigFC.Text = Convert.ToDouble(actPigFC.Value + addPigFC.Value).ToString("#,##0.0");
            totPigFCD.Text = Convert.ToDouble(actPigFCD.Value + addPigFCD.Value).ToString("#,##0.0");
            totCFC.Text = Convert.ToDouble(actCFC.Value + addCFC.Value).ToString("#,##0.0");
            totCFCD.Text = Convert.ToDouble(actCFCD.Value + addCFCD.Value).ToString("#,##0.0");
            totSi.Text = Convert.ToDouble(actSi.Value + addSi.Value).ToString("#,##0.0");
            totMn.Text = Convert.ToDouble(actMn.Value + addMn.Value).ToString("#,##0.00");
            totCr.Text = Convert.ToDouble(actCr.Value + addCr.Value).ToString("#,##0.0");
            totMo.Text = Convert.ToDouble(actMo.Value + addMo.Value).ToString("#,##0.0");
            totNi.Text = Convert.ToDouble(actNi.Value + addNi.Value).ToString("#,##0.0");

            actTotal.Text = Convert.ToDouble(actRS.Value + actSS.Value + actPigFC.Value +
                actPigFCD.Value + actCFC.Value + actCFCD.Value + actSi.Value + actMn.Value + actCr.Value +
                actMo.Value + actNi.Value).ToString("#,##0.0");

            addTotal.Text = Convert.ToDouble(addRS.Value + addSS.Value + addPigFC.Value +
                addPigFCD.Value + addCFC.Value + addCFCD.Value + addSi.Value + addMn.Value + addCr.Value +
                addMo.Value + addNi.Value).ToString("#,##0.0");

            var tot = Convert.ToDouble(actTotal.Text) + Convert.ToDouble(addTotal.Text);
            totTotal.Text = tot.ToString("#,##0.0");
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
                addRemainMetal.Value = Convert.ToDecimal(fcal.Material.RemainedMetal);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar))
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                        int valueBefore = Int32.Parse(textBox1.Text, System.Globalization.NumberStyles.AllowThousands);
                        textBox1.Text = String.Format(culture, "{0:N0}", valueBefore);
                        textBox1.Select(textBox1.Text.Length, 0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string s = textBox1.Text;

            if (s.Length > 0)
            {

            }
        }

        private void textBox1_CursorChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Focus();
            tb.Select(tb.Text.Length, 0);
        }
    }
}
