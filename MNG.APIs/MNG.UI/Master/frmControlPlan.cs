using ASRS.UI;
using NPOI.HSSF.Record.Chart;
using NPOI.OpenXmlFormats.Dml.Diagram;
using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MNG.UI
{
    public partial class frmControlPlan : Form
    {
        private Client _client;
        private string SelectedCTPCode;
        private List<ControlPlan> ControlPlans;
        private ControlPlan SelectedItem;
        private ControlPlan SelectedCTP;
        private MeltStandard SelectedMeltStandards;
        private ChemicalCompositionInFurnace SelectedChemInFurnaces;
        private ChemicalCompositionInLadle SelectedChemInLadle;
        private PourStandard SelectedPourStd;
        private MoldStandard SelectedMoldStd;
        private Tooling SelectedTooling;
        private Product SelectedProduct;
        private MaterialSpecification SelectedMatSpec;
        private ShotBlastStandard SelectedShotBlastStd;

        private frmProduct fProduct;
        private frmMaterialSpec fMatSpec;
        private frmChemInFurnace fChemInFurnace;
        private frmChemInLadle fChemInLadle;
        private frmPourStd fPourStd;
        private frmMoldStd fMoldStd;
        private frmTooling fTooling;
        private frmMeltStd fMeltStd;
        private frmShotBlastStd fShotBlastStd;

        private int CurrentPage = 1;
        private FormMode Mode { get; set; }

        public void ListEnable() => pnList.Show();
        public void ListDiable() => pnList.Hide();
        public void EnableViewMode() => Mode = FormMode.Displaying;
        public void EnableEditMode() => Mode = FormMode.Editing;
        public void EnableCreateMode() => Mode = FormMode.Adding;
        public void EnablePnList() => pnList.Show();
        public void DisablePnList() => pnList.Hide();
        public void EnableToolBar() => pnCRUD.Show();
        public void DisableToolbar() => pnCRUD.Hide();
        public void EnableNavigatorTool() => pnNavigator.Show();
        public void DiableNavigatorTool() => pnNavigator.Hide();
        public void EnableExitTool() => pnExit.Show();
        public void DisableExitTool() => pnExit.Hide();
        public void EnableSaveExitTool() => pnSaveExit.Show();
        public void DisableSaveExitTool() => pnSaveExit.Hide();

        private void MatSpecCodeChanged(object sender, CTPEventArg e) => materialSpecificationCodeTextBox.Text = e.Code;
        private void MeltStdCodeChanged(object sender, CTPEventArg e) => meltingCodeTextBox.Text = e.Code;
        private void ChemInFurnaceCodeChanged(object sender, CTPEventArg e) => chemicalCompositionInFurnaceCodeTextBox.Text = e.Code;
        private void ChemInLadleCodeChanged(object sender, CTPEventArg e) => chemicalCompositionInLadleCodeTextBox.Text = e.Code;
        private void MoldStdCodeChanged(object sender, CTPEventArg e) => moldingCodeTextBox.Text = e.Code;
        private void PourStdCodeChanged(object sender, CTPEventArg e) => pouringCodeTextBox.Text = e.Code;
        private void ShotBlastCodeChanged(object sender, CTPEventArg e) => shotBlastingCodeTextBox.Text = e.Code;
        private void ToolingCodeChanged(object sender, CTPEventArg e) => toolingCodeTextBox.Text = e.Code;

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
        private void btnExit_Click(object sender, EventArgs e) => this.Close();

        public frmControlPlan(ControlPlan _controlPlan)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            InitialStandard();
            LoadPanelCreate();

            SelectedItem = _controlPlan;
            controlPlanBindingSource.DataSource = _controlPlan;
        }

        public frmControlPlan(List<ControlPlan> _controlPlans)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            ControlPlans = new List<ControlPlan>();

            ControlPlans = _controlPlans;

            InitialStandard();
            LoadPanelView();

            cboMassDev.SelectedIndex = 0;
            //controlPlanBindingSource.DataSource = ControlPlans.ToList().OrderByDescending(x => x.Code);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private async void Search()
        {
            List<ControlPlan> ctpList = new List<ControlPlan>();
            List<Product> prodList = new List<Product>();

            var filter = tbSearch.Text;
            var type = cboMassDev.Text;

            if (type == "Mass" || type == "Latest")
            {
                ctpList = (await _client.GetControlPlanAllAsync()).Where(x => x.Type == "Mass").ToList();
            }
            else if (type == "Dev")
            {
                ctpList = (await _client.GetControlPlanAllAsync()).Where(x => x.Type == "Dev").ToList();
            }
            else if (type == "All")
            {
                ctpList = (await _client.GetControlPlanAllAsync()).ToList();
            }

            prodList = (await _client.GetProductAllAsync()).Where(x => x.ActiveControlPlanId != null).ToList();

            if (type == "All")
                prodList = (await _client.GetProductAllAsync()).ToList();

            if (type == "Mass" || type == "Dev" || type == "All")
            {
                var CTPP = from ctps in ctpList
                           join prods in prodList
                           on ctps.ProductId equals prods.Id
                           into ct
                           from x in ct
                           where x.Name.ToLower().Contains(filter.ToLower())
                           select new { Code = ctps.Code, Revision = ctps.Revision, Product = x.Name };

                controlPlanBindingSource.DataSource = ctpList.OrderByDescending(x => x.Code).ToList();
                dataGridView1.DataSource = CTPP.OrderByDescending(x => x.Code).ToList();
            }
            else if (type == "Latest")
            {
                var CTPP = from prods in prodList
                           join ctps in ctpList
                           on prods.ActiveControlPlanId equals ctps.Id
                           into ct
                           from x in ct
                           where prods.Name.ToLower().Contains(filter.ToLower())
                           select new { Code = x.Code, Revision = x.Revision, Product = prods.Name };

                controlPlanBindingSource.DataSource = ctpList.OrderByDescending(x => x.Code).ToList();
                dataGridView1.DataSource = CTPP.OrderByDescending(x => x.Code).ToList();
            }
        }

        private void InitialStandard()
        {
            SelectedItem = new ControlPlan();
            SelectedCTP = new ControlPlan();
            SelectedMeltStandards = new MeltStandard();
            SelectedChemInFurnaces = new ChemicalCompositionInFurnace();
            SelectedChemInLadle = new ChemicalCompositionInLadle();
            SelectedPourStd = new PourStandard();
            SelectedMoldStd = new MoldStandard();
            SelectedTooling = new Tooling();
            SelectedProduct = new Product();
            SelectedMatSpec = new MaterialSpecification();
            SelectedMeltStandards = new MeltStandard();
            SelectedShotBlastStd = new ShotBlastStandard();
        }

        private void LoadPanelView()
        {
            this.cbRelease.Hide();

            fProduct = new frmProduct();
            fProduct.TopLevel = false;
            pnProductInfo.Controls.Add(fProduct);
            fProduct.BringToFront();
            fProduct.Dock = DockStyle.Fill;
            fProduct.EnableViewMode();
            fProduct.ToolBarDisable();
            fProduct.MainDiable();
            fProduct.BrowseDiable();
            fProduct.ProductBrowseDisable();
            fProduct.Show();

            fMatSpec = new frmMaterialSpec();
            fMatSpec.TopLevel = false;
            pnMatSpec.Controls.Add(fMatSpec);
            fMatSpec.BringToFront();
            fMatSpec.Dock = DockStyle.Fill;
            fMatSpec.ItemBrowseDisable();
            fMatSpec.ToolBarDisable();
            fMatSpec.MainDiable();
            fMatSpec.DisableGroupHeader();
            fMatSpec.Show();

            fMeltStd = new frmMeltStd();
            fMeltStd.TopLevel = false;
            pnMeltStd.Controls.Add(fMeltStd);
            fMeltStd.BringToFront();
            fMeltStd.Dock = DockStyle.Fill;
            fMeltStd.ItemBrowseDisable();
            fMeltStd.EnableViewMode();
            fMeltStd.ToolBarDisable();
            fMeltStd.MainDisable();
            fMeltStd.DisableGroupHeader();
            fMeltStd.Show();

            fChemInFurnace = new frmChemInFurnace();
            fChemInFurnace.TopLevel = false;
            pnChemInFurnace.Controls.Add(fChemInFurnace);
            fChemInFurnace.BringToFront();
            fChemInFurnace.Dock = DockStyle.Fill;
            fChemInFurnace.ItemBrowseDisable();
            fChemInFurnace.EnableViewMode();
            fChemInFurnace.ToolBarDisable();
            fChemInFurnace.MainDiable();
            fChemInFurnace.DisableGroupHeader();
            fChemInFurnace.Show();

            fChemInLadle = new frmChemInLadle();
            fChemInLadle.TopLevel = false;
            pnChemInLadle.Controls.Add(fChemInLadle);
            fChemInLadle.BringToFront();
            fChemInLadle.Dock = DockStyle.Fill;
            fChemInLadle.ItemBrowseDisable();
            fChemInLadle.EnableViewMode();
            fChemInLadle.ToolBarDisable();
            fChemInLadle.MainDisable();
            fChemInLadle.DisableGroupHeader();
            fChemInLadle.Show();

            fPourStd = new frmPourStd();
            fPourStd.TopLevel = false;
            pnPourStd.Controls.Add(fPourStd);
            fPourStd.BringToFront();
            fPourStd.Dock = DockStyle.Fill;
            fPourStd.ItemBrowseDisable();
            fPourStd.EnableViewMode();
            fPourStd.ToolBarDisable();
            fPourStd.MainDisable();
            fPourStd.DisableGroupHeader();
            fPourStd.Show();

            fMoldStd = new frmMoldStd();
            fMoldStd.TopLevel = false;
            pnMoldStd.Controls.Add(fMoldStd);
            fMoldStd.BringToFront();
            fMoldStd.Dock = DockStyle.Fill;
            fMoldStd.ItemBrowseDisable();
            fMoldStd.EnableViewMode();
            fMoldStd.ToolBarDisable();
            fMoldStd.MainDisable();
            fMoldStd.Show();

            fTooling = new frmTooling();
            fTooling.TopLevel = false;
            pnTooling.Controls.Add(fTooling);
            fTooling.BringToFront();
            fTooling.Dock = DockStyle.Fill;
            fTooling.ItemBrowseDisable();
            fTooling.EnableViewMode();
            fTooling.ToolBarDisable();
            fTooling.DisableGroupHeader();
            fTooling.MainDisable();
            fTooling.Show();

            fShotBlastStd = new frmShotBlastStd();
            fShotBlastStd.TopLevel = false;
            pnShotBlast.Controls.Add(fShotBlastStd);
            fShotBlastStd.BringToFront();
            fShotBlastStd.Dock = DockStyle.Fill;
            fShotBlastStd.ItemBrowseDisable();
            fShotBlastStd.EnableViewMode();
            fShotBlastStd.ToolBarDisable();
            fShotBlastStd.MainDiable();
            fShotBlastStd.DisableGroupHeader();
            fShotBlastStd.Show();

            fProduct.ProductCodeChanged += this.ProductCodeChanged;
            fMatSpec.MatCodeChanged += this.MatSpecCodeChanged;
            fMeltStd.MeltStdCodeChanged += this.MeltStdCodeChanged;
            fChemInFurnace.ChemInFurnaceCodeChanged += this.ChemInFurnaceCodeChanged;
            fChemInLadle.ChemInLadleCodeChanged += this.ChemInLadleCodeChanged;
            fMoldStd.MoldStdCodeChanged += this.MoldStdCodeChanged;
            fPourStd.CodeChanged += this.PourStdCodeChanged;
            fShotBlastStd.CodeChanged += this.ShotBlastCodeChanged;
            fTooling.CodeChanged += this.ToolingCodeChanged;
        }

        private void LoadPanelCreate()
        {
            this.cbRelease.Show();

            fProduct = new frmProduct();
            fProduct.TopLevel = false;
            pnProductInfo.Controls.Add(fProduct);
            fProduct.BringToFront();
            fProduct.Dock = DockStyle.Fill;
            fProduct.EnableViewMode();
            fProduct.ToolBarDisable();
            fProduct.MainDiable();
            fProduct.BrowseEnable();
            fProduct.ProductBrowseEnable();
            fProduct.Show();

            fMatSpec = new frmMaterialSpec();
            fMatSpec.TopLevel = false;
            pnMatSpec.Controls.Add(fMatSpec);
            fMatSpec.BringToFront();
            fMatSpec.Dock = DockStyle.Fill;
            fMatSpec.ItemBrowseEnable();
            fMatSpec.ToolBarDisable();
            fMatSpec.MainDiable();
            fMatSpec.DisableGroupHeader();
            fMatSpec.Show();

            fMeltStd = new frmMeltStd();
            fMeltStd.TopLevel = false;
            pnMeltStd.Controls.Add(fMeltStd);
            fMeltStd.BringToFront();
            fMeltStd.Dock = DockStyle.Fill;
            fMeltStd.ItemBrowseEnable();
            fMeltStd.EnableViewMode();
            fMeltStd.ToolBarDisable();
            fMeltStd.MainDisable();
            fMeltStd.DisableGroupHeader();
            fMeltStd.Show();

            fChemInFurnace = new frmChemInFurnace();
            fChemInFurnace.TopLevel = false;
            pnChemInFurnace.Controls.Add(fChemInFurnace);
            fChemInFurnace.BringToFront();
            fChemInFurnace.Dock = DockStyle.Fill;
            fChemInFurnace.ItemBrowseEnable();
            fChemInFurnace.EnableViewMode();
            fChemInFurnace.ToolBarDisable();
            fChemInFurnace.MainDiable();
            fChemInFurnace.DisableGroupHeader();
            fChemInFurnace.Show();

            fChemInLadle = new frmChemInLadle();
            fChemInLadle.TopLevel = false;
            pnChemInLadle.Controls.Add(fChemInLadle);
            fChemInLadle.BringToFront();
            fChemInLadle.Dock = DockStyle.Fill;
            fChemInLadle.ItemBrowseEnable();
            fChemInLadle.EnableViewMode();
            fChemInLadle.ToolBarDisable();
            fChemInLadle.MainDisable();
            fChemInLadle.DisableGroupHeader();
            fChemInLadle.Show();

            fPourStd = new frmPourStd();
            fPourStd.TopLevel = false;
            pnPourStd.Controls.Add(fPourStd);
            fPourStd.BringToFront();
            fPourStd.Dock = DockStyle.Fill;
            fPourStd.ItemBrowseEnable();
            fPourStd.EnableViewMode();
            fPourStd.ToolBarDisable();
            fPourStd.MainDisable();
            fPourStd.DisableGroupHeader();
            fPourStd.Show();

            fMoldStd = new frmMoldStd();
            fMoldStd.TopLevel = false;
            pnMoldStd.Controls.Add(fMoldStd);
            fMoldStd.BringToFront();
            fMoldStd.Dock = DockStyle.Fill;
            fMoldStd.ItemBrowseEnable();
            fMoldStd.EnableViewMode();
            fMoldStd.ToolBarDisable();
            fMoldStd.MainDisable();
            fMoldStd.Show();

            fTooling = new frmTooling();
            fTooling.TopLevel = false;
            pnTooling.Controls.Add(fTooling);
            fTooling.BringToFront();
            fTooling.Dock = DockStyle.Fill;
            fTooling.ItemBrowseEnable();
            fTooling.EnableViewMode();
            fTooling.ToolBarDisable();
            fTooling.MainDisable();
            fTooling.DisableGroupHeader();
            fTooling.Show();

            fShotBlastStd = new frmShotBlastStd();
            fShotBlastStd.TopLevel = false;
            pnShotBlast.Controls.Add(fShotBlastStd);
            fShotBlastStd.BringToFront();
            fShotBlastStd.Dock = DockStyle.Fill;
            fShotBlastStd.ItemBrowseEnable();
            fShotBlastStd.EnableViewMode();
            fShotBlastStd.ToolBarDisable();
            fShotBlastStd.MainDiable();
            fShotBlastStd.DisableGroupHeader();
            fShotBlastStd.Show();

            fProduct.ProductCodeChanged += this.ProductCodeChanged;
            fMatSpec.MatCodeChanged += this.MatSpecCodeChanged;
            fMeltStd.MeltStdCodeChanged += this.MeltStdCodeChanged;
            fChemInFurnace.ChemInFurnaceCodeChanged += this.ChemInFurnaceCodeChanged;
            fChemInLadle.ChemInLadleCodeChanged += this.ChemInLadleCodeChanged;
            fMoldStd.MoldStdCodeChanged += this.MoldStdCodeChanged;
            fPourStd.CodeChanged += this.PourStdCodeChanged;
            fShotBlastStd.CodeChanged += this.ShotBlastCodeChanged;
            fTooling.CodeChanged += this.ToolingCodeChanged;
        }

        private void frmControlPlan_Load(object sender, EventArgs e)
        {
            pnDetails.Controls.Add(pnProductInfo);
            pnProductInfo.BringToFront();
            pnProductInfo.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnMatSpec);
            pnMatSpec.BringToFront();
            pnMatSpec.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnMeltStd);
            pnMeltStd.BringToFront();
            pnMeltStd.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnChemInFurnace);
            pnChemInFurnace.BringToFront();
            pnChemInFurnace.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnChemInLadle);
            pnChemInLadle.BringToFront();
            pnChemInLadle.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnPourStd);
            pnPourStd.BringToFront();
            pnPourStd.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnMoldStd);
            pnMoldStd.BringToFront();
            pnMoldStd.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnTooling);
            pnTooling.BringToFront();
            pnTooling.Dock = DockStyle.Left;

            pnDetails.Controls.Add(pnShotBlast);
            pnShotBlast.BringToFront();
            pnShotBlast.Dock = DockStyle.Left;
        }

        private async void controlPlanBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //SelectedItem = controlPlanBindingSource.Current as ControlPlan;

            if (SelectedItem.Id == null)
                return;

            controlPlanBindingSource.DataSource = SelectedItem;
            SelectedProduct = (await _client.GetProductByIdAsync(SelectedItem.ProductId));
            SelectedMatSpec = (await _client.GetMaterialSpecificationByIdAsync(SelectedItem.MaterialSpecificationCode));
            SelectedMeltStandards = (await _client.GetMeltStandardByIdAsync(SelectedItem.MeltingCode));
            SelectedChemInFurnaces = (await _client.GetChemicalCompositionInFurnaceByIdAsync(SelectedItem.ChemicalCompositionInFurnaceCode));
            SelectedChemInLadle = (await _client.GetChemicalCompositionInLadleByIdAsync(SelectedItem.ChemicalCompositionInLadleCode));
            SelectedPourStd = (await _client.GetPouringStandardByIdAsync(SelectedItem.PouringCode));
            SelectedTooling = (await _client.GetToolingByIdAsync(SelectedItem.ToolingCode));
            SelectedMoldStd = (await _client.GetMoldStandardByIdAsync(SelectedItem.MoldingCode));
            SelectedShotBlastStd = (await _client.GetShotBlastStandardByIdAsync(SelectedItem.ShotBlastingCode));

            fProduct.SelectedItem = SelectedProduct;
            fMatSpec.Data = SelectedMatSpec;
            fMeltStd.Data = SelectedMeltStandards;
            fChemInFurnace.Data = SelectedChemInFurnaces;
            fChemInLadle.Data = SelectedChemInLadle;
            fPourStd.Data = SelectedPourStd;
            fTooling.Data = SelectedTooling;
            fMoldStd.Data = SelectedMoldStd;
            fShotBlastStd.Data = SelectedShotBlastStd;
        }

        private void ProductCodeChanged(object sender, CTPEventArg e)
        {
            if (Mode != FormMode.Adding)
                return;

            SelectedProduct = fProduct.SelectedProduct;
            GetRevision();

            tbDateTime.Text = DateTime.Now.ToString("dd/MM/yy");
            productIdTextBox.Text = e.Code;
            controlPlanBindingSource.EndEdit();
        }

        private async void GetRevision()
        {
            int rev = 0;
            var ctpCode = $"CTP-{fProduct.SelectedProduct.Code.Substring(3, 4)}";
            var ctp = (await _client.GetControlPlanAllAsync()).Where(x => x.Code.Contains(ctpCode)).LastOrDefault();

            if (ctp == null)
                codeTextBox.Text = $"{ctpCode}-{rev.ToString("00")}";
            else
            {
                rev = Convert.ToInt32(ctp.Code.Substring(9, 2));

                if (rev < 10 && cbRelease.Checked == true)
                {
                    rev = 10;
                    codeTextBox.Text = $"{ctpCode}-{rev.ToString("00")}";
                }
                else
                {
                    rev++;
                    codeTextBox.Text = $"{ctpCode}-{rev.ToString("00")}";
                }
            }
            tbRev.Text = rev.ToString("00");
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var newCTP = new ControlPlan();
            frmControlPlan fControlPlan = new frmControlPlan(newCTP);

            fControlPlan.StartPosition = FormStartPosition.Manual;
            fControlPlan.Location = new Point(100, 50);
            fControlPlan.WindowState = FormWindowState.Normal;
            fControlPlan.Size = new Size(1650, 900);
            fControlPlan.DisablePnList();
            fControlPlan.EnableCreateMode();
            fControlPlan.EnableNavigatorTool();
            fControlPlan.DisableToolbar();
            fControlPlan.DisableExitTool();
            fControlPlan.EnableSaveExitTool();

            var result = fControlPlan.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (SelectedItem.Id == null)
                {
                    MessageBox.Show("Missing Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (SelectedItem.Revision.Substring(0, 1) == "0")
                    SelectedItem.Type = "Dev";
                else
                    SelectedItem.Type = "Mass";

                try
                {

                    await _client.PostControlPlanAsync(fControlPlan.SelectedItem);
                    MessageBox.Show("Control Plan Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("201"))
                    {
                        MessageBox.Show("Product Added", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Search();
                        return;
                    }
                }

                try
                {
                    var ctp = await _client.GetControlPlanByCodeAsync(fControlPlan.SelectedItem.Code);
                    var prod = await _client.GetProductByIdAsync(ctp.ProductId);

                    prod.ActiveControlPlanId = ctp.Id;

                    await _client.PutProductAsync(prod.Id ?? 0, prod);
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to bind with Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Search();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            //var ctp = controlPlanBindingSource.Current as ControlPlan;
            //frmControlPlan fControlPlan = new frmControlPlan(ctp);

            frmControlPlan fControlPlan = new frmControlPlan(SelectedCTP);
            fControlPlan.StartPosition = FormStartPosition.Manual;
            fControlPlan.Location = new Point(100, 50);
            fControlPlan.WindowState = FormWindowState.Normal;
            fControlPlan.Size = new Size(1650, 900);
            fControlPlan.DisablePnList();
            fControlPlan.EnableEditMode();
            fControlPlan.EnableNavigatorTool();
            fControlPlan.DisableToolbar();
            fControlPlan.DisableExitTool();
            fControlPlan.EnableSaveExitTool();
            fControlPlan.cbRelease.Hide();

            var result = fControlPlan.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (result == DialogResult.OK)
                {
                    try
                    {
                        await _client.PutControlPlanAsync(fControlPlan.SelectedItem.Id ?? 0, fControlPlan.SelectedItem);

                        var p = await _client.GetProductByIdAsync(fControlPlan.SelectedItem.ProductId);
                        p.ActiveControlPlanId = fControlPlan.SelectedItem.Id;

                        await _client.PutProductAsync(p.Id ?? 0, p);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //var items = await _client.GetControlPlanAllAsync();
                        //controlPlanBindingSource.DataSource = items;
                        Search();
                        return;
                    }

                    MessageBox.Show("Control Plan saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            controlPlanBindingSource.EndEdit();
            SelectedItem = controlPlanBindingSource.Current as ControlPlan;
        }

        private void cbRelease_CheckedChanged(object sender, EventArgs e)
        {
            GetRevision();
        }

        private bool mouseDown = false;
        private Point lastLocation;

        private void label10_MouseDown(object sender, MouseEventArgs e)
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

        private void label10_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - lastLocation.X + e.X, this.DesktopLocation.Y - lastLocation.Y + e.Y);
                this.Update();
            }
        }

        private void label10_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedCTPCode = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //var selectedCTP = (await _client.GetControlPlanAllAsync()).Where(x => x.Code.Contains(code)).LastOrDefault();
            try
            {
                SelectedCTP = (await _client.GetControlPlanByCodeAsync(SelectedCTPCode));
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Load Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //SelectedItem = controlPlanBindingSource.Current as ControlPlan;
            SelectedItem = SelectedCTP;

            if (SelectedItem.Id == null)
                return;

            controlPlanBindingSource_CurrentItemChanged(this, EventArgs.Empty);
        }
    }
}
