namespace MNG.UI.Production
{
    partial class frmMultiMelting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultiMelting));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnToolBar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnSaveExit = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnCRUD = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pnExit = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnNavigator = new System.Windows.Forms.Panel();
            this.btnFurAll = new System.Windows.Forms.Button();
            this.btnFurE = new System.Windows.Forms.Button();
            this.btnFurD = new System.Windows.Forms.Button();
            this.btnFurC = new System.Windows.Forms.Button();
            this.btnFurB = new System.Windows.Forms.Button();
            this.btnFurA = new System.Windows.Forms.Button();
            this.kanbanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testChemicalCompositionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chemicalCompositionInFurnaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chargingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.meltStandardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lotNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.furnaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnToolBar.SuspendLayout();
            this.pnSaveExit.SuspendLayout();
            this.pnCRUD.SuspendLayout();
            this.pnExit.SuspendLayout();
            this.pnNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kanbanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testChemicalCompositionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chemicalCompositionInFurnaceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meltStandardBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotNoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.furnaceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnToolBar
            // 
            this.pnToolBar.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnToolBar.Controls.Add(this.label4);
            this.pnToolBar.Controls.Add(this.pnSaveExit);
            this.pnToolBar.Controls.Add(this.pnCRUD);
            this.pnToolBar.Controls.Add(this.pnExit);
            this.pnToolBar.Controls.Add(this.label3);
            this.pnToolBar.Controls.Add(this.label2);
            this.pnToolBar.Controls.Add(this.pnNavigator);
            this.pnToolBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnToolBar.Location = new System.Drawing.Point(0, 0);
            this.pnToolBar.Name = "pnToolBar";
            this.pnToolBar.Size = new System.Drawing.Size(59, 1028);
            this.pnToolBar.TabIndex = 171;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 647);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "--------";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnSaveExit
            // 
            this.pnSaveExit.Controls.Add(this.btnSave);
            this.pnSaveExit.Controls.Add(this.btnExit);
            this.pnSaveExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSaveExit.Location = new System.Drawing.Point(0, 744);
            this.pnSaveExit.Name = "pnSaveExit";
            this.pnSaveExit.Size = new System.Drawing.Size(59, 127);
            this.pnSaveExit.TabIndex = 17;
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
            this.btnSave.Location = new System.Drawing.Point(0, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 59);
            this.btnSave.TabIndex = 9;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(0, 68);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 59);
            this.btnExit.TabIndex = 8;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // pnCRUD
            // 
            this.pnCRUD.Controls.Add(this.btnPrint);
            this.pnCRUD.Controls.Add(this.btnDelete);
            this.pnCRUD.Controls.Add(this.btnEdit);
            this.pnCRUD.Controls.Add(this.btnCreate);
            this.pnCRUD.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCRUD.Location = new System.Drawing.Point(0, 374);
            this.pnCRUD.Name = "pnCRUD";
            this.pnCRUD.Size = new System.Drawing.Size(59, 273);
            this.pnCRUD.TabIndex = 16;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(0, 214);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(59, 59);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 118);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 59);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(0, 59);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 59);
            this.btnEdit.TabIndex = 11;
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
            this.btnCreate.Location = new System.Drawing.Point(0, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(59, 59);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pnExit
            // 
            this.pnExit.Controls.Add(this.btnClose);
            this.pnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnExit.Location = new System.Drawing.Point(0, 871);
            this.pnExit.Name = "pnExit";
            this.pnExit.Size = new System.Drawing.Size(59, 136);
            this.pnExit.TabIndex = 15;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(0, 77);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 59);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "--------\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.MidnightBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 1007);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "--------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnNavigator
            // 
            this.pnNavigator.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnNavigator.Controls.Add(this.btnFurAll);
            this.pnNavigator.Controls.Add(this.btnFurE);
            this.pnNavigator.Controls.Add(this.btnFurD);
            this.pnNavigator.Controls.Add(this.btnFurC);
            this.pnNavigator.Controls.Add(this.btnFurB);
            this.pnNavigator.Controls.Add(this.btnFurA);
            this.pnNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnNavigator.Location = new System.Drawing.Point(0, 0);
            this.pnNavigator.Name = "pnNavigator";
            this.pnNavigator.Size = new System.Drawing.Size(59, 353);
            this.pnNavigator.TabIndex = 14;
            // 
            // btnFurAll
            // 
            this.btnFurAll.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFurAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFurAll.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnFurAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFurAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnFurAll.ForeColor = System.Drawing.Color.White;
            this.btnFurAll.Location = new System.Drawing.Point(0, 295);
            this.btnFurAll.Name = "btnFurAll";
            this.btnFurAll.Size = new System.Drawing.Size(59, 59);
            this.btnFurAll.TabIndex = 11;
            this.btnFurAll.Text = "All";
            this.btnFurAll.UseVisualStyleBackColor = false;
            this.btnFurAll.Click += new System.EventHandler(this.btnFurAll_Click);
            // 
            // btnFurE
            // 
            this.btnFurE.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFurE.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFurE.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnFurE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFurE.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFurE.ForeColor = System.Drawing.Color.White;
            this.btnFurE.Location = new System.Drawing.Point(0, 236);
            this.btnFurE.Name = "btnFurE";
            this.btnFurE.Size = new System.Drawing.Size(59, 59);
            this.btnFurE.TabIndex = 14;
            this.btnFurE.Text = "E";
            this.btnFurE.UseVisualStyleBackColor = false;
            this.btnFurE.Click += new System.EventHandler(this.btnFurE_Click);
            // 
            // btnFurD
            // 
            this.btnFurD.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFurD.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFurD.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnFurD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFurD.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFurD.ForeColor = System.Drawing.Color.White;
            this.btnFurD.Location = new System.Drawing.Point(0, 177);
            this.btnFurD.Name = "btnFurD";
            this.btnFurD.Size = new System.Drawing.Size(59, 59);
            this.btnFurD.TabIndex = 13;
            this.btnFurD.Text = "D";
            this.btnFurD.UseVisualStyleBackColor = false;
            this.btnFurD.Click += new System.EventHandler(this.btnFurD_Click);
            // 
            // btnFurC
            // 
            this.btnFurC.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFurC.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFurC.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnFurC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFurC.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFurC.ForeColor = System.Drawing.Color.White;
            this.btnFurC.Location = new System.Drawing.Point(0, 118);
            this.btnFurC.Name = "btnFurC";
            this.btnFurC.Size = new System.Drawing.Size(59, 59);
            this.btnFurC.TabIndex = 12;
            this.btnFurC.Text = "C";
            this.btnFurC.UseVisualStyleBackColor = false;
            this.btnFurC.Click += new System.EventHandler(this.btnFurC_Click);
            // 
            // btnFurB
            // 
            this.btnFurB.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFurB.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFurB.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnFurB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFurB.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFurB.ForeColor = System.Drawing.Color.White;
            this.btnFurB.Location = new System.Drawing.Point(0, 59);
            this.btnFurB.Name = "btnFurB";
            this.btnFurB.Size = new System.Drawing.Size(59, 59);
            this.btnFurB.TabIndex = 11;
            this.btnFurB.Text = "B";
            this.btnFurB.UseVisualStyleBackColor = false;
            this.btnFurB.Click += new System.EventHandler(this.btnFurB_Click);
            // 
            // btnFurA
            // 
            this.btnFurA.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnFurA.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFurA.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnFurA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFurA.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFurA.ForeColor = System.Drawing.Color.White;
            this.btnFurA.Location = new System.Drawing.Point(0, 0);
            this.btnFurA.Name = "btnFurA";
            this.btnFurA.Size = new System.Drawing.Size(59, 59);
            this.btnFurA.TabIndex = 18;
            this.btnFurA.Text = "A";
            this.btnFurA.UseVisualStyleBackColor = false;
            this.btnFurA.Click += new System.EventHandler(this.btnFurA_Click);
            // 
            // kanbanBindingSource
            // 
            this.kanbanBindingSource.DataSource = typeof(MNG.UI.Kanban);
            // 
            // testChemicalCompositionBindingSource
            // 
            this.testChemicalCompositionBindingSource.DataSource = typeof(MNG.UI.TestChemicalComposition);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(MNG.UI.Product);
            // 
            // chemicalCompositionInFurnaceBindingSource
            // 
            this.chemicalCompositionInFurnaceBindingSource.DataSource = typeof(MNG.UI.ChemicalCompositionInFurnace);
            // 
            // chargingBindingSource
            // 
            this.chargingBindingSource.DataSource = typeof(MNG.UI.Charging);
            // 
            // meltStandardBindingSource
            // 
            this.meltStandardBindingSource.DataSource = typeof(MNG.UI.MeltStandard);
            // 
            // lotNoBindingSource
            // 
            this.lotNoBindingSource.DataSource = typeof(MNG.UI.LotNo);
            // 
            // furnaceBindingSource
            // 
            this.furnaceBindingSource.DataSource = typeof(MNG.UI.Furnace);
            // 
            // frmMultiMelting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1900, 1028);
            this.Controls.Add(this.pnToolBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmMultiMelting";
            this.Text = "MELTING";
            this.Load += new System.EventHandler(this.frmCharging_Load);
            this.pnToolBar.ResumeLayout(false);
            this.pnToolBar.PerformLayout();
            this.pnSaveExit.ResumeLayout(false);
            this.pnCRUD.ResumeLayout(false);
            this.pnExit.ResumeLayout(false);
            this.pnNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kanbanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testChemicalCompositionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chemicalCompositionInFurnaceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chargingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meltStandardBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lotNoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.furnaceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.BindingSource chargingBindingSource;
        private System.Windows.Forms.BindingSource meltStandardBindingSource;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.BindingSource chemicalCompositionInFurnaceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.BindingSource testChemicalCompositionBindingSource;
        private System.Windows.Forms.BindingSource kanbanBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.BindingSource lotNoBindingSource;
        private System.Windows.Forms.BindingSource furnaceBindingSource;
        private System.Windows.Forms.Panel pnToolBar;
        private System.Windows.Forms.Panel pnSaveExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnCRUD;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel pnExit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnNavigator;
        private System.Windows.Forms.Button btnFurAll;
        private System.Windows.Forms.Button btnFurB;
        private System.Windows.Forms.Button btnFurA;
        private System.Windows.Forms.Button btnFurE;
        private System.Windows.Forms.Button btnFurD;
        private System.Windows.Forms.Button btnFurC;
        private System.Windows.Forms.Button btnPrint;
    }
}