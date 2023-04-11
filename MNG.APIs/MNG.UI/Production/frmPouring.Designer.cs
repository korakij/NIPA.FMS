namespace MNG.UI
{
    partial class frmPouring
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
            this.pnPouring = new System.Windows.Forms.Panel();
            this.pnKanban = new System.Windows.Forms.Panel();
            this.pnLotNo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnPouring
            // 
            this.pnPouring.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnPouring.Location = new System.Drawing.Point(938, 0);
            this.pnPouring.Name = "pnPouring";
            this.pnPouring.Size = new System.Drawing.Size(580, 720);
            this.pnPouring.TabIndex = 226;
            // 
            // pnKanban
            // 
            this.pnKanban.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnKanban.Location = new System.Drawing.Point(251, 0);
            this.pnKanban.Name = "pnKanban";
            this.pnKanban.Size = new System.Drawing.Size(687, 720);
            this.pnKanban.TabIndex = 228;
            // 
            // pnLotNo
            // 
            this.pnLotNo.BackColor = System.Drawing.Color.White;
            this.pnLotNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLotNo.Location = new System.Drawing.Point(0, 0);
            this.pnLotNo.Name = "pnLotNo";
            this.pnLotNo.Size = new System.Drawing.Size(251, 720);
            this.pnLotNo.TabIndex = 226;
            // 
            // frmPouring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1720, 720);
            this.Controls.Add(this.pnPouring);
            this.Controls.Add(this.pnKanban);
            this.Controls.Add(this.pnLotNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPouring";
            this.Text = "MNG - SPECTROMETERING";
            this.Load += new System.EventHandler(this.frmPouring_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnLotNo;
        private System.Windows.Forms.Panel pnKanban;
        private System.Windows.Forms.Panel pnPouring;
    }
}