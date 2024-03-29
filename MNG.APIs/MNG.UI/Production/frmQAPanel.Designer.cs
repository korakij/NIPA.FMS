﻿namespace MNG.UI
{
    partial class frmQAPanel
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
            this.pnLotNo = new System.Windows.Forms.Panel();
            this.pnInspection = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnPouring
            // 
            this.pnPouring.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnPouring.Location = new System.Drawing.Point(313, 0);
            this.pnPouring.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnPouring.Name = "pnPouring";
            this.pnPouring.Size = new System.Drawing.Size(751, 886);
            this.pnPouring.TabIndex = 226;
            // 
            // pnLotNo
            // 
            this.pnLotNo.BackColor = System.Drawing.Color.White;
            this.pnLotNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLotNo.Location = new System.Drawing.Point(0, 0);
            this.pnLotNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnLotNo.Name = "pnLotNo";
            this.pnLotNo.Size = new System.Drawing.Size(313, 886);
            this.pnLotNo.TabIndex = 226;
            // 
            // pnInspection
            // 
            this.pnInspection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnInspection.Location = new System.Drawing.Point(1064, 0);
            this.pnInspection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnInspection.Name = "pnInspection";
            this.pnInspection.Size = new System.Drawing.Size(1229, 886);
            this.pnInspection.TabIndex = 227;
            // 
            // frmQAPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2293, 886);
            this.Controls.Add(this.pnInspection);
            this.Controls.Add(this.pnPouring);
            this.Controls.Add(this.pnLotNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmQAPanel";
            this.Text = "MNG - SPECTROMETERING";
            this.Load += new System.EventHandler(this.frmQAPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnLotNo;
        private System.Windows.Forms.Panel pnPouring;
        private System.Windows.Forms.Panel pnInspection;
    }
}