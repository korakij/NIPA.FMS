using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace SpectrometerReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Source file to be renamed  
            string sourceFile = @"E:\Mango.Solutions\MNG.FMS\MNG.APIs\results1.txt";
            // Create a FileInfo  
            System.IO.FileInfo fi = new System.IO.FileInfo(sourceFile);
            // Check if file is there  
            if (fi.Exists)
            {
                // Move file with a new name. Hence renamed.  
                fi.MoveTo(@"E:\Mango.Solutions\MNG.FMS\MNG.APIs\results1.csv");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<List<string>> info = new List<List<string>>();
            int lastLine = 0;
            
            using (var reader = new StreamReader(@"E:\Mango.Solutions\MNG.FMS\MNG.APIs\results.txt"))
            {
                while (!reader.EndOfStream)
                {
                    List<string> data = new List<string>();
                    var line = reader.ReadLine();
                    var values = line.Split('\t');

                    for (int i = 0; i < values.Length; i++)
                    {
                        data.Add(values[i]);
                    }

                    info.Add(data);
                    lastLine++;
                }

                var c = Convert.ToDouble(info[3][11]);
                var result = $"{info[0][11]} = {c}";
                MessageBox.Show(result);
            }
        }
    }
}
