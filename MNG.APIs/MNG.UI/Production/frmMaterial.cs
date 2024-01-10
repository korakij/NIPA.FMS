using EasyModbus;
using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class frmMaterial : Form
    {
        private List<Charging> _chargings;
        private Client _client;
        private MeltingEventArgs MeltInfo;
        private Charging CurrentCharge;
        private LotNo CurrentLotNo;
        private bool _isDataCompleted;
        private bool _isTimeCompleted;
        private bool _isKwHrCompleted;
        private ModbusClient modbusClient;
        private MaterialSummary MatSummary;
        public event EventHandler<MeltingEventArgs> ChargeNoChanged;
        public event EventHandler<MeltingEventArgs> SummaryUpdate;
        public event EventHandler<FormEventArgs> FormSelected;

        public frmMaterial()
        {
            InitializeComponent();

            MeltInfo = new MeltingEventArgs();
            CurrentCharge = new Charging();
            modbusClient = new ModbusClient();
            MatSummary = new MaterialSummary();
        }

        public bool IsDataCompleted
        {
            get { return _isDataCompleted; }
            set { _isDataCompleted = value; }
        }

        private void frmAddMaterial_Load(object sender, EventArgs e)
        {
            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        public async void E_LotNoChanged(object sender, MeltingEventArgs e)
        {
            if (e.LotNos == null)
            {
                chargingBindingSource.Clear();
                tbHour.Text = "";
                tbMinute.Text = "";
                CurrentLotNo = null;
                CurrentCharge = null;
                return;
            }

            CurrentLotNo = e.LotNos;
            _chargings = (await _client.GetChargingsByLotNoAsync(e.LotNos.Code)).OrderByDescending(x => x.ChargeNo).ToList();
            chargingBindingSource.DataSource = _chargings;

            if (_chargings.Count == 0)
                CurrentCharge = null;
        }

        public async void CreateItem()
        {
            if (CurrentLotNo == null)
            {
                MessageBox.Show("Unable to Create New Charge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var last = new Charging();
            try
            {
                last = (await _client.GetChargingsByLotNoAsync(CurrentLotNo.Code)).LastOrDefault();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable To Create New Charge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (last != null && last.IsCompleted == false)
            {
                MessageBox.Show("Unable To Create New Charge, Last Charge has not completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var count = chargingBindingSource.Count + 1;
            var newChargingNo = $"C-{CurrentLotNo.Code}-{count.ToString("00")}";

            var newCharging = new Charging();
            newCharging.ChargeNo = newChargingNo;
            newCharging.LotNoCode = CurrentLotNo.Code;
            newCharging.Status = Status.Running.ToString();
            newCharging.ChargeTime = DateTime.Now;
            newCharging.MaxTempTime = DateTime.Now;
            newCharging.StartKwHr = 0;
            newCharging.MaxTempKwHr = 0;

            //if (MatSummary == null)
            //    newCharging.RemainedMetal = 0;
            //else
            //    newCharging.RemainedMetal = MatSummary.Remained;

            frmCreateCharge fCreateCharge = new frmCreateCharge(newCharging);

            if (fCreateCharge.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var _chargeItem = fCreateCharge.ChargeItem;
                    var ctp = (await _client.GetControlPlanByIdAsync(_chargeItem.ControlPlanId ?? 0));
                    if(ctp.ChemicalCompositionInFurnaceCode == null)
                    {
                        MessageBox.Show("รายการที่คุณเลือกใน Control plan ไม่มีการระบุค่าเคมีการในเตาหลอม โปรดเลือกรายการอื่น", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    await _client.PostChargingAsync(_chargeItem);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        _chargings = (await _client.GetChargingsByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.ChargeNo).ToList();
                        chargingBindingSource.DataSource = _chargings;

                        chargingBindingSource.Position = 0;
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public async void EditItem()
        {
            if (CurrentCharge == null)
            {
                MessageBox.Show("Unable to Edit Current Charge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmEditMatCharging fMatCharging = new frmEditMatCharging(CurrentCharge);

            fMatCharging.StartPosition = FormStartPosition.Manual;
            fMatCharging.Location = new Point(300, 10);

            DialogResult result = fMatCharging.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutChargingAsync(fMatCharging.ResultCharge.ChargeNo, fMatCharging.ResultCharge);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _chargings = (await _client.GetChargingsByLotNoAsync(CurrentCharge.LotNoCode)).OrderByDescending(x => x.ChargeNo).ToList();
                chargingBindingSource.DataSource = _chargings;

                MeltingEventArgs ln = new MeltingEventArgs();
                MeltInfo.LotNos.Code = CurrentLotNo.Code;

                SummaryUpdate?.Invoke(this, MeltInfo);
            }
            else if (result == DialogResult.Cancel)
            {
                _chargings = (await _client.GetChargingsByLotNoAsync(CurrentCharge.LotNoCode)).OrderByDescending(x => x.ChargeNo).ToList();
                chargingBindingSource.DataSource = _chargings;
            }
        }

        public async void Export()
        {
            if (CurrentCharge == null)
                return;

            var result = MessageBox.Show($"Do you want to Export {CurrentCharge.LotNoCode}?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                var chargeRaw = (await _client.GetChargingsByLotNoAsync(CurrentCharge.LotNoCode)).ToList();
                var chemInFurRaw = (await _client.GetTestsByLotNoAsync(CurrentCharge.LotNoCode)).ToList();
                var chemInLadRaw = (await _client.GetKanbansByLotNoAsync(CurrentCharge.LotNoCode)).ToList();
                var pouringRaw = (await _client.GetPouringsByLotNoAsync(CurrentCharge.LotNoCode)).ToList();

                var prodRaw = (await _client.GetProductAllAsync()).ToList();
                var matSpecRaw = (await _client.GetMaterialSpecificationAllAsync()).ToList();
                var ctpRaw = (await _client.GetControlPlanAllAsync()).ToList();
                var chemInFurStdRaw = (await _client.GetChemicalCompositionInFurnaceAllAsync()).ToList();
                var chemInLadStdRaw = (await _client.GetChemicalCompositionInLadleAllAsync()).ToList();
                var pouringStdRaw = (await _client.GetPouringStandardAllAsync()).ToList();
                var toolingStdRaw = (await _client.GetToolingAllAsync()).ToList();

                var chargeFilter = chargeRaw.Select(x => new { x.ChargeNo, x.ChargeTime, x.MaxTempTime, x.StartKwHr, x.MaxTempKwHr, 
                    x.MaxTemp, x.PigFC, x.PigFCD, x.Ss, x.Rs, x.C_FC, x.C_FCD, x.Fe_Si, x.Fe_Mn, x.HC_Cr, x.Fe_Mo, x.Fe_Ni, x.ProductId });

                var chemInFurFilter = chemInFurRaw.Select(x => new
                {
                    x.Code, x.Time, x.UpdatedTime, x.ChargingCode, x.ProductId, x.IsPassed, 
                    x.Result.Cce,
                    x.Result.C,
                    x.Result.Si,
                    x.Result.Mn,
                    x.Result.Mg,
                    x.Result.S,
                    x.Result.Al,
                    x.Result.Cu,
                    x.Result.Sn,
                    x.Result.Cr,
                    x.Result.P,
                    x.Result.Mo,
                    x.Result.Ni,
                    x.Result.V,
                    x.Result.Ti,
                    x.Result.Te
                });

                var chemInLadFilter = chemInLadRaw.Select(x => new
                {
                    x.Code, x.Time, x.UpdatedTime, x.TestChemicalCompositionCode, x.MaterialCode, x.Weight, x.KwHr,
                    x.Inoculant, x.WireInoculant, x.Magnesium, x.WireMagnesium, x.Copper, x.Tin, x. FeedTemp, x.Chill,
                    x.IsPassed,
                    x.IsCompleted,
                    x.Result.Cce,
                    x.Result.C,
                    x.Result.Si,
                    x.Result.Mn,
                    x.Result.Mg,
                    x.Result.S,
                    x.Result.Al,
                    x.Result.Cu,
                    x.Result.Sn,
                    x.Result.Cr,
                    x.Result.P,
                    x.Result.Mo,
                    x.Result.Ni,
                    x.Result.V,
                    x.Result.Ti,
                    x.Result.Te
                });

                var pouringFilter = pouringRaw.Select(x => new
                {
                    x.Code, x.FirstMoldTime, x.LastMoldTime, x.Duration, x.LineCode, x.FirstTemp, x.LastTemp,
                    x.NoOfPouredMold, x.ProductNo, x.PouredWeight, x.ProductCode, x.KanbanCode, x.MoldingCode, x.Defect
                    //x.Defect.MeltDefect, x.Defect.MoldDefect, x.Defect.PourDefect, x.Defect.FinDefect, x.Defect.EngDefect, x.Defect.CoreDefect,
                    //x.Defect.TotalNumber, x.Defect.TotalGood, x.Defect.TotalDefect, x.Defect.DefectRate, x.Defect.TotalWeight,
                    //x.Defect.TotalGoodWeight, x.Defect.TotalDefectWeight, x.Defect.DefectWeightRate
                }) ;

                var chemInFurStdFilter = chemInFurStdRaw.Select(x => new
                {
                    x.Code,
                    x.CceMax,
                    x.CceMin,
                    x.CMax,
                    x.CMin,
                    x.SiMax,
                    x.SiMin,
                    x.MnMax,
                    x.MnMin,
                    x.MgMax,
                    x.MgMin,
                    x.SMax,
                    x.SMin,
                    x.AlMax,
                    x.AlMin,
                    x.CuMax,
                    x.CuMin,
                    x.SnMax,
                    x.SnMin,
                    x.CrMax,
                    x.CrMin,
                    x.PMax,
                    x.PMin,
                    x.MoMax,
                    x.MoMin,
                    x.NiMax,
                    x.NiMin,
                    x.VMax,
                    x.VMin,
                    x.TiMax,
                    x.TiMin,
                    x.TeMax,
                    x.TeMin
                });

                var chemInLadStdFilter = chemInLadStdRaw.Select(x => new
                {
                    x.Code,
                    x.CceMax,
                    x.CceMin,
                    x.CMax,
                    x.CMin,
                    x.SiMax,
                    x.SiMin,
                    x.MnMax,
                    x.MnMin,
                    x.MgMax,
                    x.MgMin,
                    x.SMax,
                    x.SMin,
                    x.AlMax,
                    x.AlMin,
                    x.CuMax,
                    x.CuMin,
                    x.SnMax,
                    x.SnMin,
                    x.CrMax,
                    x.CrMin,
                    x.PMax,
                    x.PMin,
                    x.MoMax,
                    x.MoMin,
                    x.NiMax,
                    x.NiMin,
                    x.VMax,
                    x.VMin,
                    x.TiMax,
                    x.TiMin,
                    x.TeMax,
                    x.TeMin
                });

                var prodFilter = prodRaw.Select(x => new { x.Id, x.Code, x.Name, x.Weight, x.MaterialCode, x.ActiveControlPlanId });
                var ctpFilter = ctpRaw.Select(x => new
                {
                    x.Id,
                    x.Code,
                    x.ProductId,
                    x.MaterialSpecificationCode,
                    x.MeltingCode,
                    x.ChemicalCompositionInFurnaceCode,
                    x.ChemicalCompositionInLadleCode,
                    x.PouringCode,
                    x.MoldingCode,
                    x.ShotBlastingCode,
                    x.ToolingCode
                });
                
                ExcelMapper mapper = new ExcelMapper();
                var newfile = $@"\\192.168.2.3\wmw\Department\Production\2023\Report\DAT-{CurrentCharge.LotNoCode}.xlsx";

                mapper.Save(newfile, ctpFilter, "tbCTP", true);
                mapper.Save(newfile, chargeFilter, "Charging",true);
                mapper.Save(newfile, chemInFurFilter, "TestChemInFur", true);
                mapper.Save(newfile, chemInLadFilter, "TestChemInLad", true);
                mapper.Save(newfile, prodFilter, "tbProducts", true);
                mapper.Save(newfile, matSpecRaw, "tbMatSpec", true);
                mapper.Save(newfile, chemInFurStdFilter, "tbChemInFurStd", true);
                mapper.Save(newfile, chemInLadStdFilter, "tbChemInLadStd", true);
                mapper.Save(newfile, pouringFilter, "Pouring", true);
                mapper.Save(newfile, pouringStdRaw, "tbPouringStd", true);
                mapper.Save(newfile, toolingStdRaw, "tbToolingStd", true);

                //mapper.Save(newfile, chemInFurRaw, "Pouring", true);
            }
        }

        public async void DeleteItem()
        {
            if (CurrentCharge == null)
                return;

            var result = MessageBox.Show($"Do you want to delete {CurrentCharge.ChargeNo}?\nThe Entire Data Lot No will be deleted", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                var cnt = (await _client.GetTestNoByChargeNoAsync(CurrentCharge.ChargeNo)).Count;

                if (cnt != 0)
                {
                    MessageBox.Show("Unable to Delete because this charge has already been tested chem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    await _client.DeleteChargingAsync(CurrentCharge.ChargeNo);
                    MessageBox.Show($"{CurrentCharge.ChargeNo} has been delete", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _chargings = (await _client.GetChargingsByLotNoAsync(CurrentLotNo.Code)).OrderByDescending(x => x.ChargeNo).ToList();
                    chargingBindingSource.DataSource = _chargings;
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void MatSumUpdated(object sender, MatSummaryEventArgs e)
        {
            MatSummary = e.MatSum;
        }

        private void chargingBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CurrentCharge = chargingBindingSource.Current as Charging;

            var chargeInfo = new MeltingEventArgs();

            if (CurrentCharge == null)
            {
                ChargeNoChanged?.Invoke(this, chargeInfo);
                return;
            }

            statusTextBox1.Text = CurrentCharge.Status;
            tbHour.Text = (CurrentCharge.MaxTempTime - CurrentCharge.ChargeTime).Value.TotalHours.ToString("00");
            tbMinute.Text = (CurrentCharge.MaxTempTime - CurrentCharge.ChargeTime).Value.Minutes.ToString("00");

            if (CurrentCharge == null)
            {
                ChargeNoChanged?.Invoke(this, chargeInfo);
                return;
            }

            chargeInfo.ChargeNo = CurrentCharge;
            ChargeNoChanged?.Invoke(this, chargeInfo);
        }

        private void startKwHrTextBox_TextChanged(object sender, EventArgs e)
        {
            double? kwDiff;
            int MaxTemp;

            if (maxTempKwHrTextBox.Text == "" || startKwHrTextBox.Text == "")
            {
                _isKwHrCompleted = false;
                tbKwHrPerCharge.Text = "";
                return;
            }

            kwDiff = Convert.ToDouble(maxTempKwHrTextBox.Text) - Convert.ToDouble(startKwHrTextBox.Text);
            tbKwHrPerCharge.Text = string.Format("{0:0.00}", kwDiff);

            if (string.IsNullOrEmpty(maxTempTextBox.Text))
                MaxTemp = 0;
            else
                MaxTemp = Convert.ToInt32(maxTempTextBox.Text);

            if (kwDiff > 0 && MaxTemp > 0)
                _isKwHrCompleted = true;
            else
                _isKwHrCompleted = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var fName = new FormEventArgs();
            fName.Name = FormName.frmMaterial;

            FormSelected?.Invoke(this, fName);
        }

        public void FormEnableSelection()
        {
            pnBorderBottom.BackColor = Color.MidnightBlue;
            pnBorderTop.BackColor = Color.MidnightBlue;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.Color.Black;
        }

        public void FormDisableSelection()
        {
            pnBorderBottom.BackColor = Color.White;
            pnBorderTop.BackColor = Color.White;
            lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbHeader.ForeColor = System.Drawing.SystemColors.ControlDark;
        }
    }
}
