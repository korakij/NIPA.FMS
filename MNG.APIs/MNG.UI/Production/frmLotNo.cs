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
    public partial class frmLotNo : Form
    {
        private List<LotNo> _lotNos;
        private Client _client;
        private LotNo CurrentLotNo;
        private Furnace Furnace;

        public event EventHandler<MeltingEventArgs> LotNoChanged;
        public event EventHandler<MeltingEventArgs> LotNoChangedInPouring;
        public event EventHandler<FormEventArgs> FormSelected;

        public frmLotNo(Furnace _fur)
        {
            InitializeComponent();

            _lotNos = new List<LotNo>();
            CurrentLotNo = new LotNo();
            Furnace = new Furnace();

            var dt = DateTime.Now;
            var year = dt.Year.ToString().Substring(2,2);
            var month = dt.Month;

            Furnace = _fur;
            timer1.Interval = Properties.Settings.Default.Refresh_Rate;
            timer1.Start();
        }

        public void EnableLotUpdatedTimer() => timer1.Enabled = true;
        public void DisableLotUpdatedTimer() => timer1.Enabled = false;

        private async void frmLotNo_Load(object sender, EventArgs e)
        {
            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            cboYear.SelectedIndex = DateTime.Now.Year - 2019;
            cboMonth.SelectedIndex = DateTime.Now.Month - 1;

            //if (Furnace.Code == null)
            //    _lotNos = (await _client.GetLotNoByFilterAsync(GetDateMonth())).OrderByDescending(x => x.Code).ToList();
            //else
            //    _lotNos = (await _client.GetLotNoByFilterAsync(GetDateMonth())).OrderByDescending(x => x.Code).Where(y => y.Code.Substring(7, 1) == Furnace.Code).ToList();

            //lotNoBindingSource.DataSource = _lotNos;
            //lotNoBindingSource.Position = 0;
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

        public async void CreateItem()
        {
            var fCreateLotNo = new frmLotNoInfo();
            var newLot = new LotNo();

            if (fCreateLotNo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    newLot.Code = fCreateLotNo.LotNo;
                    newLot.Date = fCreateLotNo.Date;
                    newLot.Shift = fCreateLotNo.Shift;
                    newLot.FurnaceCode = fCreateLotNo.Furnace;

                    await _client.PostLotNoAsync(newLot);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        if (Furnace.Code == null)
                            _lotNos = (await _client.GetLotNoByFilterAsync(GetDateMonth())).OrderByDescending(x => x.Code).ToList();
                        else
                            _lotNos = (await _client.GetLotNoByFilterAsync(GetDateMonth())).OrderByDescending(x => x.Code).Where(y => y.Code.Substring(7, 1) == Furnace.Code).ToList();

                        lotNoBindingSource.DataSource = _lotNos;
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            fCreateLotNo.Close();
        }

        public void EditItem()
        {
            MessageBox.Show("Unable to Edit LotNo");
        }

        public async void DeleteItem()
        {
            if (CurrentLotNo == null)
                return;

            var result = MessageBox.Show($"Do you want to delete {CurrentLotNo.Code}?\nThe Entire Data Lot No will be deleted", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    await _client.DeleteLotNoAsync(CurrentLotNo.Code);
                    MessageBox.Show($"{CurrentLotNo.Code} has been delete", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (Furnace.Code == null)
                        _lotNos = (await _client.GetLotNoByFilterAsync(GetDateMonth())).OrderByDescending(x => x.Code).ToList();
                    else
                        _lotNos = (await _client.GetLotNoByFilterAsync(GetDateMonth())).OrderByDescending(x => x.Code).Where(y => y.Code.Substring(7, 1) == Furnace.Code).ToList();

                    lotNoBindingSource.DataSource = _lotNos;

                    cboYear_SelectedIndexChanged(this, EventArgs.Empty);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void Export()
        {
        }

        private void lotNoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CurrentLotNo = lotNoBindingSource.Current as LotNo;

            //if (CurrentLotNo == null)
            //    return;

            var ln = new MeltingEventArgs();
            ln.LotNos = CurrentLotNo;

            LotNoChanged?.Invoke(this, ln);

            //if (ln.LotNos != null)
            //{
            //    var lotNo = ln.LotNos.Code.Substring(0, 6);
            //    ln.LotNos.Code = lotNo;
            //}

            //LotNoChangedInPouring?.Invoke(this, ln);
        }

        private async void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dateMtn = GetDateMonth();
            if (dateMtn.Count() < 4)
                return;

            if (Furnace.Code == "All")
            {
                var dmd = $"{cboYear.Text.Substring(2, 2)}{cboMonth.Text}{cboDate.Text}";
                _lotNos = (await _client.GetLotNoByFilterAsync(dmd)).OrderByDescending(x => x.Code).ToList();
            }
            else
            {
                var dmd = $"{cboYear.Text.Substring(2, 2)}{cboMonth.Text}{cboDate.Text}";
                var lots = (await _client.GetLotNoByFilterAsync(dmd)).OrderByDescending(x => x.Code).ToList();
                _lotNos = lots.Where(x => x.Code.Substring(7) == Furnace.Code).ToList();

                //_lotNos = (await _client.GetLotNoAllAsync()).Where(x => x.Code.Substring(0, 4) == dateMtn).ToList();
                //_lotNos = (await _client.GetLotNoByFilterAsync(GetDateMonth())).OrderByDescending(x => x.Code).Where(y => y.Code.Substring(7, 1) == Furnace.Code).ToList();
            }

            lotNoBindingSource.DataSource = _lotNos;

            //if (_lotNos.Count == 0)
            //    lotNoBindingSource_CurrentChanged(this, EventArgs.Empty);
        }

        private string GetDateMonth()
        {
            //var lot = $"{cboYear.Text.Substring(2, 2)}{cboMonth.Text}{cboDate.Text}";
            var lot = $"{cboYear.Text.Substring(2, 2)}{cboMonth.Text}";

            return lot;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            var dm = $"{cboYear.Text.Substring(2, 2)}{cboMonth.Text}";

            var currentLots = _lotNos.Where(x => x.Code.Substring(0, 4) == dm).OrderByDescending(x => x.Code).ToList();
            var dbLots = new List<LotNo>();

            if (Furnace.Code == "All")
            {
                var dmd = $"{cboYear.Text.Substring(2, 2)}{cboMonth.Text}{cboDate.Text}";
                dbLots = (await _client.GetLotNoByFilterAsync(dmd)).OrderByDescending(x => x.Code).ToList();
            }
            else
            {
                dbLots = (await _client.GetLotNoByFilterAsync(dm)).OrderByDescending(x => x.Code).Where(y => y.Code.Substring(7, 1) == Furnace.Code).ToList();
            }

            if (currentLots.Count != dbLots.Count)
            {
                _lotNos = dbLots;
                lotNoBindingSource.DataSource = _lotNos;
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var fName = new FormEventArgs();
            fName.Name = FormName.frmLotNo;

            FormSelected?.Invoke(this, fName);
        }
    }
}
