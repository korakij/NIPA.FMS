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
    public partial class frmQA : Form
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

        public frmQA()
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

            ChangeMode(false);
        }

        public frmQA(Pouring _pouring, Product _product)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CurrentProduct = new Product();
            CurrentProduct = _product;

            pouringBindingSource.DataSource = _pouring;

            ChangeMode(true);
        }

        public void EnableToolBar() => pnToolBar.Show();
        public void DisableToolBar() => pnToolBar.Hide();

        private async void frmEditQC_Load(object sender, EventArgs e)
        {
        }

        public void ChangeMode(bool isEdit)
        {
            
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

            fInspection.Location = new Point((x / 2) - (fInspection.Width / 2), (y / 2) - (fInspection.Height / 2));

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
            fName.Name = FormName.frmQA;

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
           

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            pouringBindingSource.EndEdit();
            PouringItem = pouringBindingSource.Current as Pouring;
        }

    }
}
