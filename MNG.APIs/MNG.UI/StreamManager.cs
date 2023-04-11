using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI
{
    public class StreamManager
    {
        public StreamManager()
        {

        }

        public string Readstring()
        {
            try
            {
                StreamReader readStream = new StreamReader(@"D:\Projects\Mango.Solutions\MNG.FMS\ChemResult\chem1.html", Encoding.UTF8);

                string s = readStream.ReadToEnd();
                readStream.Close();

                return s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
    }
}
