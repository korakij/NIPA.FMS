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
    public partial class frmInspection : Form
    {
        private Client _client;
        private Product CurrentProduct;
        private LotNo CurrentLotNo;
        private Kanban CurrentKanban;
        private Pouring CurrentPouring;
        private List<Pouring> _pourings;
        private ControlPlan CurrentControlPlan;
        private PourStandard CurrentPourStandard;

        private bool IsSaved;
        private bool IsLoaded = false;

        private int? meltingDefect;
        private int? moldingDefect;
        private int? pouringDefect;
        private int? finDefect;
        private int? engDefect;
        private int? coreDefect;

        public event EventHandler<FormEventArgs> FormSelected;

        public Pouring PouringItem { get; set; }

        public frmInspection()
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CurrentLotNo = new LotNo();
            CurrentKanban = new Kanban();
            CurrentControlPlan = new ControlPlan();
            CurrentPouring = new Pouring();
            CurrentPourStandard = new PourStandard();
            CurrentProduct = new Product();
        }

        public frmInspection(Pouring _pouring, Product _product)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CurrentProduct = new Product();
            CurrentProduct = _product;

            pouringBindingSource.DataSource = _pouring;
        }

        public void EnableToolBar() => pnToolBar.Show();
        public void DisableToolBar() => pnToolBar.Hide();

        private async void frmEditQC_Load(object sender, EventArgs e)
        {
            //IsSaved = false;
            //btnSave.Enabled = false;

            ////pouringBindingSource.DataSource = PouringItem;
            //IsLoaded = true;

            //meltingDefect = PouringItem.Defect.MeltDefect.Total ?? 0;
            //moldingDefect = PouringItem.Defect.MoldDefect.Total ?? 0;
            //pouringDefect = PouringItem.Defect.PourDefect.Total ?? 0;
            //finDefect = PouringItem.Defect.FinDefect.Total ?? 0;
            //engDefect = PouringItem.Defect.EngDefect.Total ?? 0;
            //coreDefect = PouringItem.Defect.CoreDefect.Total ?? 0;

            //ProductItem = (await _client.GetProductByIdAsync(PouringItem.ProductCode));
            //productBindingSource.DataSource = ProductItem;

        }

        public async void PouringIntoMoldChanged(object sender, MeltingEventArgs e)
        {
            CurrentPouring = e.PouringNo;
            pouringBindingSource.DataSource = CurrentPouring;

            CurrentProduct = await _client.GetProductByIdAsync(CurrentPouring.ProductCode);
        }

        public async void EditItem()
        {
            CurrentPouring = pouringBindingSource.Current as Pouring;

            if (CurrentPouring == null)
            {
                MessageBox.Show("Unable to Edit Current Pouring", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmInspection fInspection = new frmInspection(CurrentPouring, CurrentProduct);
            fInspection.Height = 950;
            fInspection.StartPosition = FormStartPosition.Manual;
            var y = Screen.PrimaryScreen.WorkingArea.Height;
            var x = Screen.PrimaryScreen.WorkingArea.Width;

            fInspection.Location = new Point((x / 2) - (fInspection.Width / 2), (y/2) - (fInspection.Height / 2));

            if (fInspection.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _client.PutPouringInspectionAsync(fInspection.PouringItem.Code, fInspection.PouringItem);
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
                    CurrentPouring = await _client.GetPouringByIdAsync(CurrentPouring.Code);
                    pouringBindingSource.DataSource = CurrentPouring;
                }
            }
            else
            {

            }
        }

        public async void DeletedItem()
        {
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

        private void panel1_Click(object sender, EventArgs e)
        {
            var fName = new FormEventArgs();
            fName.Name = FormName.frmPouringIntoMold;

            FormSelected?.Invoke(this, fName);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            pouringBindingSource.EndEdit();
            PouringItem = pouringBindingSource.Current as Pouring;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pouringBindingSource.CancelEdit();

            pouringBindingSource.ResetBindings(false);
            this.Close();
        }

        private void pnHeader_Click(object sender, EventArgs e)
        {
            var fName = new FormEventArgs();
            fName.Name = FormName.frmInspection;

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pouringBindingSource.EndEdit();

            var p = pouringBindingSource.Current as Pouring;

            meltingDefect = p.Defect.MeltDefect.BlowHole + p.Defect.MeltDefect.ChemNG +
                p.Defect.MeltDefect.Chill + p.Defect.MeltDefect.HardnessNG + p.Defect.MeltDefect.MicroNG +
                p.Defect.MeltDefect.PinHole + p.Defect.MeltDefect.Shrinkage;

            moldingDefect = p.Defect.MoldDefect.BlowHole + p.Defect.MoldDefect.Burr +
                p.Defect.MoldDefect.ChillMismatch + p.Defect.MoldDefect.CoreMismatch +
                p.Defect.MoldDefect.MissMatch + p.Defect.MoldDefect.PinHole +
                p.Defect.MoldDefect.SandBroken + p.Defect.MoldDefect.SandDrop;

            coreDefect = p.Defect.CoreDefect.CoreDeform + p.Defect.CoreDefect.WetCore +
                p.Defect.CoreDefect.CoreBroken;

            pouringDefect = p.Defect.PourDefect.BlowHole + p.Defect.PourDefect.Chill +
                p.Defect.PourDefect.ColdShut + p.Defect.PourDefect.HardnessNG +
                p.Defect.PourDefect.MicroNG + p.Defect.PourDefect.PinHole +
                p.Defect.PourDefect.Shrinkage + p.Defect.PourDefect.Slag;

            engDefect = p.Defect.EngDefect.AirPocket + p.Defect.EngDefect.MissedIdentifer +
                p.Defect.EngDefect.WornTooling;

            finDefect = p.Defect.FinDefect.Deform + p.Defect.FinDefect.Dent + p.Defect.FinDefect.OverGrinding;

            p.Defect.MeltDefect.Total = meltingDefect;
            p.Defect.MoldDefect.Total = moldingDefect;
            p.Defect.CoreDefect.Total = coreDefect;
            p.Defect.PourDefect.Total = pouringDefect;
            p.Defect.EngDefect.Total = engDefect;
            p.Defect.FinDefect.Total = finDefect;

            p.Defect.TotalDefect = meltingDefect + moldingDefect + coreDefect + pouringDefect +
                engDefect + finDefect;

            pouringBindingSource.ResetBindings(false);

            if (p.Defect.TotalNumber <= 0)
                return;

            p.Defect.TotalGood = p.Defect.TotalNumber - p.Defect.TotalDefect;
            p.Defect.TotalWeight = p.Defect.TotalNumber * CurrentProduct.Weight;
            p.Defect.TotalDefectWeight = p.Defect.TotalDefect * CurrentProduct.Weight;
            p.Defect.TotalGoodWeight = p.Defect.TotalWeight - p.Defect.TotalDefectWeight;
            p.Defect.DefectRate = (float)p.Defect.TotalDefect / (float)p.Defect.TotalNumber;
            p.Defect.DefectWeightRate = p.Defect.TotalDefectWeight / p.Defect.TotalWeight;

            pouringBindingSource.ResetBindings(false);

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            pouringBindingSource.EndEdit();
            PouringItem = pouringBindingSource.Current as Pouring;
        }
    }
}
