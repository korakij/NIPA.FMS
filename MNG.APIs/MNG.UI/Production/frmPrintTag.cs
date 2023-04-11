using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class frmPrintTag : Form
    {
        private PrintDocument pd = new PrintDocument();
        private TestChemicalComposition TestResult;
        private ControlPlan CurrentControlPlan;

        public string[] Label { get; set; } = new string[3];
        public string[] Info { get; set; } = new string[3];

        public frmPrintTag()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            pd.PrintPage += PrintPage;
            pd.Print();

            this.Close();
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            Point loc = new Point(10, 0);
            e.Graphics.DrawImage(pictureBox2.Image, loc);
            e.Graphics.DrawString(Info[0], new Font("Century Gothic", 11, FontStyle.Regular), new SolidBrush(Color.Black), new Point(10, 47));
            e.Graphics.DrawString(Info[1], new Font("Century Gothic", 11, FontStyle.Regular), new SolidBrush(Color.Black), new Point(10, 67));
            e.Graphics.DrawString(Info[2], new Font("Century Gothic", 11, FontStyle.Regular), new SolidBrush(Color.Black), new Point(10, 87));
        }

        private void frmPrintTag_Load(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox2.Image = brCode.Draw(Info[0], 30);
            Info1.Text = Info[0];
            Info2.Text = Info[1];
            Info3.Text = Info[2];
        }
    }
}
