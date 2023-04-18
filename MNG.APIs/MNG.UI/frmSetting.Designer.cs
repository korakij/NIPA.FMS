namespace MNG.UI
{
    partial class frmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codeLabel;
            System.Windows.Forms.Label isSelectedLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label27 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.pnSaveExit = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnToolBar = new System.Windows.Forms.Panel();
            this.pnCRUD = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnDetails = new System.Windows.Forms.Panel();
            this.isSelectedCheckBox = new System.Windows.Forms.CheckBox();
            this.settingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.apI_URLTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.result_PathTextBox = new System.Windows.Forms.TextBox();
            this.powerMeterIPTextBox = new System.Windows.Forms.TextBox();
            this.refreshRateTextBox = new System.Windows.Forms.TextBox();
            this.pnDgv = new System.Windows.Forms.Panel();
            this.settingDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            codeLabel = new System.Windows.Forms.Label();
            isSelectedLabel = new System.Windows.Forms.Label();
            this.pnSaveExit.SuspendLayout();
            this.pnToolBar.SuspendLayout();
            this.pnCRUD.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingSource)).BeginInit();
            this.pnDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codeLabel.Location = new System.Drawing.Point(31, 67);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(93, 17);
            codeLabel.TabIndex = 15;
            codeLabel.Text = "Setting Code";
            // 
            // isSelectedLabel
            // 
            isSelectedLabel.AutoSize = true;
            isSelectedLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            isSelectedLabel.Location = new System.Drawing.Point(31, 320);
            isSelectedLabel.Name = "isSelectedLabel";
            isSelectedLabel.Size = new System.Drawing.Size(63, 17);
            isSelectedLabel.TabIndex = 17;
            isSelectedLabel.Text = "Selected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "API URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "PATH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Refresh Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(191, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Milli Sec.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "RESULT PATH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Power Meter IP";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.MidnightBlue;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(0, 592);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 21);
            this.label27.TabIndex = 9;
            this.label27.Text = "--------";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.MidnightBlue;
            this.label25.Dock = System.Windows.Forms.DockStyle.Top;
            this.label25.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(0, 35);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 21);
            this.label25.TabIndex = 13;
            this.label25.Text = "--------";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnSaveExit
            // 
            this.pnSaveExit.Controls.Add(this.btnSelect);
            this.pnSaveExit.Controls.Add(this.btnSave);
            this.pnSaveExit.Controls.Add(this.btnExit);
            this.pnSaveExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSaveExit.Location = new System.Drawing.Point(0, 315);
            this.pnSaveExit.Name = "pnSaveExit";
            this.pnSaveExit.Size = new System.Drawing.Size(59, 277);
            this.pnSaveExit.TabIndex = 17;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSelect.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(0, 100);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(59, 59);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(0, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 59);
            this.btnSave.TabIndex = 9;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(0, 218);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 59);
            this.btnExit.TabIndex = 8;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnToolBar
            // 
            this.pnToolBar.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnToolBar.Controls.Add(this.pnCRUD);
            this.pnToolBar.Controls.Add(this.label25);
            this.pnToolBar.Controls.Add(this.panel5);
            this.pnToolBar.Controls.Add(this.pnSaveExit);
            this.pnToolBar.Controls.Add(this.label27);
            this.pnToolBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnToolBar.Name = "pnToolBar";
            this.pnToolBar.Size = new System.Drawing.Size(59, 613);
            this.pnToolBar.TabIndex = 295;
            // 
            // pnCRUD
            // 
            this.pnCRUD.Controls.Add(this.btnDelete);
            this.pnCRUD.Controls.Add(this.btnEdit);
            this.pnCRUD.Controls.Add(this.btnCreate);
            this.pnCRUD.Controls.Add(this.btnLoad);
            this.pnCRUD.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCRUD.Location = new System.Drawing.Point(0, 56);
            this.pnCRUD.Name = "pnCRUD";
            this.pnCRUD.Size = new System.Drawing.Size(59, 250);
            this.pnCRUD.TabIndex = 14;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 177);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 59);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(0, 118);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 59);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.Location = new System.Drawing.Point(0, 59);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(59, 59);
            this.btnCreate.TabIndex = 19;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.Location = new System.Drawing.Point(0, 0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(59, 59);
            this.btnLoad.TabIndex = 18;
            this.btnLoad.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(59, 35);
            this.panel5.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(59, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 613);
            this.panel2.TabIndex = 296;
            // 
            // lbHeader
            // 
            this.lbHeader.BackColor = System.Drawing.Color.White;
            this.lbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbHeader.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbHeader.Location = new System.Drawing.Point(64, 0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(673, 45);
            this.lbHeader.TabIndex = 297;
            this.lbHeader.Text = "S E T T I N G";
            this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbHeader_MouseDown);
            this.lbHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbHeader_MouseMove);
            this.lbHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbHeader_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(64, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 3);
            this.panel1.TabIndex = 298;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pnDetails);
            this.panel3.Controls.Add(this.pnDgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(64, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(673, 565);
            this.panel3.TabIndex = 299;
            // 
            // pnDetails
            // 
            this.pnDetails.Controls.Add(codeLabel);
            this.pnDetails.Controls.Add(this.label2);
            this.pnDetails.Controls.Add(this.isSelectedCheckBox);
            this.pnDetails.Controls.Add(this.label5);
            this.pnDetails.Controls.Add(isSelectedLabel);
            this.pnDetails.Controls.Add(this.label1);
            this.pnDetails.Controls.Add(this.apI_URLTextBox);
            this.pnDetails.Controls.Add(this.label6);
            this.pnDetails.Controls.Add(this.label3);
            this.pnDetails.Controls.Add(this.codeTextBox);
            this.pnDetails.Controls.Add(this.label4);
            this.pnDetails.Controls.Add(this.pathTextBox);
            this.pnDetails.Controls.Add(this.result_PathTextBox);
            this.pnDetails.Controls.Add(this.powerMeterIPTextBox);
            this.pnDetails.Controls.Add(this.refreshRateTextBox);
            this.pnDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDetails.Location = new System.Drawing.Point(131, 0);
            this.pnDetails.Name = "pnDetails";
            this.pnDetails.Size = new System.Drawing.Size(542, 565);
            this.pnDetails.TabIndex = 28;
            // 
            // isSelectedCheckBox
            // 
            this.isSelectedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.settingBindingSource, "IsSelected", true));
            this.isSelectedCheckBox.Enabled = false;
            this.isSelectedCheckBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isSelectedCheckBox.Location = new System.Drawing.Point(141, 317);
            this.isSelectedCheckBox.Name = "isSelectedCheckBox";
            this.isSelectedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isSelectedCheckBox.TabIndex = 18;
            this.isSelectedCheckBox.UseVisualStyleBackColor = true;
            // 
            // settingBindingSource
            // 
            this.settingBindingSource.DataSource = typeof(MNG.UI.Setting);
            this.settingBindingSource.CurrentChanged += new System.EventHandler(this.settingBindingSource_CurrentChanged);
            // 
            // apI_URLTextBox
            // 
            this.apI_URLTextBox.BackColor = System.Drawing.Color.White;
            this.apI_URLTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apI_URLTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "ApI_URL", true));
            this.apI_URLTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apI_URLTextBox.Location = new System.Drawing.Point(141, 122);
            this.apI_URLTextBox.Name = "apI_URLTextBox";
            this.apI_URLTextBox.ReadOnly = true;
            this.apI_URLTextBox.Size = new System.Drawing.Size(373, 23);
            this.apI_URLTextBox.TabIndex = 14;
            // 
            // codeTextBox
            // 
            this.codeTextBox.BackColor = System.Drawing.Color.White;
            this.codeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "Code", true));
            this.codeTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox.Location = new System.Drawing.Point(141, 64);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(104, 23);
            this.codeTextBox.TabIndex = 16;
            // 
            // pathTextBox
            // 
            this.pathTextBox.BackColor = System.Drawing.Color.White;
            this.pathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "Path", true));
            this.pathTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathTextBox.Location = new System.Drawing.Point(141, 151);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(373, 23);
            this.pathTextBox.TabIndex = 20;
            // 
            // result_PathTextBox
            // 
            this.result_PathTextBox.BackColor = System.Drawing.Color.White;
            this.result_PathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.result_PathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "Result_Path", true));
            this.result_PathTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_PathTextBox.Location = new System.Drawing.Point(141, 180);
            this.result_PathTextBox.Name = "result_PathTextBox";
            this.result_PathTextBox.ReadOnly = true;
            this.result_PathTextBox.Size = new System.Drawing.Size(373, 23);
            this.result_PathTextBox.TabIndex = 26;
            // 
            // powerMeterIPTextBox
            // 
            this.powerMeterIPTextBox.BackColor = System.Drawing.Color.White;
            this.powerMeterIPTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.powerMeterIPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "PowerMeterIP", true));
            this.powerMeterIPTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerMeterIPTextBox.Location = new System.Drawing.Point(141, 238);
            this.powerMeterIPTextBox.Name = "powerMeterIPTextBox";
            this.powerMeterIPTextBox.ReadOnly = true;
            this.powerMeterIPTextBox.Size = new System.Drawing.Size(104, 23);
            this.powerMeterIPTextBox.TabIndex = 22;
            // 
            // refreshRateTextBox
            // 
            this.refreshRateTextBox.BackColor = System.Drawing.Color.White;
            this.refreshRateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.refreshRateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "RefreshRate", true));
            this.refreshRateTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshRateTextBox.Location = new System.Drawing.Point(141, 267);
            this.refreshRateTextBox.Name = "refreshRateTextBox";
            this.refreshRateTextBox.ReadOnly = true;
            this.refreshRateTextBox.Size = new System.Drawing.Size(44, 23);
            this.refreshRateTextBox.TabIndex = 24;
            // 
            // pnDgv
            // 
            this.pnDgv.Controls.Add(this.settingDataGridView);
            this.pnDgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnDgv.Location = new System.Drawing.Point(0, 0);
            this.pnDgv.Name = "pnDgv";
            this.pnDgv.Size = new System.Drawing.Size(131, 565);
            this.pnDgv.TabIndex = 27;
            // 
            // settingDataGridView
            // 
            this.settingDataGridView.AllowUserToAddRows = false;
            this.settingDataGridView.AllowUserToDeleteRows = false;
            this.settingDataGridView.AutoGenerateColumns = false;
            this.settingDataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.settingDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.settingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.settingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.settingDataGridView.DataSource = this.settingBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.settingDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.settingDataGridView.Location = new System.Drawing.Point(6, 64);
            this.settingDataGridView.Name = "settingDataGridView";
            this.settingDataGridView.ReadOnly = true;
            this.settingDataGridView.RowHeadersWidth = 30;
            this.settingDataGridView.Size = new System.Drawing.Size(112, 223);
            this.settingDataGridView.TabIndex = 13;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(737, 613);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.Text = "frmSetting";
            this.pnSaveExit.ResumeLayout(false);
            this.pnToolBar.ResumeLayout(false);
            this.pnToolBar.PerformLayout();
            this.pnCRUD.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnDetails.ResumeLayout(false);
            this.pnDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingSource)).EndInit();
            this.pnDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel pnSaveExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnToolBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView settingDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource settingBindingSource;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel pnCRUD;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox apI_URLTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.CheckBox isSelectedCheckBox;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox powerMeterIPTextBox;
        private System.Windows.Forms.TextBox refreshRateTextBox;
        private System.Windows.Forms.TextBox result_PathTextBox;
        private System.Windows.Forms.Panel pnDetails;
        private System.Windows.Forms.Panel pnDgv;
    }
}