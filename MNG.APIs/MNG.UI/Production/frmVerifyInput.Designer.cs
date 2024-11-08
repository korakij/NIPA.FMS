namespace MNG.UI.Production
{
    partial class frmVerifyInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerifyInput));
            this.label60 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.lbOutput = new System.Windows.Forms.Label();
            this.btnGenPouringCode = new System.Windows.Forms.Button();
            this.btnGenTestCode = new System.Windows.Forms.Button();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel4.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label60.Dock = System.Windows.Forms.DockStyle.Top;
            this.label60.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label60.Location = new System.Drawing.Point(39, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(507, 35);
            this.label60.TabIndex = 290;
            this.label60.Text = "V E R I F Y";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbInput
            // 
            this.tbInput.BackColor = System.Drawing.Color.White;
            this.tbInput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInput.Location = new System.Drawing.Point(243, 65);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(202, 27);
            this.tbInput.TabIndex = 117;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.panel13);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(34, 171);
            this.panel4.TabIndex = 297;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btnOk);
            this.panel13.Controls.Add(this.btnCancel);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 33);
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
            this.label6.Location = new System.Drawing.Point(0, 150);
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
            this.panel1.Size = new System.Drawing.Size(5, 171);
            this.panel1.TabIndex = 298;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(39, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 3);
            this.panel3.TabIndex = 299;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(39, 35);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(507, 5);
            this.panel7.TabIndex = 300;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(543, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(3, 128);
            this.panel6.TabIndex = 301;
            // 
            // tbOutput
            // 
            this.tbOutput.BackColor = System.Drawing.Color.White;
            this.tbOutput.Enabled = false;
            this.tbOutput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOutput.Location = new System.Drawing.Point(243, 117);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.Size = new System.Drawing.Size(202, 27);
            this.tbOutput.TabIndex = 117;
            this.tbOutput.TabStop = false;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput.Location = new System.Drawing.Point(63, 68);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(57, 21);
            this.lbInput.TabIndex = 302;
            this.lbInput.Text = "label1";
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutput.Location = new System.Drawing.Point(63, 120);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(57, 21);
            this.lbOutput.TabIndex = 302;
            this.lbOutput.Text = "label1";
            // 
            // btnGenPouringCode
            // 
            this.btnGenPouringCode.AutoSize = true;
            this.btnGenPouringCode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenPouringCode.FlatAppearance.BorderSize = 0;
            this.btnGenPouringCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenPouringCode.Image = ((System.Drawing.Image)(resources.GetObject("btnGenPouringCode.Image")));
            this.btnGenPouringCode.Location = new System.Drawing.Point(446, 111);
            this.btnGenPouringCode.Name = "btnGenPouringCode";
            this.btnGenPouringCode.Size = new System.Drawing.Size(34, 35);
            this.btnGenPouringCode.TabIndex = 303;
            this.btnGenPouringCode.UseVisualStyleBackColor = true;
            this.btnGenPouringCode.Click += new System.EventHandler(this.btnGenPouringCode_Click);
            // 
            // btnGenTestCode
            // 
            this.btnGenTestCode.AutoSize = true;
            this.btnGenTestCode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenTestCode.FlatAppearance.BorderSize = 0;
            this.btnGenTestCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenTestCode.Image = ((System.Drawing.Image)(resources.GetObject("btnGenTestCode.Image")));
            this.btnGenTestCode.Location = new System.Drawing.Point(446, 111);
            this.btnGenTestCode.Name = "btnGenTestCode";
            this.btnGenTestCode.Size = new System.Drawing.Size(34, 35);
            this.btnGenTestCode.TabIndex = 303;
            this.btnGenTestCode.UseVisualStyleBackColor = true;
            this.btnGenTestCode.Click += new System.EventHandler(this.btnGenTestCode_Click);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(MNG.UI.Product);
            // 
            // frmVerifyInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(546, 171);
            this.Controls.Add(this.btnGenPouringCode);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnGenTestCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerifyInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCreateNewTest";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox tbInput;
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
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Button btnGenPouringCode;
        private System.Windows.Forms.Button btnGenTestCode;
    }
}