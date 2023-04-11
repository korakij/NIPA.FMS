﻿using ASRS.UI;
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

        public int PartNo { get; set; }
        public TestChemicalComposition CCETest { get; set; }

        public frmCreateNewTest(string newTest)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            pnCCE.Hide();
            tbTestNo.Text = newTest;
            btnOk.Enabled = false;
        }

        public frmCreateNewTest(string newTest, Product _prod, ChemicalCompositionInFurnace _chemInFur, TestChemicalComposition _CCETest)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CCETest = new TestChemicalComposition();

            pnCCE.Show();
            productBindingSource.DataSource = _prod;
            chemicalCompositionInFurnaceBindingSource.DataSource = _chemInFur;
            testChemicalCompositionBindingSource.DataSource = _CCETest;

            tbTestNo.Text = newTest;
            btnOk.Enabled = true;
        }

        private async void btnProductBrowse_Click(object sender, EventArgs e)
        {
            var products = (await _client.GetProductAllAsync()).Where(x => x.ActiveControlPlanId != null).ToList();

            frmProduct fProduct = new frmProduct(products);

            fProduct.EnableViewMode();
            fProduct.ToolDisable();
            fProduct.MainEnable();
            fProduct.BrowseDiable();
            fProduct.ProductBrowseDisable();
            fProduct.StartPosition = FormStartPosition.Manual;
            fProduct.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (fProduct.SelectedProduct == null)
                    return;

                productBindingSource.DataSource = fProduct.SelectedProduct;
                productBindingSource.EndEdit();
                btnOk.Enabled = true;
                PartNo = fProduct.SelectedProduct.Id ?? 0;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            testChemicalCompositionBindingSource.EndEdit();
            CCETest = testChemicalCompositionBindingSource.Current as TestChemicalComposition;
        }
    }
}
