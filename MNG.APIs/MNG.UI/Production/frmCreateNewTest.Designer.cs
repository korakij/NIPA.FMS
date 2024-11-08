﻿namespace MNG.UI.Production
{
    partial class frmCreateNewTest
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
            System.Windows.Forms.Label lbPartName;
            System.Windows.Forms.Label lbTestNo;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label controlPlanIdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateNewTest));
            this.lbHeader = new System.Windows.Forms.Label();
            this.tbTestNo = new System.Windows.Forms.TextBox();
            this.btnProductBrowse = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.controlPlanIdTextBox = new System.Windows.Forms.TextBox();
            this.controlPlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeTextBox1 = new System.Windows.Forms.TextBox();
            this.revisionTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.testChemicalCompositionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnCCE = new System.Windows.Forms.Panel();
            this.cceTextBox1 = new MNG.UI.Production.ColorTextBox();
            this.cceMinTextBox = new System.Windows.Forms.TextBox();
            this.chemicalCompositionInFurnaceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cceMaxTextBox = new System.Windows.Forms.TextBox();
            lbPartName = new System.Windows.Forms.Label();
            lbTestNo = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            controlPlanIdLabel = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlPlanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testChemicalCompositionBindingSource)).BeginInit();
            this.pnCCE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chemicalCompositionInFurnaceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPartName
            // 
            lbPartName.AutoSize = true;
            lbPartName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbPartName.Location = new System.Drawing.Point(27, 86);
            lbPartName.Name = "lbPartName";
            lbPartName.Size = new System.Drawing.Size(78, 17);
            lbPartName.TabIndex = 291;
            lbPartName.Text = "Part Name";
            // 
            // lbTestNo
            // 
            lbTestNo.AutoSize = true;
            lbTestNo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbTestNo.Location = new System.Drawing.Point(27, 25);
            lbTestNo.Name = "lbTestNo";
            lbTestNo.Size = new System.Drawing.Size(58, 17);
            lbTestNo.TabIndex = 291;
            lbTestNo.Text = "Test No.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(29, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 17);
            label1.TabIndex = 118;
            label1.Text = "C-CE";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label17.Location = new System.Drawing.Point(119, 19);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(34, 17);
            label17.TabIndex = 119;
            label17.Text = "Max";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label18.Location = new System.Drawing.Point(170, 19);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(30, 17);
            label18.TabIndex = 120;
            label18.Text = "Min";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label19.Location = new System.Drawing.Point(221, 19);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(50, 17);
            label19.TabIndex = 117;
            label19.Text = "Actual";
            // 
            // controlPlanIdLabel
            // 
            controlPlanIdLabel.AutoSize = true;
            controlPlanIdLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            controlPlanIdLabel.Location = new System.Drawing.Point(27, 119);
            controlPlanIdLabel.Name = "controlPlanIdLabel";
            controlPlanIdLabel.Size = new System.Drawing.Size(89, 17);
            controlPlanIdLabel.TabIndex = 306;
            controlPlanIdLabel.Text = "Control Plan";
            // 
            // lbHeader
            // 
            this.lbHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbHeader.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbHeader.Location = new System.Drawing.Point(39, 0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(632, 35);
            this.lbHeader.TabIndex = 290;
            this.lbHeader.Text = "C R E A T E - N E W  T E S T";
            this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbTestNo
            // 
            this.tbTestNo.BackColor = System.Drawing.Color.White;
            this.tbTestNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTestNo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTestNo.Location = new System.Drawing.Point(122, 26);
            this.tbTestNo.Name = "tbTestNo";
            this.tbTestNo.ReadOnly = true;
            this.tbTestNo.Size = new System.Drawing.Size(143, 23);
            this.tbTestNo.TabIndex = 117;
            // 
            // btnProductBrowse
            // 
            this.btnProductBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProductBrowse.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductBrowse.Location = new System.Drawing.Point(524, 83);
            this.btnProductBrowse.Name = "btnProductBrowse";
            this.btnProductBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnProductBrowse.TabIndex = 296;
            this.btnProductBrowse.Text = "...";
            this.btnProductBrowse.UseVisualStyleBackColor = true;
            this.btnProductBrowse.Click += new System.EventHandler(this.btnProductBrowse_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.panel13);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(34, 304);
            this.panel4.TabIndex = 297;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnOk);
            this.panel13.Controls.Add(this.btnCancel);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 166);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(34, 117);
            this.panel13.TabIndex = 15;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(0, 47);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(34, 35);
            this.btnOk.TabIndex = 9;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(0, 82);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(34, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.MidnightBlue;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "----";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(34, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 304);
            this.panel1.TabIndex = 298;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(39, 301);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 3);
            this.panel3.TabIndex = 299;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(39, 35);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(632, 5);
            this.panel7.TabIndex = 300;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(668, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(3, 264);
            this.panel6.TabIndex = 301;
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Name", true));
            this.nameTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(271, 84);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(247, 23);
            this.nameTextBox.TabIndex = 304;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(MNG.UI.Product);
            // 
            // idTextBox
            // 
            this.idTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Id", true));
            this.idTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTextBox.Location = new System.Drawing.Point(122, 84);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(45, 23);
            this.idTextBox.TabIndex = 305;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.controlPlanIdTextBox);
            this.panel2.Controls.Add(this.codeTextBox1);
            this.panel2.Controls.Add(this.revisionTextBox);
            this.panel2.Controls.Add(this.codeTextBox);
            this.panel2.Controls.Add(controlPlanIdLabel);
            this.panel2.Controls.Add(lbTestNo);
            this.panel2.Controls.Add(this.idTextBox);
            this.panel2.Controls.Add(this.tbTestNo);
            this.panel2.Controls.Add(this.nameTextBox);
            this.panel2.Controls.Add(lbPartName);
            this.panel2.Controls.Add(this.btnProductBrowse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(39, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 168);
            this.panel2.TabIndex = 306;
            // 
            // controlPlanIdTextBox
            // 
            this.controlPlanIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPlanIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.controlPlanBindingSource, "Id", true));
            this.controlPlanIdTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlPlanIdTextBox.Location = new System.Drawing.Point(122, 117);
            this.controlPlanIdTextBox.Name = "controlPlanIdTextBox";
            this.controlPlanIdTextBox.Size = new System.Drawing.Size(45, 23);
            this.controlPlanIdTextBox.TabIndex = 311;
            // 
            // controlPlanBindingSource
            // 
            this.controlPlanBindingSource.DataSource = typeof(MNG.UI.ControlPlan);
            // 
            // codeTextBox1
            // 
            this.codeTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Code", true));
            this.codeTextBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox1.Location = new System.Drawing.Point(173, 84);
            this.codeTextBox1.Name = "codeTextBox1";
            this.codeTextBox1.Size = new System.Drawing.Size(92, 23);
            this.codeTextBox1.TabIndex = 310;
            // 
            // revisionTextBox
            // 
            this.revisionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.revisionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.controlPlanBindingSource, "Revision", true));
            this.revisionTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revisionTextBox.Location = new System.Drawing.Point(271, 117);
            this.revisionTextBox.Name = "revisionTextBox";
            this.revisionTextBox.Size = new System.Drawing.Size(29, 23);
            this.revisionTextBox.TabIndex = 309;
            // 
            // codeTextBox
            // 
            this.codeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.controlPlanBindingSource, "Code", true));
            this.codeTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox.Location = new System.Drawing.Point(173, 117);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(92, 23);
            this.codeTextBox.TabIndex = 307;
            // 
            // testChemicalCompositionBindingSource
            // 
            this.testChemicalCompositionBindingSource.DataSource = typeof(MNG.UI.TestChemicalComposition);
            // 
            // pnCCE
            // 
            this.pnCCE.Controls.Add(this.cceTextBox1);
            this.pnCCE.Controls.Add(label1);
            this.pnCCE.Controls.Add(label17);
            this.pnCCE.Controls.Add(label18);
            this.pnCCE.Controls.Add(label19);
            this.pnCCE.Controls.Add(this.cceMinTextBox);
            this.pnCCE.Controls.Add(this.cceMaxTextBox);
            this.pnCCE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCCE.Location = new System.Drawing.Point(39, 208);
            this.pnCCE.Name = "pnCCE";
            this.pnCCE.Size = new System.Drawing.Size(629, 96);
            this.pnCCE.TabIndex = 307;
            // 
            // cceTextBox1
            // 
            this.cceTextBox1.BackColor = System.Drawing.Color.White;
            this.cceTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cceTextBox1.ColorNotOK = "Red";
            this.cceTextBox1.ColorNull = "white";
            this.cceTextBox1.ColorOK = "GreenYellow";
            this.cceTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.testChemicalCompositionBindingSource, "Result.Cce", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "-", "#,##0.000"));
            this.cceTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("IsOK", this.testChemicalCompositionBindingSource, "Validation.IsOk_CCE", true));
            this.cceTextBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cceTextBox1.ForeColor = System.Drawing.Color.Black;
            this.cceTextBox1.IsOK = null;
            this.cceTextBox1.Location = new System.Drawing.Point(224, 39);
            this.cceTextBox1.Name = "cceTextBox1";
            this.cceTextBox1.Size = new System.Drawing.Size(45, 23);
            this.cceTextBox1.TabIndex = 122;
            this.cceTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cceMinTextBox
            // 
            this.cceMinTextBox.BackColor = System.Drawing.Color.White;
            this.cceMinTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cceMinTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chemicalCompositionInFurnaceBindingSource, "CceMin", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "-", "N3"));
            this.cceMinTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cceMinTextBox.Location = new System.Drawing.Point(173, 39);
            this.cceMinTextBox.Name = "cceMinTextBox";
            this.cceMinTextBox.ReadOnly = true;
            this.cceMinTextBox.Size = new System.Drawing.Size(45, 23);
            this.cceMinTextBox.TabIndex = 3;
            this.cceMinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chemicalCompositionInFurnaceBindingSource
            // 
            this.chemicalCompositionInFurnaceBindingSource.DataSource = typeof(MNG.UI.ChemicalCompositionInFurnace);
            // 
            // cceMaxTextBox
            // 
            this.cceMaxTextBox.BackColor = System.Drawing.Color.White;
            this.cceMaxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cceMaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chemicalCompositionInFurnaceBindingSource, "CceMax", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "-", "N3"));
            this.cceMaxTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cceMaxTextBox.Location = new System.Drawing.Point(122, 39);
            this.cceMaxTextBox.Name = "cceMaxTextBox";
            this.cceMaxTextBox.ReadOnly = true;
            this.cceMaxTextBox.Size = new System.Drawing.Size(45, 23);
            this.cceMaxTextBox.TabIndex = 1;
            this.cceMaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmCreateNewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(671, 304);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnCCE);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCreateNewTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCreateNewTest";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlPlanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testChemicalCompositionBindingSource)).EndInit();
            this.pnCCE.ResumeLayout(false);
            this.pnCCE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chemicalCompositionInFurnaceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.TextBox tbTestNo;
        private System.Windows.Forms.Button btnProductBrowse;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnCCE;
        private System.Windows.Forms.TextBox cceMinTextBox;
        private System.Windows.Forms.BindingSource chemicalCompositionInFurnaceBindingSource;
        private System.Windows.Forms.TextBox cceMaxTextBox;
        private System.Windows.Forms.BindingSource testChemicalCompositionBindingSource;
        private ColorTextBox cceTextBox1;
        private System.Windows.Forms.BindingSource controlPlanBindingSource;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox codeTextBox1;
        private System.Windows.Forms.TextBox revisionTextBox;
        private System.Windows.Forms.TextBox controlPlanIdTextBox;
    }
}