using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ASRS.UI;
using EasyModbus;

namespace MNG.UI.Production
{
    public partial class frmCalculator : Form
    {
        public Charging CurrentCharge { get; set; }
        public Charging Material { get; set; }
        private Client _client;
        private Furnace CurrentFurnace;
        private int resolution = 10;
        private int ActiveCTPId;

        private decimal CrequiredQty;
        private decimal SirequiredQty;
        private decimal MnrequiredQty;
        private decimal CrrequiredQty;
        private decimal NirequiredQty;
        private decimal MorequiredQty;


        public frmCalculator(Charging _currentCharge, Furnace _currentFurnace, string _activeCTPId)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CurrentCharge = new Charging();
            Material = new Charging();
            CurrentCharge = _currentCharge;

            CurrentFurnace = new Furnace();
            CurrentFurnace = _currentFurnace;

            ActiveCTPId = Convert.ToInt32(_activeCTPId);
            ResetCal();
        }

        private async void frmEditMatCharging_Load(object sender, EventArgs e)
        {
            var ctp = (await _client.GetControlPlanByIdAsync(ActiveCTPId));
            var ChemInFur = (await _client.GetChemicalCompositionInFurnaceByIdAsync(ctp.ChemicalCompositionInFurnaceCode));

            chargingBindingSource.DataSource = CurrentCharge;
            chemicalCompositionInFurnaceBindingSource.DataSource = ChemInFur;
            controlPlanBindingSource.DataSource = ctp;

            GetTargetChem(ChemInFur);

            if (CurrentCharge.ProductId != null)
            {
                var p = await _client.GetProductByIdAsync(CurrentCharge.ProductId ?? 0);
                productBindingSource.DataSource = p;
            }
        }

        private void ResetCal()
        {
            calCFC.Text = "0.0";
            calCFCD.Text = "0.0";
            calSi.Text = "0.0";
            calMn.Text = "0.0";
            calCr.Text = "0.0";
            calMo.Text = "0.0";
            calNi.Text = "0.0";

            TargetC.Value = 0;
            TargetSi.Value = 0;
            TargetMn.Value = 0;

            tbSsPrice.Text = "";
            tbPigFcdPrice.Text = "";
            tbPigFcPrice.Text = "";

            tbTotalC.Text = "";
            tbTotalSi.Text = "";
            tbTotalMn.Text = "";
        }

        private void rsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void GetTotal()
        {
            chargingBindingSource.EndEdit();

            GetTotalCarbon();
            GetTotalSilicon();
            GetTotalManganese();
            GetTotalPrice();

            var totalReq = RsQty.Value + SsQty.Value + PigFcQty.Value + PigFcQty.Value +
                CrequiredQty + SirequiredQty + MnrequiredQty + CrrequiredQty +
                MorequiredQty + NirequiredQty;

            calTotal.Text = totalReq.ToString("#,##0.0");

        }

        private void GetTotalPrice()
        {
            var SSPrice = SsQty.Value * SSCost.Value;
            var PigFcPrice = PigFcQty.Value * PigFcCost.Value;
            var PigFcdPrice = PigFcdQty.Value * PigFcdCost.Value;
            var CFcPrice = Convert.ToDecimal(calCFC.Text) * CfcCost.Value;
            var CFcdPrice = Convert.ToDecimal(calCFCD.Text) * CfcdCost.Value;
            var SiPrice = SirequiredQty * SiCost.Value;
            var MnPrice = MnrequiredQty * MnCost.Value;
            var CrPrice = CrrequiredQty * CrCost.Value;
            var MoPrice = MorequiredQty * MoCost.Value;
            var NiPrice = NirequiredQty * NiCost.Value;

            var totalPrice = SSPrice + PigFcPrice + PigFcdPrice + CFcPrice + CFcdPrice + SiPrice +
                MnPrice + CrPrice + NiPrice + MoPrice;

            tbSsPrice.Text = SSPrice.ToString("#,##0.0");
            tbPigFcPrice.Text = PigFcPrice.ToString("#,##0.0");
            tbPigFcdPrice.Text = PigFcdPrice.ToString("#,##0.0");
            tbCfcPrice.Text = CFcPrice.ToString("#,##0.0");
            tbCfcdPrice.Text = CFcdPrice.ToString("#,##0.0");
            tbSiPrice.Text = SiPrice.ToString("#,##0.0");
            tbMnPrice.Text = MnPrice.ToString("#,##0.0");
            tbCrPrice.Text = CrPrice.ToString("#,##0.0");
            tbNiPrice.Text = NiPrice.ToString("#,##0.0");
            tbMoPrice.Text = MoPrice.ToString("#,##0.0");

            tbTotalPrice.Text = totalPrice.ToString("###,##0.0");

            var totalQty = SsQty.Value + PigFcQty.Value + PigFcdQty.Value;

            if (totalQty == 0)
                return;

            tbUnitCost.Text = decimal.Divide(totalPrice, totalQty).ToString("#,##0.00");
        }

        private void GetTotalCarbon()
        {
            var CQtyInMetal = CInMetal.Value * MetalQty.Value * MetalContent.Value * MetalEff.Value;
            var CQtyInSS = CinSS.Value * SsQty.Value * SsContent.Value * SsEff.Value;
            var CQtyInRS = CinRs.Value * RsQty.Value * RsContent.Value * RsEff.Value;
            var CQtyInPigFC = CInPigFc.Value * PigFcQty.Value * PigFcContent.Value * PigFcEff.Value;
            var CQtyInPigFCD = CInPigFcd.Value * PigFcdQty.Value * PigFcdContent.Value * PigFcdEff.Value;
            var TotalMetal = MetalQty.Value + SsQty.Value + RsQty.Value + PigFcQty.Value + PigFcdQty.Value;

            var totalC = decimal.Divide(CQtyInMetal, 100) + decimal.Divide(CQtyInSS, 100) + decimal.Divide(CQtyInRS, 100) +
                decimal.Divide(CQtyInPigFC, 100) + decimal.Divide(CQtyInPigFCD, 100);

            tbTotalC.Text = totalC.ToString("#0.0");
            CrequiredQty = (TargetC.Value * (MetalQty.Value + RsQty.Value + SsQty.Value) / 100 - totalC) / CfcContent.Value / CfcEff.Value;

            if (CrequiredQty < 0)
            {
                MessageBox.Show("C qty < 0.0 kg", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CrequiredQty = 0;
            }

            if (cbFC.Checked == true && cbFCD.Checked == true)
            {
                CrequiredQty = decimal.Divide(CrequiredQty, 2);
                calCFC.Text = Convert.ToDouble(CrequiredQty).ToString("#0.0");
                calCFCD.Text = Convert.ToDouble(CrequiredQty).ToString("#0.0");
            }
            else if (cbFC.Checked == false && cbFCD.Checked == true)
            {
                calCFC.Text = Convert.ToDouble(0).ToString("#0.0");
                calCFCD.Text = Convert.ToDouble(CrequiredQty).ToString("#0.0");
            }
            else if (cbFC.Checked == true && cbFCD.Checked == false)
            {
                calCFC.Text = Convert.ToDouble(CrequiredQty).ToString("#0.0");
                calCFCD.Text = Convert.ToDouble(0).ToString("#0.0");
            }
            else if (cbFC.Checked == false && cbFCD.Checked == false)
            {
                calCFC.Text = Convert.ToDouble(0).ToString("#0.0");
                calCFCD.Text = Convert.ToDouble(0).ToString("#0.0");
            }
        }


        private void GetTotalSilicon()
        {
            var SiQtyInMetal = SiInMetal.Value * MetalQty.Value * MetalContent.Value * MetalEff.Value;
            var SiQtyInSS = SiInSS.Value * SsQty.Value * SsContent.Value * SsEff.Value;
            var SiQtyInRs = SiInRs.Value * RsQty.Value * RsContent.Value * RsEff.Value;
            var SiQtyInPigFC = SiInPigFc.Value * PigFcQty.Value * PigFcContent.Value * PigFcEff.Value;
            var SiQtyInPigFCD = SiInPigFcd.Value * PigFcdQty.Value * PigFcdContent.Value * PigFcdEff.Value;

            var totalSi = decimal.Divide(SiQtyInMetal, 100) + decimal.Divide(SiQtyInSS, 100) + decimal.Divide(SiQtyInRs, 100) +
                decimal.Divide(SiQtyInPigFC, 100) + decimal.Divide(SiQtyInPigFCD, 100);

            tbTotalSi.Text = totalSi.ToString("#0.0");
            SirequiredQty = (TargetSi.Value * (MetalQty.Value + RsQty.Value + SsQty.Value) / 100 - totalSi) / SiContent.Value / SiEff.Value;

            if (SirequiredQty < 0)
            {
                MessageBox.Show("Si qty < 0.0 kg", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SirequiredQty = 0;
            }

            calSi.Text = Convert.ToDouble(SirequiredQty).ToString("#0.0");
        }

        private void GetTotalManganese()
        {
            var MnQtyInMetal = MnInMetal.Value * MetalQty.Value * MetalContent.Value * MetalEff.Value;
            var MnQtyInSS = MnInSS.Value * SsQty.Value * SsContent.Value * SsEff.Value;
            var MnQtyInRs = MnInRs.Value * RsQty.Value * RsContent.Value * RsEff.Value;
            var MnQtyInPigFC = MnInPigFc.Value * PigFcQty.Value * PigFcContent.Value * PigFcEff.Value;
            var MnQtyInPigFCD = MnInPigFcd.Value * PigFcdQty.Value * PigFcdContent.Value * PigFcdEff.Value;

            var totalMn = decimal.Divide(MnQtyInMetal, 100) + decimal.Divide(MnQtyInSS, 100) + decimal.Divide(MnQtyInRs, 100) +
                decimal.Divide(MnQtyInPigFC, 100) + decimal.Divide(MnQtyInPigFCD, 100);

            tbTotalMn.Text = totalMn.ToString("#0.0");
            MnrequiredQty = (TargetMn.Value * (MetalQty.Value + RsQty.Value + SsQty.Value) / 100 - totalMn) / MnContent.Value / MnEff.Value;

            if (MnrequiredQty < 0)
            {
                MessageBox.Show("Mn qty < 0.0 kg", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MnrequiredQty = 0;
            }

            calMn.Text = Convert.ToDouble(MnrequiredQty).ToString("#0.0");
        }

        private void cbFC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFC.Checked == true || cbFCD.Checked == true)
                GetTotal();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            chargingBindingSource.CancelEdit();
            this.Close();
        }

        private async void btnBrowse_Click(object sender, EventArgs e)
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

                productBindingSource.DataSource = p;
                chemicalCompositionInFurnaceBindingSource.DataSource = ChemStd;
                controlPlanBindingSource.DataSource = cp;

                GetTargetChem(ChemStd);
                GetTotal();
            }
        }

        private void GetTargetChem(ChemicalCompositionInFurnace ChemStd)
        {
            var C = ((ChemStd.CceMax ?? 0) + (ChemStd.CceMin ?? 0)) / 2f;
            var Si = ((ChemStd.SiMax ?? 0) + (ChemStd.SiMin ?? 0)) / 2f;
            var Mn = ((ChemStd.MnMax ?? 0) + (ChemStd.MnMin ?? 0)) / 2f;

            TargetC.Value = Convert.ToDecimal(C);
            TargetSi.Value = Convert.ToDecimal(Si);
            TargetMn.Value = Convert.ToDecimal(Mn);

            tbAvgC.Text = C.ToString("0.00");
            tbAvgSi.Text = Si.ToString("0.00");
            tbAvgMn.Text = Mn.ToString("0.00");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SSCost_ValueChanged(object sender, EventArgs e)
        {
            GetTotal();
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            chargingBindingSource.EndEdit();
            CurrentCharge = chargingBindingSource.Current as Charging;

            try
            {
                Material.Rs = Convert.ToSingle(RsQty.Value);
                Material.Ss = Convert.ToSingle(SsQty.Value);
                Material.PigFC = Convert.ToSingle(PigFcQty.Value);
                Material.PigFCD = Convert.ToSingle(PigFcdQty.Value);
                Material.C_FC = Convert.ToSingle(calCFC.Text);
                Material.C_FCD = Convert.ToSingle(calCFCD.Text);
                Material.Fe_Si = Convert.ToSingle(calSi.Text);
                Material.Fe_Mn = Convert.ToSingle(calMn.Text);
                Material.HC_Cr = Convert.ToSingle(calCr.Text);
                Material.Fe_Mo = Convert.ToSingle(calMo.Text);
                Material.Fe_Ni = Convert.ToSingle(calNi.Text);
                Material.Total = Convert.ToSingle(calTotal.Text);

                btnOk.DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show("Data Error");
                btnOk.DialogResult = DialogResult.None;
            }

        }

        private async void cbLastChem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLastChem.Checked)
            {
                if (CurrentCharge == null)
                    return;

                var chem = (await _client.GetTestNoByLotNoFilterAsync(CurrentCharge.LotNoCode)).LastOrDefault();
                if (chem == null)
                    return;

                CInMetal.Value = Convert.ToDecimal(chem.Result.Cce);
                SiInMetal.Value = Convert.ToDecimal(chem.Result.Si);
                MnInMetal.Value = Convert.ToDecimal(chem.Result.Mn);
            }
            else
            {
                CInMetal.Value = 0;
                SiInMetal.Value = 0;
                MnInMetal.Value = 0;
            }
        }

        private void CInMetal_ValueChanged(object sender, EventArgs e)
        {
            GetTotal();
        }

        private void TargetC_ValueChanged(object sender, EventArgs e)
        {
            GetTotal();
        }
    }
}
