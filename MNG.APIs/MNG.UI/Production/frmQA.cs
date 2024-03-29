﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
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
        private Pouring CurrentPouring;
        private List<Pouring> _pourings;
        private ControlPlan CurrentControlPlan;
        private PourStandard CurrentPourStandard;
        private MaterialSpecification CurrentMatSpec;

        private bool IsSaved;
        private bool IsLoaded = false;
        private bool EditMode = false;

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

            CurrentControlPlan = new ControlPlan();
            CurrentPouring = new Pouring();
            CurrentPourStandard = new PourStandard();
            CurrentProduct = new Product();
            CurrentMatSpec = new MaterialSpecification();

            ChangeMode(false, new Pouring());
        }

        public frmQA(Pouring _pouring, Product _product, MaterialSpecification _matSpec)
        {
            InitializeComponent();

            var url = Properties.Settings.Default.API_URL;
            _client = new Client(url);

            CurrentProduct = new Product();
            CurrentProduct = _product;

            pouringBindingSource.DataSource = _pouring;
            materialSpecificationBindingSource.DataSource = _matSpec;

            ChangeMode(true, _pouring);
        }

        public void EnableToolBar() => pnToolBar.Show();
        public void DisableToolBar() => pnToolBar.Hide();

        private async void frmEditQC_Load(object sender, EventArgs e)
        {
            
        }

        public void ChangeMode(bool isEdit, Pouring _pouring)
        {
            var listTextBox = this.pnHeader.Controls.OfType<TextBox>().ToList();
            for (int i = 0; i < listTextBox.Count(); i++)
            {
                listTextBox[i].ReadOnly = true;
            }

            EditMode = isEdit;
            if(EditMode)
            {
                getImageCurrent(_pouring);
                var defaultImg = MNG.UI.Properties.Resources.InsertImage;
                if(_pouring.QInspect.GraphiteImg == null)
                    GraphiteImg.Image = defaultImg;
                if(_pouring.QInspect.MatrixImg == null)
                    MatrixImg.Image = defaultImg;

                graphiteATextBox1.ReadOnly = false;
                nodularityTextBox.ReadOnly = false;
                sizeTextBox.ReadOnly = false;
                countTextBox.ReadOnly = false;
                ferriteTextBox.ReadOnly = false;
                pearliteTextBox.ReadOnly = false;
                cementiteTextBox.ReadOnly = false;
                hardnessTextBox.ReadOnly = false;
                tensileTextBox1.ReadOnly = false;
                yeildTextBox.ReadOnly = false;
                elongationTextBox1.ReadOnly = false;
            }
        }

        public async void PouringIntoMoldChanged(object sender, MeltingEventArgs e)
        {
            CurrentPouring = e.PouringNo;
            pouringBindingSource.DataSource = CurrentPouring;

            CurrentProduct = await _client.GetProductByIdAsync(CurrentPouring.ProductCode);
            CurrentControlPlan = (await _client.GetControlPlanByIdAsync(CurrentProduct.ActiveControlPlanId ?? 0));

            CurrentMatSpec = (await _client.GetMaterialSpecificationByIdAsync(CurrentControlPlan.MaterialSpecificationCode));
            materialSpecificationBindingSource.DataSource = CurrentMatSpec;

            getImageCurrent(CurrentPouring);
            QA_ColorTextBox(CurrentPouring, CurrentMatSpec);
        }

        public async void EditItem()
        {
            if (CurrentPouring == null)
            {
                MessageBox.Show("Unable to Edit Current Pouring", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmQA fQA = new frmQA(CurrentPouring, CurrentProduct, CurrentMatSpec);

            fQA.Height = 990;
            fQA.StartPosition = FormStartPosition.Manual;
            var y = Screen.PrimaryScreen.WorkingArea.Height;
            var x = Screen.PrimaryScreen.WorkingArea.Width;

            fQA.Location = new Point((x / 2) - (fQA.Width / 2), (y / 2) - (fQA.Height / 2));

            if (fQA.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _client.PutPouringInspectionAsync(fQA.PouringItem.Code, fQA.PouringItem);
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
                    getImageCurrent(CurrentPouring);
                }
            }
            else
            {

            }
            frmEditQC_Load(null, null);
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

            if (GraphiteImg.Image.RawFormat != null)
            {
                ImageConverter converter = new ImageConverter();
                PouringItem.QInspect.GraphiteImg = (byte[])converter.ConvertTo(GraphiteImg.Image, typeof(byte[]));
            }
            if (MatrixImg.Image.RawFormat != null)
            {
                ImageConverter converter = new ImageConverter();
                PouringItem.QInspect.MatrixImg = (byte[])converter.ConvertTo(MatrixImg.Image, typeof(byte[]));
            }

            QA_ColorTextBox(PouringItem, materialSpecificationBindingSource.DataSource as MaterialSpecification);
        }

        private void GraphiteImg_DoubleClick(object sender, EventArgs e)
        {
            if(!EditMode) return;

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

                GraphiteImg.Image = destImage;
            }
        }

        private void MatrixImg_DoubleClick(object sender, EventArgs e)
        {
            if(!EditMode) return;

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

                MatrixImg.Image = destImage;
            }
        }

        private void getImageCurrent(Pouring _pouring)
        {
            if (_pouring.QInspect == null)  return;

            if (_pouring.QInspect.GraphiteImg != null)
            {
                var graphiteImgCurrent = _pouring.QInspect.GraphiteImg;
                using (var ms = new MemoryStream(graphiteImgCurrent))
                {
                    GraphiteImg.Image = Image.FromStream(ms);
                }
            }
            else GraphiteImg.Image = null;
            if (_pouring.QInspect.MatrixImg != null)
            {
                var matrixImgCurrent = _pouring.QInspect.MatrixImg;
                using (var ms = new MemoryStream(matrixImgCurrent))
                {
                    MatrixImg.Image = Image.FromStream(ms);
                }
            }
            else MatrixImg.Image = null;
        }

        private void QA_ColorTextBox(Pouring _pouring, MaterialSpecification _matSpec)
        {
            if (_pouring.QInspect.GraphiteA >= _matSpec.GraphiteA) graphiteATextBox1.BackColor = Color.GreenYellow;
            else if(_pouring.QInspect.GraphiteA < _matSpec.GraphiteA & _pouring.QInspect.GraphiteA > 0) graphiteATextBox1.BackColor = Color.Red;
            else graphiteATextBox1.BackColor = Color.White;

            if (_pouring.QInspect.Nodularity >= _matSpec.NodularityMin) nodularityTextBox.BackColor = Color.GreenYellow;
            else if (_pouring.QInspect.Nodularity < _matSpec.NodularityMin & _pouring.QInspect.Nodularity > 0) nodularityTextBox.BackColor = Color.Red;
            else nodularityTextBox.BackColor = Color.White;
            
            if(_pouring.QInspect.Size >= _matSpec.SizeMin & _pouring.QInspect.Size <= _matSpec.SizeMax) sizeTextBox.BackColor = Color.GreenYellow;
            else if (_pouring.QInspect.Size < _matSpec.SizeMin || _pouring.QInspect.Size > _matSpec.SizeMax) sizeTextBox.BackColor = Color.Red;
            else sizeTextBox.BackColor = Color.White;

            if (_matSpec.NoduleCount == null || _pouring.QInspect.Count == 0) countTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Count >= _matSpec.NoduleCount ) countTextBox.BackColor = Color.GreenYellow;
            else countTextBox.BackColor = Color.Red;

            if (_matSpec.FerriteMax == null || _matSpec.FerriteMin == null || _pouring.QInspect.Ferrite == 0) ferriteTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Ferrite >= _matSpec.FerriteMin & _pouring.QInspect.Ferrite <= _matSpec.FerriteMax) ferriteTextBox.BackColor = Color.GreenYellow;
            else ferriteTextBox.BackColor = Color.Red;

            if (_matSpec.PearliteMin == null || _pouring.QInspect.Pearlite == 0) pearliteTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Pearlite >= _matSpec.PearliteMin & _pouring.QInspect.Pearlite <= _matSpec.PearliteMax) pearliteTextBox.BackColor = Color.GreenYellow;
            else pearliteTextBox.BackColor = Color.Red;

            if (_matSpec.CementiteMin == null || _pouring.QInspect.Cementite == 0) cementiteTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Cementite >= _matSpec.CementiteMin & _pouring.QInspect.Cementite <= _matSpec.CementiteMax) cementiteTextBox.BackColor = Color.GreenYellow;
            else cementiteTextBox.BackColor = Color.Red;

            if (_matSpec.HbMin == null || _pouring.QInspect.Hardness == 0) hardnessTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Hardness >= _matSpec.HbMin & _pouring.QInspect.Hardness <= _matSpec.HbMax) hardnessTextBox.BackColor = Color.GreenYellow;
            else hardnessTextBox.BackColor = Color.Red;

            if (_matSpec.Tensile == null || _pouring.QInspect.Tensile == 0) tensileTextBox1.BackColor = Color.White;
            else if(_pouring.QInspect.Tensile >= _matSpec.Tensile) tensileTextBox1.BackColor = Color.GreenYellow;
            else tensileTextBox1.BackColor = Color.Red;

            if (_matSpec.Yield == null || _pouring.QInspect.Yeild == 0) yeildTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Yeild >= _matSpec.Yield) yeildTextBox.BackColor = Color.GreenYellow;
            else yeildTextBox.BackColor = Color.Red;

            if (_matSpec.Elongation == null || _pouring.QInspect.Elongation == 0) elongationTextBox1.BackColor = Color.White;
            else if(_pouring.QInspect.Elongation >= _matSpec.Elongation) elongationTextBox1.BackColor = Color.GreenYellow;
            else elongationTextBox1.BackColor = Color.Red;
        }
    }
}
