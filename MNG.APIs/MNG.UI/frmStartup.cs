using ASRS.UI;
using MNG.UI.Production;
using Newtonsoft.Json;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace MNG.UI
{
    public partial class frmStartup : Form
    {
        private Client _client;
        private frmControlPlan fControlPlan;
        private frmSpectrometer fSpectroMeter;
        private frmPouringProc fPouring;
        private frmInspectionProc fInspection;
        private frmQAProc fQA;
        private MNG.UI.Production.frmMultiMelting fMelting;
        private string TempIP = string.Empty;
        private List<ButtonEnable> buttonEnables;
        private User user = null;
        private Screen screens;
        private int selectScreen;

        string toolTipText = "Text of toolTip";
        public frmStartup()
        {
            InitializeComponent();

            string fileName = @"\\192.168.2.3\wmw\Installers\NIPA_FMS\config.json";
            //string paraPath = @"C:\Users\Parameter.json";
            string paraPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Parameter.json");
            string jsonString;
            selectScreen = 0;
            Config configObj = new Config();
            BasicSetting basicSetting = new BasicSetting(paraPath);
            try
            {
                jsonString = File.ReadAllText(fileName);
                configObj = System.Text.Json.JsonSerializer.Deserialize<Config>(jsonString);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Read Config.Json", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            selectScreen = basicSetting.SelectScreen();

            try
            {
                using (StreamReader reader = new StreamReader("Setting.txt"))
                {
                    TempIP = reader.ReadLine();
                }
            }
            catch { }
            MNG.UI.Properties.Settings.Default.API_URL = configObj.APIURL;
            MNG.UI.Properties.Settings.Default.Result_Path = configObj.ChemResultPath;
            MNG.UI.Properties.Settings.Default.Refresh_Rate = configObj.RefreshRate;
            MNG.UI.Properties.Settings.Default.PMeter_IP = configObj.PMeterIP1;
            Properties.Settings.Default.TempIP = TempIP;

            //MNG.UI.Properties.Settings.Default.API_URL = "http://192.168.2.3/NIPA_FMS";   
            //MNG.UI.Properties.Settings.Default.API_URL = "https://wmw-api.azurewebsites.net";
            MNG.UI.Properties.Settings.Default.API_URL = "https://localhost:56802/";
            //MNG.UI.Properties.Settings.Default.API_URL = "https://localhost/NIPA_FMS";
            //MNG.UI.Properties.Settings.Default.Result_Path = @"D:\Mango.Solutions\MNG.FMS\ChemResult\";
            //MNG.UI.Properties.Settings.Default.Refresh_Rate = 5000;

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
            buttonEnables = new List<ButtonEnable>();
            DisableButtons();
            //Load_AllButton();

            screens = Screen.AllScreens[selectScreen];
            StartPosition = FormStartPosition.Manual;
            Location = screens.WorkingArea.Location;
            Properties.Settings.Default.SelectedScreen = selectScreen;
        }

        private void frmStartup_Load(object sender, EventArgs e)
        {
            settingToolTip();
            //Load_AllButton();
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnProducts_Click(object sender, EventArgs e)
        {
            var products = (await _client.GetProductAllAsync()).ToList();
            frmProduct fProduct = new frmProduct(products);

            fProduct.EnableViewMode();
            fProduct.ToolEnable();
            fProduct.MainEnable();
            fProduct.BrowseDiable();
            fProduct.ProductBrowseDisable();
            fProduct.SetWidth(955);
            fProduct.StartPosition = FormStartPosition.Manual;
            //fProduct.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
            fProduct.Location = new Point( Location.X + pnMaster.Location.X + pnMaster.Width + 20, Location.Y + pnMaster.Location.Y);
            fProduct.ShowDialog();
        }

        private async void btnMaterials_Click(object sender, EventArgs e)
        {
            var materials = (await _client.GetMaterialAllAsync()).ToList();
            frmMaterialType fMaterials = new frmMaterialType(materials);

            fMaterials.DisableEditMode();
            fMaterials.DisableMatType();
            fMaterials.ToolEnable();
            fMaterials.MainEnable();
            fMaterials.BrowseDiable();
            fMaterials.StartPosition = FormStartPosition.Manual;
            fMaterials.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, Location.Y + pnMaster.Location.Y);
            fMaterials.ShowDialog();
        }

        private async void btnCustomers_Click(object sender, EventArgs e)
        {
            var customers = (await _client.GetCustomerAllAsync()).ToList();
            frmCustomer fCustomers = new frmCustomer(customers);

            fCustomers.DisableEditMode();
            fCustomers.ToolEnable();
            fCustomers.MainEnable();
            fCustomers.BrowseDiable();
            fCustomers.StartPosition = FormStartPosition.Manual;
            fCustomers.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, Location.Y + pnMaster.Location.Y);
            fCustomers.ShowDialog();
        }

        private async void btnMaterialSpec_Click(object sender, EventArgs e)
        {
            var matSpec = (await _client.GetMaterialSpecificationAllAsync()).ToList();
            frmMaterialSpec fMatSpec = new frmMaterialSpec(matSpec);

            fMatSpec.DisableMatType();
            fMatSpec.DisableEditMode();
            fMatSpec.ToolEnable();
            fMatSpec.MainEnable();
            fMatSpec.ItemBrowseDisable();
            fMatSpec.StartPosition = FormStartPosition.Manual;
            fMatSpec.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, Location.Y + pnMaster.Location.Y);
            fMatSpec.ShowDialog();
        }

        private async void btnMaterial_Click(object sender, EventArgs e)
        {
            var meltStd = (await _client.GetMeltStandardAllAsync()).ToList();
            frmMeltStd fMeltStd = new frmMeltStd(meltStd);

            fMeltStd.EnableViewMode();
            fMeltStd.ToolEnable();
            fMeltStd.MainEnable();
            fMeltStd.DisableGroupHeader();
            fMeltStd.ItemBrowseDisable();
            fMeltStd.StartPosition = FormStartPosition.Manual;
            fMeltStd.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, Location.Y + pnMaster.Location.Y);
            fMeltStd.ShowDialog();
        }

        private async void btnChemInFur_Click(object sender, EventArgs e)
        {
            var chemSpec = (await _client.GetChemicalCompositionInFurnaceAllAsync()).ToList();
            frmChemInFurnace fMatSpec = new frmChemInFurnace(chemSpec);

            fMatSpec.EnableViewMode();
            fMatSpec.ToolEnable();
            fMatSpec.MainEnable();
            fMatSpec.ItemBrowseDisable();
            fMatSpec.DisableGroupHeader();
            fMatSpec.StartPosition = FormStartPosition.Manual;
            fMatSpec.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, Location.Y + pnMaster.Location.Y);
            fMatSpec.ShowDialog();
        }

        private async void btnChemInLad_Click(object sender, EventArgs e)
        {
            var chemSpec = (await _client.GetChemicalCompositionInLadleAllAsync()).ToList();
            frmChemInLadle fChemInLadle = new frmChemInLadle(chemSpec);

            fChemInLadle.EnableViewMode();
            fChemInLadle.ToolEnable();
            fChemInLadle.MainEnable();
            fChemInLadle.ItemBrowseDisable();
            fChemInLadle.DisableGroupHeader();
            fChemInLadle.StartPosition = FormStartPosition.Manual;
            fChemInLadle.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, Location.Y + pnMaster.Location.Y);
            fChemInLadle.ShowDialog();
        }

        private async void btnPourStd_Click(object sender, EventArgs e)
        {
            var pourStd = (await _client.GetPouringStandardAllAsync()).ToList();
            frmPourStd fPourStd = new frmPourStd(pourStd);

            fPourStd.EnableViewMode();
            fPourStd.ToolEnable();
            fPourStd.MainEnable();
            fPourStd.ItemBrowseDisable();
            fPourStd.DisableGroupHeader();
            fPourStd.StartPosition = FormStartPosition.Manual;
            fPourStd.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
            fPourStd.ShowDialog();
        }

        private async void btnMoldStd_Click(object sender, EventArgs e)
        {
            var moldStd = (await _client.GetMoldStandardAllAsync()).ToList();
            frmMoldStd fMoldStd = new frmMoldStd(moldStd);

            fMoldStd.EnableViewMode();
            fMoldStd.ToolEnable();
            fMoldStd.MainEnable();
            fMoldStd.ItemBrowseDisable();
            fMoldStd.StartPosition = FormStartPosition.Manual;
            fMoldStd.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
            fMoldStd.ShowDialog();
        }

        private async void btnShotblast_Click(object sender, EventArgs e)
        {
            var shotBlastStd = (await _client.GetShotBlastStandardAllAsync()).ToList();
            frmShotBlastStd fShotBlastStd = new frmShotBlastStd(shotBlastStd);

            fShotBlastStd.EnableViewMode();
            fShotBlastStd.ToolEnable();
            fShotBlastStd.MainEnable();
            fShotBlastStd.ItemBrowseDisable();
            fShotBlastStd.StartPosition = FormStartPosition.Manual;
            fShotBlastStd.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
            fShotBlastStd.ShowDialog();
        }

        private async void btnTooling_Click(object sender, EventArgs e)
        {
            var toolings = (await _client.GetToolingAllAsync()).ToList();
            frmTooling fTooling = new frmTooling(toolings);

            fTooling.EnableViewMode();
            fTooling.ToolEnable();
            fTooling.MainEnable();
            fTooling.ItemBrowseDisable();
            fTooling.DisableGroupHeader();
            fTooling.StartPosition = FormStartPosition.Manual;
            fTooling.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
            fTooling.ShowDialog();
        }

        private async void btnCTP_Click(object sender, EventArgs e)
        {
            var controlPlans = (await _client.GetControlPlanAllAsync()).ToList();
            fControlPlan = new frmControlPlan(controlPlans);

            fControlPlan.StartPosition = FormStartPosition.Manual;
            fControlPlan.Location = new Point(Location.X, Location.Y) ;
            fControlPlan.WindowState = FormWindowState.Maximized;
            fControlPlan.EnablePnList();
            fControlPlan.EnableNavigatorTool();
            fControlPlan.EnableToolBar();
            fControlPlan.EnableExitTool();
            fControlPlan.DisableSaveExitTool();
            fControlPlan.ShowDialog();
        }

        private void btnMelting_Click(object sender, EventArgs e)
        {
            if (fMelting == null || fMelting.IsDisposed)
            {
                fMelting = new MNG.UI.Production.frmMultiMelting();

                fMelting.StartPosition = FormStartPosition.Manual;
                fMelting.Location = new Point(Location.X, Location.Y);
                fMelting.WindowState = FormWindowState.Maximized;
                fMelting.EnableNavigatorTool();
                fMelting.DisableToolbar();
                fMelting.EnableExitTool();
                fMelting.DisableSaveExitTool();
                fMelting.ShowDialog();
            }
        }

        private async void btnSetting_Click(object sender, EventArgs e)
        {
            var settings = (await _client.GetSettingAllAsync()).ToList();
            frmSetting fSetting = new frmSetting(settings);

            fSetting.EnablePnCRUD();
            fSetting.EnableToolBar();
            fSetting.EnablePnDgv();
            fSetting.EnablePnDetails();
            fSetting.DisableSave();
            fSetting.EnableBtnSelect();
            fSetting.SetReadOnly(true);
            fSetting.StartPosition = FormStartPosition.Manual;
            fSetting.Location = new Point(Location.X + pnMaster.Location.X + pnMaster.Width + 20,Location.Y + pnMaster.Location.Y);
            fSetting.ShowDialog();
        }

        private void btnSpectroMeter_Click(object sender, EventArgs e)
        {
            if (fSpectroMeter == null || fSpectroMeter.IsDisposed)
            {
                fSpectroMeter = new frmSpectrometer();

                fSpectroMeter.StartPosition = FormStartPosition.Manual;
                fSpectroMeter.Location = new Point(Location.X, Location.Y);
                fSpectroMeter.WindowState = FormWindowState.Maximized;
                fSpectroMeter.Show();
            }
        }

        private void btnPouring_Click(object sender, EventArgs e)
        {
            if (fPouring == null || fPouring.IsDisposed)
            {
                fPouring = new frmPouringProc();

                fPouring.StartPosition = FormStartPosition.Manual;
                fPouring.Location = new Point(Location.X, Location.Y);
                fPouring.WindowState = FormWindowState.Maximized;
                fPouring.Show();
            }
        }

        private void btnInspection_Click(object sender, EventArgs e)
        {
            if (fInspection == null || fInspection.IsDisposed)
            {
                frmInspectionProc fInspection = new frmInspectionProc();

                fInspection.StartPosition = FormStartPosition.Manual;
                fInspection.Location = new Point(Location.X, Location.Y);
                fInspection.WindowState = FormWindowState.Maximized;
                fInspection.Show();
            }
        }

        private void btnQA_Click(object sender, EventArgs e)
        {
            if (fQA == null || fQA.IsDisposed)
            {
                frmQAProc fQA = new frmQAProc();

                fQA.StartPosition = FormStartPosition.Manual;
                fQA.Location = new Point(Location.X, Location.Y);
                fQA.WindowState = FormWindowState.Maximized;
                fQA.Show();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnShowSetting_Click(object sender, EventArgs e)
        {
            Assembly assem = Assembly.GetEntryAssembly();
            AssemblyName assemName = assem.GetName();
            string appVerString;

            try
            {
                Version ver = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                appVerString = $"Application : {assemName.Name}\nVersion : {ver}";
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load Version", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(appVerString, "Application Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void settingToolTip()
        {
            toolTip1.OwnerDraw = true;
            toolTip1.BackColor = Color.WhiteSmoke;
            toolTip1.Draw += ToolTip1_Draw;
            toolTip1.Popup += ToolTip1_Popup;
            toolTip1.SetToolTip(btnMaterials, "Materials detail");
            toolTip1.SetToolTip(btnMelting, "Melting  ");
            toolTip1.SetToolTip(btnMaterial, "Material of melt standart");
            toolTip1.SetToolTip(btnProducts, "Products  ");
            toolTip1.SetToolTip(btnClose, "Close  ");
            toolTip1.SetToolTip(btnMaterialSpec, "Material standart");
            toolTip1.SetToolTip(btnChemInFur, "Chemical in Furnace standart");
            toolTip1.SetToolTip(btnChemInLad, "Chemical in ladle standart");
            toolTip1.SetToolTip(btnPourStd, "Pour standart");
            toolTip1.SetToolTip(btnMoldStd, "Mold standart");
            toolTip1.SetToolTip(btnShotblast, "Shotblast standart");
            toolTip1.SetToolTip(btnTooling, "Tooling  ");
            toolTip1.SetToolTip(btnSetting, "Setting program");
            toolTip1.SetToolTip(btnSpectroMeter, "Spectro Meter");
            toolTip1.SetToolTip(btnPouring, "Pouring  ");
            toolTip1.SetToolTip(btnInspection, "Inspection  ");
            toolTip1.SetToolTip(btnShowSetting, "Show setting");
            toolTip1.SetToolTip(btnQA, "QA  ");
            toolTip1.SetToolTip(btnCTP, "Control plan ");
            toolTip1.SetToolTip(btnCustomers, "Customers detail");
            /*btnMelting
            btnSpectroMeter
            btnPouring
            btnInspection
            btnQA
            btnCTP
            btnProducts
            btnMaterials
            btnSetting
            btnCustomers
            btnMaterialSpec
            btnMaterial
            btnChemInFur
            btnChemInLad
            btnMoldStd
            btnTooling
            btnShotblast
            btnShowSetting
            tbClose*/

        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(toolTip1.GetToolTip(e.AssociatedControl), new Font("calibri", 17.0f));
        }

        private void ToolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font tooltipFont = new Font("calibri", 15.0f);
            e.DrawBackground();
            e.DrawBorder();
            toolTipText = e.ToolTipText;
            e.Graphics.DrawString(e.ToolTipText, tooltipFont, Brushes.Black, new PointF(10, 2));
        }
        
        private void Load_Setting()
        {

        }
        private void Load_AllButton()
        {
            string ss = "";
            foreach(var be in buttonEnables)
            {
                ss += be.ButtonSet.Name.ToString() + ", ";
            }

            //MessageBox.Show(ss);
            frmLogIn _frmLogIn = new frmLogIn();
            _frmLogIn.ShowDialog();
            user = _frmLogIn.User;

            if (user != null)
            {
                EnableButtons(_frmLogIn.User);
            }
        }

        private void EnableButtons(User userLogOn)
        {
            for (int i = 0; i < buttonEnables.Count; i++)
            {
                if (userLogOn.Position == 3)
                {
                    buttonEnables[i].Enable();
                }
                else if (userLogOn.Department == 3 && buttonEnables[i].Level == 2)
                {
                    buttonEnables[i].Enable();
                }
                else if (userLogOn.Position >= buttonEnables[i].Level && userLogOn.Department == buttonEnables[i].Department)
                {
                    buttonEnables[i].Enable();
                }
            }
        }

        private void DisableButtons()
        {
            var bt_grp1 = panel8.Controls;
            var bt_grp2 = pnMaster.Controls;
            var bt_grp3 = pnMain.Controls;
            int[] departs = new int[] {3, 4, 2, 3, 1,
                                       5, 5, 5, 5, 
                                       5, 5, 5, 5, 5, 5, 5, 5, 5};

            /*for (int i = 0; i < 5; i++)
            {
                ButtonEnable bE = new ButtonEnable() { ButtonSet = (System.Windows.Forms.Button)bt_grp1[i], Department = departs[i], Level = 1 };
                bE.Disable();
                buttonEnables.Add(bE);
            }*/
            for (int i = 1; i < 5; i++)
            {
                ButtonEnable bE = new ButtonEnable() { ButtonSet = (System.Windows.Forms.Button)bt_grp2[i], Department = departs[i + 5], Level = 2 };
                bE.Disable();
                buttonEnables.Add(bE);
            }
            for (int i = 1; i < 9; i++)
            {
                ButtonEnable bE = new ButtonEnable() { ButtonSet = (System.Windows.Forms.Button)bt_grp3[i], Department = departs[i + 9], Level = 2 };
                bE.Disable();
                buttonEnables.Add(bE);
            }
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            if (user == null)
                Load_AllButton();
            else
            {
                user = null;
                DisableButtons();
                Load_AllButton();
            }
        }
    }

    public class BasicSetting
    {
        private string path {  get; set; }
        private string jsonString { get; set; }
        private Parameter para;
        public BasicSetting(string _path) 
        { 
            path = _path;
            para = new Parameter() { SelectScreen = 0};
        }

        public int SelectScreen()
        {
            try
            {
                jsonString = File.ReadAllText(path);
                para = System.Text.Json.JsonSerializer.Deserialize<Parameter>(jsonString);
            }
            catch (Exception)
            {
                CreateFileParameter();
            }

            return para.SelectScreen;
        }

        private void CreateFileParameter()
        {
            Parameter _para = new Parameter{SelectScreen = 0 };

            try
            {
                string jsonstring = JsonConvert.SerializeObject(para);
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(jsonstring);
                }
                //MessageBox.Show("สร้างไฟล์สำเร็จ");
                jsonString = File.ReadAllText(path);
                para = System.Text.Json.JsonSerializer.Deserialize<Parameter>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
    }

    public class Parameter
    {
        public int SelectScreen { get; set; }
    }
}
