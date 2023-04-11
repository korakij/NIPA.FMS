using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectroReadToDatabaseV4
{
    public class Streammanager
    {
        //public string PathHtml = "F:/Data/SpectroReadToDB/html_test";
        //string PathHtml = Application.StartupPath;

        public string Path_Html()
        {
            //string paths = Path.GetDirectoryName(PathHtml);
            //MessageBox.Show(paths);
            StreamReader html = new StreamReader("Path_HTML.txt", Encoding.UTF8);//SpectroReadToDB\SpectroReadtoDatabaseV4\bin\Debug
            string path = "";
            path = html.ReadToEnd();
            html.Close();
            return path;
        }

        public string Readstring()
        {
            try
            {
                FileWebRequest request = (FileWebRequest)WebRequest.Create(Path_Html());
                request.Credentials = CredentialCache.DefaultCredentials;
                FileWebResponse response = (FileWebResponse)request.GetResponse();

                Stream receiveStream = response.GetResponseStream();

                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string s = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                //จบการอ่านข้อมูลจาก HTML File ข้อมูลทั้งหมดอยู่ที่ตัวแปร s
                return s;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
    }
}
