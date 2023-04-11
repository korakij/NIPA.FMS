using BarcodeLib;
using MNG.UI;
using MNG.UI.Production;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASRS.UI
{
    public partial class frmProduct : Form
    {
        private Client _client;
        private Product _product = new Product();

        public Product SelectedItem
        {
            get { return _product; }
            set
            {
                _product = value;
                productBindingSource.DataSource = _product;
            }
        }

        public event EventHandler<CTPEventArg> ProductCodeChanged;

        public Product SelectedProduct = new Product();
        public FormMode Mode { get; set; }

        public void ToolEnable() => pnTool.Show();
        public void ToolDisable() => pnTool.Hide();
        public void MainEnable() => pnMain.Show();
        public void MainDiable() => pnMain.Hide();
        public void ToolBarEnable() => pnToolbar.Show();
        public void ToolBarDisable() => pnToolbar.Hide();
        public void BrowseEnable() => pnBrowse.Show();
        public void BrowseDiable() => pnBrowse.Hide();
        public void ProductBrowseEnable() => btnProductBrowse.Show();
        public void ProductBrowseDisable() => btnProductBrowse.Hide();
        public void SetWidth(int width) => this.Width = width;
        public void EnableViewMode() => Mode = FormMode.Displaying;

        public void EnableEditMode()
        {
            Mode = FormMode.Editing;
            //btnMaterial.Hide();
        }

        public void EnableCreateMode()
        {
            Mode = FormMode.Adding;
            //btnMaterial.Show();
        }

        public frmProduct()
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        public frmProduct(List<Product> _products)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_products.Count != 0)
                productBindingSource.DataSource = _products;
        }

        public frmProduct(Product _product)
        {
            InitializeComponent();

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);

            if (_product != null)
                productBindingSource.DataSource = _product;
        }

        private void frmItem_Load(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Product();
            var cnt = (await _client.GetProductAllAsync()).ToList().Count();

            newItem.Id = cnt + 1;

            frmProduct fAddProduct = new frmProduct(newItem);

            fAddProduct.EnableCreateMode();
            fAddProduct.ToolDisable();
            fAddProduct.MainDiable();
            fAddProduct.BrowseEnable();
            fAddProduct.ProductBrowseDisable();
            fAddProduct.SetWidth(545);
            fAddProduct.StartPosition = FormStartPosition.Manual;
            fAddProduct.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fAddProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PostProductAsync(fAddProduct.SelectedProduct);
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
                    }
                }
            }
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var product = productBindingSource.Current as Product;

            frmProduct fUpdate = new frmProduct(product);

            fUpdate.EnableEditMode();
            fUpdate.ToolDisable();
            fUpdate.MainDiable();
            fUpdate.BrowseEnable();
            fUpdate.ProductBrowseDisable();
            fUpdate.SetWidth(545);
            fUpdate.StartPosition = FormStartPosition.Manual;
            fUpdate.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fUpdate.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    await _client.PutProductAsync(Convert.ToInt32(fUpdate.SelectedProduct.Id), fUpdate.SelectedProduct);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Product saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            productBindingSource.EndEdit();
            SelectedProduct = productBindingSource.Current as Product;
            _product = productBindingSource.Current as Product;
        }

        private async void productBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedProduct = productBindingSource.Current as Product;
            _product = productBindingSource.Current as Product;

            if (SelectedProduct.CustomerId == 0)
                return;

            //var custName = (await _client.GetCustomerByIdAsync(SelectedProduct.CustomerId)).Name;
            var cust = (await _client.GetCustomerByIdAsync(SelectedProduct.CustomerId));

            customerBindingSource.DataSource = cust;

            if (cust.Name == null)
                tbCustName.Text = "";
            else
                tbCustName.Text = cust.Name;

            if (SelectedProduct == null)
            {
                BarCodeBox.Image = null;
                return;
            }

            Color foreColor = Color.Black;
            Color backColor = Color.White;

            Barcode barcode = new Barcode();
            Image imgId = barcode.Encode(TYPE.CODE128, SelectedProduct.Id.ToString(), foreColor, backColor, (int)(BarCodeBox.Width * 0.9), (int)(BarCodeBox.Height * 0.9));
            BarCodeBox.Image = imgId;
        }

        private bool mouseDown = false;
        private Point lastLocation;

        private void label5_MouseDown_1(object sender, MouseEventArgs e)
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

        private void label5_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.SetDesktopLocation(this.DesktopLocation.X - lastLocation.X + e.X, this.DesktopLocation.Y - lastLocation.Y + e.Y);
                this.Update();
            }
        }

        private void label5_MouseUp_1(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnMaterial_Click(object sender, EventArgs e)
        {
            var materials = (await _client.GetMaterialAllAsync()).ToList();
            frmMaterialType fMaterial = new frmMaterialType(materials);

            fMaterial.ToolDisable();
            fMaterial.MainEnable();
            fMaterial.BrowseDiable();
            fMaterial.SetWidth(620);
            fMaterial.StartPosition = FormStartPosition.Manual;
            fMaterial.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fMaterial.ShowDialog();

            if (result == DialogResult.OK)
            {
                materialCodeTextBox.Text = fMaterial.SelectedItem.Code;
                productBindingSource.EndEdit();
            }

        }

        private async void btnCustomer_Click(object sender, EventArgs e)
        {
            var customers = (await _client.GetCustomerAllAsync()).ToList();
            frmCustomer fCustomer = new frmCustomer(customers);

            fCustomer.ToolDisable();
            fCustomer.MainEnable();
            fCustomer.BrowseDiable();
            fCustomer.SetWidth(620);
            fCustomer.StartPosition = FormStartPosition.Manual;
            fCustomer.Location = new Point(this.Location.X + this.Size.Width + 20, this.Location.Y);

            var result = fCustomer.ShowDialog();

            if (result == DialogResult.OK)
            {
                customerIdTextBox.Text = fCustomer.SelectedItem.Id.ToString();
                productBindingSource.EndEdit();
            }
        }

        private async void customerIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (customerIdTextBox.Text == "" || customerIdTextBox.Text == "0")
                return;

            var customer = await _client.GetCustomerByIdAsync(Convert.ToInt32(customerIdTextBox.Text));

            tbCustName.Text = customer.Name;
        }

        private async void materialCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Mode != FormMode.Adding)
                return;

            if (materialCodeTextBox.Text == "")
                return;

            var str = materialCodeTextBox.Text.Substring(0, 3);

            if (str == "FCD")
            {
                var lastProd = (await _client.GetProductAllAsync()).Where(x => x.Code.Contains("CA-2")).LastOrDefault();
                if (lastProd == null)
                {
                    lastProd = new Product();
                    lastProd.Code = "CA-2000";
                }
                var nextNum = Convert.ToInt32(lastProd.Code.Substring(3, 4)) + 1;
                codeTextBox.Text = $"CA-{nextNum.ToString("000")}";
            }
            else
            {
                var lastProd = (await _client.GetProductAllAsync()).Where(x => x.Code.Contains("CA-1")).LastOrDefault();
                if (lastProd == null)
                {
                    lastProd = new Product();
                    lastProd.Code = "CA-1000";
                }
                var nextNum = Convert.ToInt32(lastProd.Code.Substring(3, 4)) + 1;
                codeTextBox.Text = $"CA-{nextNum.ToString("000")}";
            }

            productBindingSource.EndEdit();
        }

        private void itemDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOk_Click(this, EventArgs.Empty);
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Image Files",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "Image files(*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png",
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = new Bitmap(openFileDialog1.FileName);
                var destRect = new Rectangle(0, 0, 320, 240);
                var destImage = new Bitmap(320, 240);

                destImage.SetResolution(bit.HorizontalResolution, bit.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(bit, destRect, 0, 0, bit.Width, bit.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                imagePictureBox.Image = destImage;
            }
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            var bmp = (Bitmap)imagePictureBox.Image;
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);

            var destRect = new Rectangle(0, 0, 180, 240);
            var destImage = new Bitmap(180, 240);

            destImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(bmp, destRect, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            imagePictureBox.Image = bmp;
        }

        private async void btnProductBrowse_Click(object sender, EventArgs e)
        {
            var products = (await _client.GetProductAllAsync()).ToList();

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
                productBindingSource.DataSource = fProduct.SelectedProduct;
            }
        }

        private void codeTextBox_TextChanged(object sender, EventArgs e)
        {
            productBindingSource.EndEdit();
            var prod = productBindingSource.Current as Product;
            var arg = new CTPEventArg();
            arg.Code = prod.Id.ToString();

            ProductCodeChanged?.Invoke(this, arg);
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            frmPrintTag fPrintTag = new frmPrintTag();
            fPrintTag.Info[0] = SelectedProduct.Code;
            fPrintTag.Info[1] = $"{SelectedProduct.Code}   {SelectedProduct.Name}";
            fPrintTag.Info[2] = "";
            fPrintTag.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
