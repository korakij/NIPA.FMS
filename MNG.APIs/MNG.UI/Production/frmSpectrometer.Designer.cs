namespace MNG.UI
{
    partial class frmSpectrometer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpectrometer));
            this.pnKanban = new System.Windows.Forms.Panel();
            this.pnTestChem = new System.Windows.Forms.Panel();
            this.pnLotNo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnKanban
            // 
            this.pnKanban.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnKanban.Location = new System.Drawing.Point(705, 0);
            this.pnKanban.Name = "pnKanban";
            this.pnKanban.Size = new System.Drawing.Size(687, 720);
            this.pnKanban.TabIndex = 228;
            // 
            // pnTestChem
            // 
            this.pnTestChem.BackColor = System.Drawing.Color.White;
            this.pnTestChem.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnTestChem.Location = new System.Drawing.Point(310, 0);
            this.pnTestChem.Name = "pnTestChem";
            this.pnTestChem.Size = new System.Drawing.Size(395, 720);
            this.pnTestChem.TabIndex = 227;
            // 
            // pnLotNo
            // 
            this.pnLotNo.BackColor = System.Drawing.Color.White;
            this.pnLotNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLotNo.Location = new System.Drawing.Point(59, 0);
            this.pnLotNo.Name = "pnLotNo";
            this.pnLotNo.Size = new System.Drawing.Size(251, 720);
            this.pnLotNo.TabIndex = 226;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 720);
            this.panel1.TabIndex = 229;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(0, 217);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(59, 59);
            this.btnEdit.TabIndex = 215;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 513);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(59, 186);
            this.panel2.TabIndex = 17;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(0, 127);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 59);
            this.btnExit.TabIndex = 8;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.MidnightBlue;
            this.label25.Dock = System.Windows.Forms.DockStyle.Top;
            this.label25.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(0, 196);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 21);
            this.label25.TabIndex = 13;
            this.label25.Text = "--------";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(59, 80);
            this.panel3.TabIndex = 16;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.MidnightBlue;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(0, 699);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 21);
            this.label27.TabIndex = 9;
            this.label27.Text = "--------";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(59, 116);
            this.panel4.TabIndex = 14;
            // 
            // frmSpectrometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1720, 720);
            this.Controls.Add(this.pnKanban);
            this.Controls.Add(this.pnTestChem);
            this.Controls.Add(this.pnLotNo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSpectrometer";
            this.Text = "MNG - SPECTROMETERING";
            this.Load += new System.EventHandler(this.frmSpectrometer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnTestChem;
        private System.Windows.Forms.Panel pnLotNo;
        private System.Windows.Forms.Panel pnKanban;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel4;
    }
}