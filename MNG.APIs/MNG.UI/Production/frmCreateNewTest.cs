using ASRS.UI;
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
    public partial class frmCreateNewTest : Form
    {
        private Client _client;
        private int productIdInFur;
        public int? PartNo { get; set; }
        public TestChemicalComposition TestChem { get; set; }
        private TestChemicalComposition _TestChem;

        public frmCreateNewTest(string newTest, int _productIdInFur)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);
            TestChem = new TestChemicalComposition();
            _TestChem = new TestChemicalComposition();

            pnCCE.Hide();
            tbTestNo.Text = newTest;
            btnOk.Enabled = false;

            productIdInFur = _productIdInFur;
        }

        public frmCreateNewTest(string newTest, Product _prod, ChemicalCompositionInFurnace _chemInFur, TestChemicalComposition _CCETest, ControlPlan _ctp)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            _TestChem = _CCETest;
            lbHeader.Text = "E D I T - T E S T";
            pnCCE.Show();
            productBindingSource.DataSource = _prod;
            chemicalCompositionInFurnaceBindingSource.DataSource = _chemInFur;
            testChemicalCompositionBindingSource.DataSource = _CCETest;
            controlPlanBindingSource.DataSource = _ctp;

            tbTestNo.Text = newTest;
            btnOk.Enabled = true;
        }

        private async void btnProductBrowse_Click(object sender, EventArgs e)
        {
            var products = (await _client.GetProductAllAsync()).Where(x => x.ActiveControlPlanId != null).ToList();
            string productInFur = "";
            if (productIdInFur != 0) 
               productInFur = products.Where(x => x.Id == productIdInFur).FirstOrDefault().Name;
            frmProduct fProduct = new frmProduct(products, productInFur);

            fProduct.EnableViewMode();
            fProduct.ToolDisable();
            fProduct.MainEnable();
            fProduct.BrowseDiable();
            fProduct.ProductBrowseDisable();
            //fProduct.StartPosition = FormStartPosition.Manual;
            //fProduct.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (fProduct.SelectedProduct == null)
                    return;

                var ctp = (await _client.GetControlPlanByIdAsync(fProduct.SelectedProduct.ActiveControlPlanId ?? 0));

                if(ctp.ChemicalCompositionInFurnaceCode == null)
                {
                    MessageBox.Show("รายการที่คุณเลือกใน Control plan ไม่มีการระบุค่าเคมีการในเตาหลอม โปรดเลือกรายการอื่น", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("This product not have Chemical Composition In Furnace, plaese select another product.", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PartNo = fProduct.SelectedProduct.Id ?? 0;
                _TestChem.ControlPlan = ctp;
                _TestChem.ControlPlanId = ctp.Id;
                _TestChem.Product = fProduct.SelectedProduct;
                _TestChem.ProductId = fProduct.SelectedProduct.Id ?? 0;

                productBindingSource.DataSource = _TestChem.Product;
                controlPlanBindingSource.DataSource = ctp;
                testChemicalCompositionBindingSource.DataSource = _TestChem;
                btnOk.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            testChemicalCompositionBindingSource.EndEdit();
            productBindingSource.EndEdit();
            TestChem = testChemicalCompositionBindingSource.Current as TestChemicalComposition;
        }
    }
}
