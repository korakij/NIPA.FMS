namespace MNG.UI.Production
{
    partial class frmInspectionProc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInspectionProc));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnToolBar = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnSaveExit = new System.Windows.Forms.Panel();
            this.pnCRUD = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pnExit = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnNavigator = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnL3 = new System.Windows.Forms.Button();
            this.btnL2 = new System.Windows.Forms.Button();
            this.btnL1 = new System.Windows.Forms.Button();
            this.kanbanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testChemicalCompositionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chemicalCompositionInFurnaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chargingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.meltStandardBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lotNoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.furnaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnToolBar.SuspendLayout();
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
            this.pnToolBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnToolBar.Name = "pnToolBar";
            this.pnToolBar.Size = new System.Drawing.Size(79, 1265);
            this.pnToolBar.TabIndex = 171;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 566);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "--------";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnSaveExit
            // 
            this.pnSaveExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnSaveExit.Location = new System.Drawing.Point(0, 925);
            this.pnSaveExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnSaveExit.Name = "pnSaveExit";
            this.pnSaveExit.Size = new System.Drawing.Size(79, 156);
            this.pnSaveExit.TabIndex = 17;
            // 
            // pnCRUD
            // 
            this.pnCRUD.Controls.Add(this.btnDelete);
            this.pnCRUD.Controls.Add(this.btnEdit);
            this.pnCRUD.Controls.Add(this.btnCreate);
            this.pnCRUD.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCRUD.Location = new System.Drawing.Point(0, 331);
            this.pnCRUD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnCRUD.Name = "pnCRUD";
            this.pnCRUD.Size = new System.Drawing.Size(79, 235);
            this.pnCRUD.TabIndex = 16;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 146);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 73);
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
            this.btnEdit.Location = new System.Drawing.Point(0, 73);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(79, 73);
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
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(79, 73);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pnExit
            // 
            this.pnExit.Controls.Add(this.btnClose);
            this.pnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnExit.Location = new System.Drawing.Point(0, 1081);
            this.pnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnExit.Name = "pnExit";
            this.pnExit.Size = new System.Drawing.Size(79, 156);
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
            this.btnClose.Location = new System.Drawing.Point(0, 83);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 73);
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
            this.label3.Location = new System.Drawing.Point(0, 303);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 28);
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
            this.label2.Location = new System.Drawing.Point(0, 1237);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "--------";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnNavigator
            // 
            this.pnNavigator.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnNavigator.Controls.Add(this.btnAll);
            this.pnNavigator.Controls.Add(this.btnL3);
            this.pnNavigator.Controls.Add(this.btnL2);
            this.pnNavigator.Controls.Add(this.btnL1);
            this.pnNavigator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnNavigator.Location = new System.Drawing.Point(0, 0);
            this.pnNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnNavigator.Name = "pnNavigator";
            this.pnNavigator.Size = new System.Drawing.Size(79, 303);
            this.pnNavigator.TabIndex = 14;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAll.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(0, 219);
            this.btnAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(79, 73);
            this.btnAll.TabIndex = 11;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnL3
            // 
            this.btnL3.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnL3.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnL3.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnL3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnL3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnL3.ForeColor = System.Drawing.Color.White;
            this.btnL3.Location = new System.Drawing.Point(0, 146);
            this.btnL3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnL3.Name = "btnL3";
            this.btnL3.Size = new System.Drawing.Size(79, 73);
            this.btnL3.TabIndex = 19;
            this.btnL3.Text = "L3";
            this.btnL3.UseVisualStyleBackColor = false;
            // 
            // btnL2
            // 
            this.btnL2.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnL2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnL2.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnL2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnL2.ForeColor = System.Drawing.Color.White;
            this.btnL2.Location = new System.Drawing.Point(0, 73);
            this.btnL2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnL2.Name = "btnL2";
            this.btnL2.Size = new System.Drawing.Size(79, 73);
            this.btnL2.TabIndex = 11;
            this.btnL2.Text = "L2";
            this.btnL2.UseVisualStyleBackColor = false;
            this.btnL2.Click += new System.EventHandler(this.btnL2_Click);
            // 
            // btnL1
            // 
            this.btnL1.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnL1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnL1.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnL1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnL1.ForeColor = System.Drawing.Color.White;
            this.btnL1.Location = new System.Drawing.Point(0, 0);
            this.btnL1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnL1.Name = "btnL1";
            this.btnL1.Size = new System.Drawing.Size(79, 73);
            this.btnL1.TabIndex = 18;
            this.btnL1.Text = "L1";
            this.btnL1.UseVisualStyleBackColor = false;
            this.btnL1.Click += new System.EventHandler(this.btnL1_Click);
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
            // frmInspectionProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2422, 1265);
            this.Controls.Add(this.pnToolBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmInspectionProc";
            this.Text = "MELTING";
            this.Load += new System.EventHandler(this.frmCharging_Load);
            this.pnToolBar.ResumeLayout(false);
            this.pnToolBar.PerformLayout();
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
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnL2;
        private System.Windows.Forms.Button btnL1;
        private System.Windows.Forms.Button btnL3;
    }
}