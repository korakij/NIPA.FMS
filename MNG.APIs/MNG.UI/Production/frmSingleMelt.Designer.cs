namespace MNG.UI.Production
{
    partial class frmSingleMelt
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
            this.pnLotNo = new System.Windows.Forms.Panel();
            this.pnCharging = new System.Windows.Forms.Panel();
            this.pnChemInFur = new System.Windows.Forms.Panel();
            this.pnTapping = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnSummary = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxStatusBar = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLotNo
            // 
            this.pnLotNo.BackColor = System.Drawing.Color.White;
            this.pnLotNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLotNo.Location = new System.Drawing.Point(225, 0);
            this.pnLotNo.Name = "pnLotNo";
            this.pnLotNo.Size = new System.Drawing.Size(216, 572);
            this.pnLotNo.TabIndex = 0;
            this.pnLotNo.TabStop = true;
            // 
            // pnCharging
            // 
            this.pnCharging.BackColor = System.Drawing.Color.White;
            this.pnCharging.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnCharging.Location = new System.Drawing.Point(441, 0);
            this.pnCharging.Name = "pnCharging";
            this.pnCharging.Size = new System.Drawing.Size(367, 572);
            this.pnCharging.TabIndex = 171;
            // 
            // pnChemInFur
            // 
            this.pnChemInFur.BackColor = System.Drawing.Color.White;
            this.pnChemInFur.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnChemInFur.Location = new System.Drawing.Point(808, 0);
            this.pnChemInFur.Name = "pnChemInFur";
            this.pnChemInFur.Size = new System.Drawing.Size(375, 572);
            this.pnChemInFur.TabIndex = 172;
            // 
            // pnTapping
            // 
            this.pnTapping.BackColor = System.Drawing.Color.White;
            this.pnTapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTapping.Location = new System.Drawing.Point(1183, 0);
            this.pnTapping.Name = "pnTapping";
            this.pnTapping.Size = new System.Drawing.Size(111, 572);
            this.pnTapping.TabIndex = 173;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnSummary
            // 
            this.pnSummary.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSummary.Location = new System.Drawing.Point(0, 0);
            this.pnSummary.Name = "pnSummary";
            this.pnSummary.Size = new System.Drawing.Size(225, 572);
            this.pnSummary.TabIndex = 174;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxStatusBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 572);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1294, 28);
            this.panel1.TabIndex = 175;
            // 
            // tbxStatusBar
            // 
            this.tbxStatusBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbxStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxStatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxStatusBar.Location = new System.Drawing.Point(0, 0);
            this.tbxStatusBar.Name = "tbxStatusBar";
            this.tbxStatusBar.ReadOnly = true;
            this.tbxStatusBar.Size = new System.Drawing.Size(1294, 29);
            this.tbxStatusBar.TabIndex = 9;
            this.tbxStatusBar.TabStop = false;
            this.tbxStatusBar.Text = "   สถานะ : ปกติ";
            // 
            // frmSingleMelt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1294, 600);
            this.Controls.Add(this.pnTapping);
            this.Controls.Add(this.pnChemInFur);
            this.Controls.Add(this.pnCharging);
            this.Controls.Add(this.pnLotNo);
            this.Controls.Add(this.pnSummary);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSingleMelt";
            this.Text = "frmSingleMelt";
            this.Load += new System.EventHandler(this.frmSingleMelt_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLotNo;
        private System.Windows.Forms.Panel pnCharging;
        private System.Windows.Forms.Panel pnChemInFur;
        private System.Windows.Forms.Panel pnTapping;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnSummary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxStatusBar;
    }
}