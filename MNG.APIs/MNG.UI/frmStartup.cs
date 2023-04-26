using ASRS.UI;
using MNG.UI.Production;
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
using System.Windows.Forms;

namespace MNG.UI
{
    public partial class frmStartup : Form
    {
        private Client _client;
        private frmControlPlan fControlPlan;
        private frmSpectrometer fSpectroMeter;
        private frmPouringProc fPouring;
        private frmInspectionProc fInspection;

        private MNG.UI.Production.frmMultiMelting fMelting;

        public frmStartup()
        {
            InitializeComponent();

            string fileName = @"\\192.168.2.3\wmw\Installers\NIPA_FMS\config.json";
            string jsonString;
            Config configObj = new Config();
            try
            {
                jsonString = File.ReadAllText(fileName);
                configObj = JsonSerializer.Deserialize<Config>(jsonString);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Read Config.Json", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            MNG.UI.Properties.Settings.Default.API_URL = configObj.APIURL;
            MNG.UI.Properties.Settings.Default.Result_Path = configObj.ChemResultPath;
            MNG.UI.Properties.Settings.Default.Refresh_Rate = configObj.RefreshRate;
            MNG.UI.Properties.Settings.Default.PMeter1 = configObj.PMeterIP1;

            //MNG.UI.Properties.Settings.Default.API_URL = "http://192.168.2.3/NIPA_FMS";
            //MNG.UI.Properties.Settings.Default.API_URL = "https://localhost:44358/";
            //MNG.UI.Properties.Settings.Default.Result_Path = @"D:\Mango.Solutions\MNG.FMS\ChemResult\";
            //MNG.UI.Properties.Settings.Default.Refresh_Rate = 5000;

            var url = MNG.UI.Properties.Settings.Default.API_URL;
            _client = new Client(url);
        }

        private void frmStartup_Load(object sender, EventArgs e)
        {
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
            fProduct.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fMaterials.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fCustomers.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fMatSpec.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fMeltStd.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fMatSpec.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fChemInLadle.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fPourStd.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fMoldStd.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fShotBlastStd.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
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
            fTooling.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
            fTooling.ShowDialog();
        }

        private async void btnCTP_Click(object sender, EventArgs e)
        {
            var controlPlans = (await _client.GetControlPlanAllAsync()).ToList();
            fControlPlan = new frmControlPlan(controlPlans);

            fControlPlan.StartPosition = FormStartPosition.Manual;
            fControlPlan.Location = new Point(0, 0);
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

                fMelting.WindowState = FormWindowState.Maximized;
                fMelting.EnableNavigatorTool();
                fMelting.DisableToolbar();
                fMelting.EnableExitTool();
                fMelting.DisableSaveExitTool();
                fMelting.Show();
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
            fSetting.Location = new Point(pnMaster.Location.X + pnMaster.Width + 20, pnMaster.Location.Y);
            fSetting.ShowDialog();
        }

        private void btnSpectroMeter_Click(object sender, EventArgs e)
        {
            if (fSpectroMeter == null || fSpectroMeter.IsDisposed)
            {
                fSpectroMeter = new frmSpectrometer();

                fSpectroMeter.StartPosition = FormStartPosition.Manual;
                fSpectroMeter.Location = new Point(0, 0);
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
                fPouring.Location = new Point(0, 0);
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
                fInspection.Location = new Point(0, 0);
                fInspection.WindowState = FormWindowState.Maximized;
                fInspection.Show();
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
    }
}
