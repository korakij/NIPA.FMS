using Microsoft.Office.Interop.Excel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XWPF.UserModel;
using System;
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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Drawing;

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
        private List<cellExcel> cells;
        Excel.Application excelApp;
        private byte[] imgToExport;
        private List<Control> controlsResult;
        private List<double?> valueResult;
        private List<double?> valueMax;
        private List<double?> valueMin;

        private bool IsSaved;
        private bool IsLoaded = false;
        private bool EditMode = false;

        private int? meltingDefect;
        private int? moldingDefect;
        private int? pouringDefect;
        private int? finDefect;
        private int? engDefect;
        private int? coreDefect;

        private int selectedScreen = 0;
        private System.Drawing.Point locNow;

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
            KillProcessesExcel();
            excelApp = new Excel.Application();
            cells = new List<cellExcel>();

            selectedScreen = Properties.Settings.Default.SelectedScreen;
            var screens = Screen.AllScreens[selectedScreen];
            StartPosition = FormStartPosition.Manual;
            locNow = screens.WorkingArea.Location;
        }

        public void ChangeMode(bool isEdit, Pouring _pouring)
        {
            var listTextBox = this.pnHeader.Controls.OfType<System.Windows.Forms.TextBox>().ToList();
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
                tensileTextBox.ReadOnly = false;
                yieldTextBox.ReadOnly = false;
                elongationTextBox.ReadOnly = false;
                sizeTensileTextbox.ReadOnly = false;
            }
        }

        public async void PouringIntoMoldChanged(object sender, MeltingEventArgs e)
        {
            if (e.PouringNo != null)
            {
                CurrentPouring = e.PouringNo;
                pouringBindingSource.DataSource = CurrentPouring;

                CurrentProduct = await _client.GetProductByIdAsync(CurrentPouring.ProductCode);
                CurrentControlPlan = (await _client.GetControlPlanByIdAsync(CurrentProduct.ActiveControlPlanId ?? 0));

                CurrentMatSpec = (await _client.GetMaterialSpecificationByIdAsync(CurrentControlPlan.MaterialSpecificationCode));
                materialSpecificationBindingSource.DataSource = CurrentMatSpec;

                getImageCurrent(CurrentPouring);
                //QA_ColorTextBox(CurrentPouring, CurrentMatSpec);
                QA_ResultTbColor(CurrentPouring, CurrentMatSpec);
            }
        }

        public async void EditItem()
        {
            if (CurrentPouring == null || CurrentPouring.Code == null)
            {
                MessageBox.Show("Unable to Edit Current Pouring", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmQA fQA = new frmQA(CurrentPouring, CurrentProduct, CurrentMatSpec);

            fQA.Height = 990;
            fQA.StartPosition = FormStartPosition.Manual;
            var y = Screen.PrimaryScreen.WorkingArea.Height;
            var x = Screen.PrimaryScreen.WorkingArea.Width;

            fQA.Location = new System.Drawing.Point(locNow.X + (x / 2) - (fQA.Width / 2), locNow.Y + (y / 2) - (fQA.Height / 2));

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

        public async void Export()
        {
            if(CurrentPouring != null && CurrentPouring.Code != null && CurrentProduct != null)
            {
                //WorkingForm workForm = new WorkingForm();
                ///workForm.Show();

                qNewFile();
            }
            else
            {
                MessageBox.Show("Current Pouring is null");
            }
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
        private System.Drawing.Point lastLocation;
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

            //QA_ColorTextBox(PouringItem, materialSpecificationBindingSource.DataSource as MaterialSpecification);
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
                var destRect = new System.Drawing.Rectangle(0, 0, 320, 240);
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
                var destRect = new System.Drawing.Rectangle(0, 0, 320, 240);
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
            if (_pouring.QInspect.GraphiteA >= _matSpec.GraphiteAMin & _pouring.QInspect.GraphiteA <= _matSpec.GraphiteAMax) graphiteATextBox1.BackColor = Color.GreenYellow;
            else if(_pouring.QInspect.GraphiteA < _matSpec.GraphiteAMin & _pouring.QInspect.GraphiteA > 0) graphiteATextBox1.BackColor = Color.Red;
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

            if (_matSpec.SizeTensileMin == null || _pouring.QInspect.Tensile == 0) tensileTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Tensile >= _matSpec.SizeTensileMin) tensileTextBox.BackColor = Color.GreenYellow;
            else tensileTextBox.BackColor = Color.Red;

            if (_matSpec.YieldMin == null || _matSpec.YieldMax == null || _pouring.QInspect.Yeild == 0) yieldTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Yeild >= _matSpec.YieldMin & _pouring.QInspect.Yeild <= _matSpec.YieldMax) yieldTextBox.BackColor = Color.GreenYellow;
            else yieldTextBox.BackColor = Color.Red;

            if (_matSpec.ElongationMin == null || _matSpec.ElongationMax == null || _pouring.QInspect.Elongation == 0) elongationTextBox.BackColor = Color.White;
            else if(_pouring.QInspect.Elongation >= _matSpec.ElongationMin & _pouring.QInspect.Elongation <= _matSpec.ElongationMax) elongationTextBox.BackColor = Color.GreenYellow;
            else elongationTextBox.BackColor = Color.Red;

            if (_matSpec.SizeTensileMin == null || _matSpec.SizeTensileMax == null || _pouring.QInspect.SizeTensile == 0) sizeTensileTextbox.BackColor = Color.White;
            else if (_pouring.QInspect.SizeTensile >= _matSpec.SizeTensileMin & _pouring.QInspect.SizeTensile <= _matSpec.SizeTensileMax) sizeTensileTextbox.BackColor = Color.GreenYellow;
            else sizeTensileTextbox.BackColor = Color.Red;
        }
        private void QA_ResultTbColor(Pouring _pouring, MaterialSpecification _matSpec)
        {
            valueMinMax(_pouring, _matSpec);
            for(int i = 0; i < controlsResult.Count; i++)
            {
                if (valueResult[i] == null || valueResult[i] == 0)
                {
                    controlsResult[i].BackColor = Color.White;
                    if (valueMax[i] != null || valueMin[i] != null)
                        controlsResult[i].BackColor = Color.Yellow;
                }
                else if ((valueResult[i] <= valueMax[i] || valueMax[i] == null) && (valueResult[i] >= valueMin[i] || valueMin[i] == null) && (valueMin[i] != null || valueMax[i] != null))
                {
                    controlsResult[i].BackColor = Color.GreenYellow;
                }
                else if (valueResult[i] > valueMax[i] || valueResult[i] < valueMin[i])
                    controlsResult[i].BackColor = Color.Red;
                else
                    controlsResult[i].BackColor = Color.White;
            }
        }

        private void valueMinMax(Pouring _pouring, MaterialSpecification _matSpec)
        {
            QAInspection qInspec = _pouring.QInspect;
            if (qInspec != null)
            {
                valueResult = new List<double?>() { qInspec.GraphiteA, qInspec.Nodularity, qInspec.Size, qInspec.Count, qInspec.Ferrite, qInspec.Pearlite, qInspec.Hardness
                                                , qInspec.SizeTensile, qInspec.Tensile, qInspec.Yeild, qInspec.Elongation};
                valueMax = new List<double?>() { _matSpec.GraphiteAMax, _matSpec.NodularityMax, _matSpec.SizeMax, _matSpec.NoduleCount, _matSpec.FerriteMax, _matSpec.PearliteMax, _matSpec.HbMax
                                                , _matSpec.SizeTensileMax, _matSpec.TensileMax, _matSpec.YieldMax, _matSpec.ElongationMax};
                valueMin = new List<double?>() { _matSpec.GraphiteAMin, _matSpec.NodularityMin, _matSpec.SizeMin, null, _matSpec.FerriteMin, _matSpec.PearliteMin, _matSpec.HbMin
                                                , _matSpec.SizeTensileMin, _matSpec.TensileMin, _matSpec.YieldMin, _matSpec.ElongationMin};
                controlsResult = new List<Control>() { graphiteATextBox1, nodularityTextBox, sizeTextBox, countTextBox, ferriteTextBox, pearliteTextBox, hardnessTextBox
                                                , sizeTensileTextbox, tensileTextBox, yieldTextBox, elongationTextBox};
            }
        }

        private void frmQA_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseObjExcel();
        }

        private string SavePictureToLocal()
        {
            imgToExport = CurrentPouring.QInspect.MatrixImg;

            string tempImagePath = Path.Combine(Path.GetTempPath(), "ImgExport.jpg");
            File.WriteAllBytes(tempImagePath, imgToExport);

            return tempImagePath;
        }

        private void KillProcessesExcel()
        {
            var process = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            if (process.Length > 1)
            {
                for (int i = 0; i < process.Length - 1; i++)
                {
                    try
                    {
                        process[i].Kill();
                        process[i].WaitForExit();
                        //MessageBox.Show("Closed Excel process ID: " + process[i].Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to close Excel process ID: " + process[i].Id);
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void ReleaseObjExcel()
        {
            excelApp.Quit();
            Marshal.ReleaseComObject(excelApp);
        }

        private string SelectTemplate()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select template for Mill sheet";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }

        private async void qNewFile()
        {
            string message = "Do you want to create a new file or add to an existing file?";
            string title = "Choose an option";


            string templatePath = SelectTemplate();
            if (templatePath == "") return;
            Excel._Worksheet templateWSh = excelApp.Workbooks.Open(templatePath).Sheets[1];
            Excel.Workbook newWb = null;
            try
            {
                var result = MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes || result == DialogResult.No)
                {
                    //WorkingForm workForm = new WorkingForm();
                    ///workForm.Show();

                    CurrentProduct.Customer = (await _client.GetCustomerByIdAsync(CurrentProduct.CustomerId));
                    ChemicalCompositionInLadle chemInLadle = await _client.GetChemicalCompositionInLadleByIdAsync(CurrentControlPlan.ChemicalCompositionInLadleCode);
                    Kanban currentKanban = await _client.GetKanbanByIdAsync(CurrentPouring.KanbanCode);
                    string lotNo = "";

                    if (excelApp == null)
                    {
                        Console.WriteLine("Excel is not installed.");
                        return;
                    }

                    if (CurrentProduct != null && currentKanban != null && chemInLadle != null)
                    {
                        MillSheetLotNoForm Millform = new MillSheetLotNoForm();
                        Millform.StartPosition = FormStartPosition.CenterParent;
                        Millform.ShowDialog();
                        templateWSh.Name = Millform.LotNo;

                        templateWSh.Cells[4, 3].Value = CurrentProduct.Name;      //1.ProductName
                        templateWSh.Cells[5, 3].Value = CurrentProduct.CustomerPartNo;      //2.CustomerPartNo.
                                                                                            //worksheet.Cells[6, 3].Value = CurrentProduct.MaterialCode;      //3.MaterialCode
                        templateWSh.Cells[4, 9].Value = CurrentProduct.Customer.Name;      //4.CustomerName
                        templateWSh.Cells[5, 9].Value = Millform.LotNo;      //5.LotNoCode
                        templateWSh.Cells[6, 9].Value = CurrentPouring.FirstMoldTime;//((DateTime)CurrentPouring.FirstMoldTime).ToString("dd/MM/yy");      //6.Date
                        templateWSh.Cells[15, 3].Value = (chemInLadle.CMax == null) ? "" : chemInLadle.CMax.ToString();      //7.CMax
                        templateWSh.Cells[15, 4].Value = (chemInLadle.CMin == null) ? "" : chemInLadle.CMin.ToString();      //8.CMin
                        templateWSh.Cells[15, 3].Value = (chemInLadle.SiMax == null) ? "" : chemInLadle.SiMax.ToString();      //9.SiMax
                        templateWSh.Cells[15, 4].Value = (chemInLadle.SiMin == null) ? "" : chemInLadle.SiMin.ToString();      //10.SiMin
                        templateWSh.Cells[17, 3].Value = (chemInLadle.MnMax == null) ? "" : chemInLadle.MnMax.ToString();     //11.MnMax
                        templateWSh.Cells[17, 4].Value = (chemInLadle.MnMin == null) ? "" : chemInLadle.MnMin.ToString();     //12.MnMin
                        templateWSh.Cells[18, 3].Value = (chemInLadle.PMax == null) ? "" : chemInLadle.PMax.ToString();     //13.PMax
                        templateWSh.Cells[18, 4].Value = (chemInLadle.PMin == null) ? "" : chemInLadle.PMin.ToString();     //14.PMin
                        templateWSh.Cells[19, 3].Value = (chemInLadle.SMax == null) ? "" : chemInLadle.SMax.ToString();     //15.SMax
                        templateWSh.Cells[19, 4].Value = (chemInLadle.SMin == null) ? "" : chemInLadle.SMin.ToString();     //16.SMin
                        templateWSh.Cells[20, 3].Value = (chemInLadle.CuMax == null) ? "" : chemInLadle.CuMax.ToString();     //17.CuMax
                        templateWSh.Cells[20, 4].Value = (chemInLadle.CuMin == null) ? "" : chemInLadle.CuMin.ToString();     //18.CuMin
                        templateWSh.Cells[21, 3].Value = (chemInLadle.CrMax == null) ? "" : chemInLadle.CrMax.ToString();     //19.CrMax
                        templateWSh.Cells[21, 4].Value = (chemInLadle.CrMin == null) ? "" : chemInLadle.CrMin.ToString();     //20.CrMin
                        templateWSh.Cells[22, 3].Value = (chemInLadle.SnMax == null) ? "" : chemInLadle.SnMax.ToString();     //19.SnMax
                        templateWSh.Cells[22, 4].Value = (chemInLadle.SnMin == null) ? "" : chemInLadle.SnMin.ToString();     //20.SnMin
                        templateWSh.Cells[23, 3].Value = (chemInLadle.MgMax == null) ? "" : chemInLadle.MgMax.ToString();     //21.MgMax
                        templateWSh.Cells[23, 4].Value = (chemInLadle.MgMin == null) ? "" : chemInLadle.MgMin.ToString();     //22.MgMin
                        templateWSh.Cells[24, 3].Value = (chemInLadle.AlMax == null) ? "" : chemInLadle.AlMax.ToString();     //23.AlMax
                        templateWSh.Cells[24, 4].Value = (chemInLadle.AlMin == null) ? "" : chemInLadle.AlMin.ToString();     //24.AlMin
                        templateWSh.Cells[15, 5].Value = (currentKanban.Result.C == null) ? "" : currentKanban.Result.C.ToString();     //23.Result_C
                        templateWSh.Cells[16, 5].Value = (currentKanban.Result.Si == null) ? "" : currentKanban.Result.Si.ToString();     //24.Result_Si
                        templateWSh.Cells[17, 5].Value = (currentKanban.Result.Mn == null) ? "" : currentKanban.Result.Mn.ToString();     //25.Result_Mn
                        templateWSh.Cells[18, 5].Value = (currentKanban.Result.P == null) ? "" : currentKanban.Result.P.ToString();     //26.Result_P
                        templateWSh.Cells[19, 5].Value = (currentKanban.Result.S == null) ? "" : currentKanban.Result.S.ToString();     //27.Result_S
                        templateWSh.Cells[20, 5].Value = (currentKanban.Result.Cu == null) ? "" : currentKanban.Result.Cu.ToString();     //28.Result_Cu
                        templateWSh.Cells[21, 5].Value = (currentKanban.Result.Cr == null) ? "" : currentKanban.Result.Cr.ToString();     //29.Result_Cr
                        templateWSh.Cells[22, 5].Value = (currentKanban.Result.Sn == null) ? "" : currentKanban.Result.Sn.ToString();     //30.Result_Sn
                        templateWSh.Cells[23, 5].Value = (currentKanban.Result.Sn == null) ? "" : currentKanban.Result.Sn.ToString();     //31.Result_Mg
                        templateWSh.Cells[24, 5].Value = (currentKanban.Result.Sn == null) ? "" : currentKanban.Result.Sn.ToString();     //32.Result_Al
                        templateWSh.Cells[15, 9].Value = (CurrentMatSpec.SizeMax == null) ? "" : CurrentMatSpec.SizeTensileMax.ToString();     //31.SizeTensileMax
                        templateWSh.Cells[15, 10].Value = (CurrentMatSpec.SizeMin == null) ? "" : CurrentMatSpec.SizeTensileMin.ToString();     //32.SizeTensileMin
                        templateWSh.Cells[15, 11].Value = (CurrentPouring.QInspect.Size == null) ? "" : CurrentPouring.QInspect.SizeTensile.ToString();     //33.QInspection_Size
                        templateWSh.Cells[16, 9].Value = (CurrentMatSpec.TensileMax == null) ? "" : CurrentMatSpec.TensileMax.ToString();     //34.TensileMax
                        templateWSh.Cells[16, 10].Value = (CurrentMatSpec.TensileMin == null) ? "" : CurrentMatSpec.TensileMin.ToString();     //35.TensileMin
                        templateWSh.Cells[16, 11].Value = (CurrentPouring.QInspect.Tensile == null) ? "" : CurrentPouring.QInspect.Tensile.ToString();     //36.QInspection_Tensile
                        templateWSh.Cells[17, 9].Value = (CurrentMatSpec.YieldMax == null) ? "" : CurrentMatSpec.YieldMax.ToString();     //37.CurrentMatSpec.YieldMax
                        templateWSh.Cells[17, 10].Value = (CurrentMatSpec.YieldMin == null) ? "" : CurrentMatSpec.YieldMin.ToString();     //38.CurrentMatSpec.YieldMin
                        templateWSh.Cells[17, 11].Value = (CurrentPouring.QInspect.Yeild == null) ? "" : CurrentPouring.QInspect.Yeild.ToString();     //39.QInspection_Yeild
                        templateWSh.Cells[18, 9].Value = (CurrentMatSpec.ElongationMax == null) ? "" : CurrentMatSpec.ElongationMax.ToString();     //40.CurrentMatSpec.ElongationMax
                        templateWSh.Cells[18, 10].Value = (CurrentMatSpec.ElongationMin == null) ? "" : CurrentMatSpec.ElongationMin.ToString();     //41.CurrentMatSpec.ElongationMin
                        templateWSh.Cells[18, 11].Value = (CurrentPouring.QInspect.Elongation == null) ? "" : CurrentPouring.QInspect.Elongation.ToString();     //42.QInspection_Elongation
                        templateWSh.Cells[19, 9].Value = (CurrentMatSpec.HbMax == null) ? "" : CurrentMatSpec.HbMax.ToString();     //43.HBMax
                        templateWSh.Cells[19, 10].Value = (CurrentMatSpec.HbMin == null) ? "" : CurrentMatSpec.HbMin.ToString();     //44.HBMin
                        templateWSh.Cells[19, 11].Value = (CurrentPouring.QInspect.Hardness == null) ? "" : CurrentPouring.QInspect.Hardness.ToString();     //45.QInspection_Hardness
                        templateWSh.Cells[32, 3].Value = (CurrentMatSpec.GraphiteAMax == null) ? "" : (CurrentMatSpec.GraphiteAMax * 0.01).ToString();      //46.GraphiteAMax
                        templateWSh.Cells[32, 4].Value = (CurrentMatSpec.GraphiteAMin == null) ? "" : (CurrentMatSpec.GraphiteAMin * 0.01).ToString();      //47.GraphiteAMin
                        templateWSh.Cells[32, 5].Value = (CurrentPouring.QInspect.GraphiteA == null) ? "" : (CurrentPouring.QInspect.GraphiteA * 0.01).ToString();      //48.QInspection_GraphiteA
                        templateWSh.Cells[33, 3].Value = (CurrentMatSpec.SizeMax == null) ? "" : CurrentMatSpec.NodularityMin.ToString();      //49.SizeMax
                        templateWSh.Cells[33, 4].Value = (CurrentMatSpec.SizeMin == null) ? "" : CurrentMatSpec.NodularityMin.ToString();      //50.SizeMin
                        templateWSh.Cells[33, 5].Value = (CurrentPouring.QInspect.Size == null) ? "" : CurrentPouring.QInspect.Size.ToString();      //51.QInspection_Size
                        templateWSh.Cells[34, 3].Value = (CurrentMatSpec.NodularityMax == null) ? "" : (CurrentMatSpec.NodularityMax * 0.01).ToString();      //52.NodularityMax
                        templateWSh.Cells[34, 4].Value = (CurrentMatSpec.NodularityMin == null) ? "" : (CurrentMatSpec.NodularityMin * 0.01).ToString();      //53.NodularityMin
                        templateWSh.Cells[34, 5].Value = (CurrentPouring.QInspect.Nodularity == null) ? "" : (CurrentPouring.QInspect.Nodularity * 0.01).ToString();      //54.QInspection_Nodularity
                        templateWSh.Cells[32, 9].Value = (CurrentMatSpec.PearliteMax == null) ? "" : (CurrentMatSpec.PearliteMax * 0.01).ToString();     //55.PearliteMax
                        templateWSh.Cells[32, 10].Value = (CurrentMatSpec.PearliteMin == null) ? "" : (CurrentMatSpec.PearliteMin * 0.01).ToString();     //56.PearliteMin
                        templateWSh.Cells[32, 11].Value = (CurrentPouring.QInspect.Pearlite == null) ? "" : (CurrentPouring.QInspect.Pearlite * 0.01).ToString();     //57.QInspection_Pearlite
                        templateWSh.Cells[33, 9].Value = (CurrentMatSpec.FerriteMax == null) ? "" : (CurrentMatSpec.FerriteMax * 0.01).ToString();     //58.FerriteMax
                        templateWSh.Cells[33, 10].Value = (CurrentMatSpec.FerriteMin == null) ? "" : (CurrentMatSpec.FerriteMin * 0.01).ToString();     //59.FerriteMin
                        templateWSh.Cells[33, 11].Value = (CurrentPouring.QInspect.Ferrite == null) ? "" : (CurrentPouring.QInspect.Ferrite * 0.01).ToString();     //60.QInspection_Ferrite
                        templateWSh.Cells[34, 9].Value = (CurrentMatSpec.CementiteMax == null) ? "" : (CurrentMatSpec.CementiteMax * 0.01).ToString();     //61.CementileMax
                        templateWSh.Cells[34, 10].Value = (CurrentMatSpec.CementiteMin == null) ? "" : (CurrentMatSpec.CementiteMin * 0.01).ToString();     //62.CementileMin
                        templateWSh.Cells[34, 11].Value = (CurrentPouring.QInspect.Cementite == null) ? "" : (CurrentPouring.QInspect.Cementite * 0.01).ToString();     //63.QInspection_Cementile
                                                                                                                                                                        //worksheet.Cells[75, 13].Value = ((DateTime)CurrentPouring.FirstMoldTime).ToString("dd/MM/yy"); //64 Date

                        if (CurrentPouring.QInspect.MatrixImg != null)
                        {
                            string imgPath = SavePictureToLocal();
                            int row = 36;
                            int col = 1;
                            double left = (double)((float)templateWSh.Cells[row, col].Left);
                            double top = (double)((float)templateWSh.Cells[row, col].Top);
                            templateWSh.Shapes.AddPicture(imgPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue,
                                            (float)left, (float)top, (float)480, (float)360);
                        }
                        //workForm.Close();
                    }
                    if (result == DialogResult.Yes)
                    {
                        newWb = excelApp.Workbooks.Add();
                        templateWSh.Copy(After: newWb.Sheets[newWb.Sheets.Count]);
                        newWb.Sheets[1].Delete();

                        excelApp.Workbooks["Template Mill sheet"].Close(false);
                        excelApp.Visible = true;
                    }
                    else
                    {
                        string oldExcelPath = SelectTemplate();
                        Excel.Workbook oldWb = excelApp.Workbooks.Open(oldExcelPath);
                        templateWSh.Copy(After: oldWb.Sheets[oldWb.Sheets.Count]);

                        excelApp.Workbooks["Template Mill sheet"].Close(false);
                        excelApp.Visible = true;
                    }
                }

            }
            finally
            {
                //newWb.Close();

                //Marshal.ReleaseComObject(newWb);
            }
        }

        private void connectWorkingExcel()
        {

        }
    }

    public class cellExcel
    {
        public System.Drawing.Point Address { get; set; }
        public string Value { get; set; }
    }
}
