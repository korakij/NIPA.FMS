namespace MNG.UI.Production
{
    partial class frmCreateCharge
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
            System.Windows.Forms.Label chargeTimeLabel1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label codeLabel;
            System.Windows.Forms.Label controlPlanIdLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateCharge));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chargeNoTextBox = new System.Windows.Forms.TextBox();
            this.chargingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chargeTimeTextBox = new System.Windows.Forms.TextBox();
            this.startKwHrTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.codeTextBox1 = new System.Windows.Forms.TextBox();
            this.controlPlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.controlPlanIdTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            chargeTimeLabel1 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            codeLabel = new System.Windows.Forms.Label();
            controlPlanIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chargingBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlPlanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // chargeTimeLabel1
            // 
            chargeTimeLabel1.AutoSize = true;
            chargeTimeLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chargeTimeLabel1.Location = new System.Drawing.Point(34, 68);
            chargeTimeLabel1.Name = "chargeTimeLabel1";
            chargeTimeLabel1.Size = new System.Drawing.Size(94, 17);
            chargeTimeLabel1.TabIndex = 49;
            chargeTimeLabel1.Text = "Charge Time:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(34, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 17);
            label1.TabIndex = 49;
            label1.Text = "Charge No.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(34, 97);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 17);
            label2.TabIndex = 49;
            label2.Text = "Power";
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codeLabel.Location = new System.Drawing.Point(34, 155);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(78, 17);
            codeLabel.TabIndex = 54;
            codeLabel.Text = "Part Name";
            // 
            // controlPlanIdLabel
            // 
            controlPlanIdLabel.AutoSize = true;
            controlPlanIdLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            controlPlanIdLabel.Location = new System.Drawing.Point(34, 184);
            controlPlanIdLabel.Name = "controlPlanIdLabel";
            controlPlanIdLabel.Size = new System.Drawing.Size(89, 17);
            controlPlanIdLabel.TabIndex = 56;
            controlPlanIdLabel.Text = "Control Plan";
            controlPlanIdLabel.Click += new System.EventHandler(this.controlPlanIdLabel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chargeNoTextBox
            // 
            this.chargeNoTextBox.BackColor = System.Drawing.Color.White;
            this.chargeNoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chargeNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chargingBindingSource, "ChargeNo", true));
            this.chargeNoTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargeNoTextBox.Location = new System.Drawing.Point(134, 37);
            this.chargeNoTextBox.Name = "chargeNoTextBox";
            this.chargeNoTextBox.ReadOnly = true;
            this.chargeNoTextBox.Size = new System.Drawing.Size(115, 23);
            this.chargeNoTextBox.TabIndex = 52;
            // 
            // chargingBindingSource
            // 
            this.chargingBindingSource.DataSource = typeof(MNG.UI.Charging);
            // 
            // chargeTimeTextBox
            // 
            this.chargeTimeTextBox.BackColor = System.Drawing.Color.White;
            this.chargeTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chargeTimeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chargingBindingSource, "ChargeTime", true));
            this.chargeTimeTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chargeTimeTextBox.Location = new System.Drawing.Point(134, 66);
            this.chargeTimeTextBox.Name = "chargeTimeTextBox";
            this.chargeTimeTextBox.ReadOnly = true;
            this.chargeTimeTextBox.Size = new System.Drawing.Size(115, 23);
            this.chargeTimeTextBox.TabIndex = 53;
            // 
            // startKwHrTextBox
            // 
            this.startKwHrTextBox.BackColor = System.Drawing.Color.White;
            this.startKwHrTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startKwHrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chargingBindingSource, "StartKwHr", true));
            this.startKwHrTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startKwHrTextBox.Location = new System.Drawing.Point(134, 95);
            this.startKwHrTextBox.Name = "startKwHrTextBox";
            this.startKwHrTextBox.ReadOnly = true;
            this.startKwHrTextBox.Size = new System.Drawing.Size(115, 23);
            this.startKwHrTextBox.TabIndex = 54;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBrowse);
            this.panel2.Controls.Add(this.codeTextBox1);
            this.panel2.Controls.Add(this.controlPlanIdTextBox);
            this.panel2.Controls.Add(this.idTextBox);
            this.panel2.Controls.Add(controlPlanIdLabel);
            this.panel2.Controls.Add(this.nameTextBox);
            this.panel2.Controls.Add(codeLabel);
            this.panel2.Controls.Add(this.codeTextBox);
            this.panel2.Controls.Add(label1);
            this.panel2.Controls.Add(chargeTimeLabel1);
            this.panel2.Controls.Add(label2);
            this.panel2.Controls.Add(this.chargeNoTextBox);
            this.panel2.Controls.Add(this.chargeTimeTextBox);
            this.panel2.Controls.Add(this.startKwHrTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(40, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 236);
            this.panel2.TabIndex = 72;
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(513, 152);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 23);
            this.btnBrowse.TabIndex = 231;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // codeTextBox1
            // 
            this.codeTextBox1.BackColor = System.Drawing.Color.White;
            this.codeTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.controlPlanBindingSource, "Code", true));
            this.codeTextBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox1.Location = new System.Drawing.Point(181, 182);
            this.codeTextBox1.Name = "codeTextBox1";
            this.codeTextBox1.ReadOnly = true;
            this.codeTextBox1.Size = new System.Drawing.Size(86, 23);
            this.codeTextBox1.TabIndex = 60;
            // 
            // controlPlanBindingSource
            // 
            this.controlPlanBindingSource.DataSource = typeof(MNG.UI.ControlPlan);
            // 
            // controlPlanIdTextBox
            // 
            this.controlPlanIdTextBox.BackColor = System.Drawing.Color.White;
            this.controlPlanIdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPlanIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chargingBindingSource, "ControlPlanId", true));
            this.controlPlanIdTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlPlanIdTextBox.Location = new System.Drawing.Point(134, 182);
            this.controlPlanIdTextBox.Name = "controlPlanIdTextBox";
            this.controlPlanIdTextBox.ReadOnly = true;
            this.controlPlanIdTextBox.Size = new System.Drawing.Size(41, 23);
            this.controlPlanIdTextBox.TabIndex = 59;
            // 
            // idTextBox
            // 
            this.idTextBox.BackColor = System.Drawing.Color.White;
            this.idTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Id", true));
            this.idTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idTextBox.Location = new System.Drawing.Point(134, 153);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(41, 23);
            this.idTextBox.TabIndex = 58;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(MNG.UI.Product);
            // 
            // nameTextBox
            // 
            this.nameTextBox.BackColor = System.Drawing.Color.White;
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Name", true));
            this.nameTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(273, 153);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(234, 23);
            this.nameTextBox.TabIndex = 56;
            // 
            // codeTextBox
            // 
            this.codeTextBox.BackColor = System.Drawing.Color.White;
            this.codeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.productBindingSource, "Code", true));
            this.codeTextBox.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTextBox.Location = new System.Drawing.Point(181, 153);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.ReadOnly = true;
            this.codeTextBox.Size = new System.Drawing.Size(86, 23);
            this.codeTextBox.TabIndex = 55;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.panel13);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(35, 276);
            this.panel4.TabIndex = 73;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnOk);
            this.panel13.Controls.Add(this.btnClose);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 121);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(35, 134);
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
            this.btnOk.Location = new System.Drawing.Point(0, 64);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(35, 35);
            this.btnOk.TabIndex = 9;
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(0, 99);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 8;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.MidnightBlue;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "--------";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(35, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 276);
            this.panel1.TabIndex = 74;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(40, 273);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(637, 3);
            this.panel3.TabIndex = 75;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(40, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(637, 34);
            this.panel5.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(637, 34);
            this.label5.TabIndex = 1;
            this.label5.Text = "Create New Charge";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label5_MouseDown);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label5_MouseMove);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label5_MouseUp);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(674, 37);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(3, 236);
            this.panel6.TabIndex = 77;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(40, 34);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(637, 3);
            this.panel7.TabIndex = 78;
            // 
            // frmCreateCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 276);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.chargingBindingSource, "ProductId", true));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCreateCharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCreateCharge";
            this.Load += new System.EventHandler(this.frmCreateCharge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chargingBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.controlPlanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource chargingBindingSource;
        private System.Windows.Forms.TextBox chargeNoTextBox;
        private System.Windows.Forms.TextBox chargeTimeTextBox;
        private System.Windows.Forms.TextBox startKwHrTextBox;
        private System.Windows.Forms.BindingSource productBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.TextBox codeTextBox1;
        private System.Windows.Forms.BindingSource controlPlanBindingSource;
        private System.Windows.Forms.TextBox controlPlanIdTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button btnBrowse;
    }
}