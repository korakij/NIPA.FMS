using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeLib;

namespace MNG.UI
{
    public class PrintBarcode
    {
        private Bitmap BM;
        private string Info1;
        private string Info2;

        public PrintBarcode(Bitmap bm, string info1, string info2)
        {
            BM = bm;
            Info1 = info1;
            Info2 = info2;
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(BM, loc);
            e.Graphics.DrawString(Info1, new Font("Calibri", 14, FontStyle.Bold), new SolidBrush(Color.Black), new Point(15, 55));
            e.Graphics.DrawString(Info2, new Font("Calibri", 14, FontStyle.Bold), new SolidBrush(Color.Black), new Point(15, 80));
        }
    }
}
