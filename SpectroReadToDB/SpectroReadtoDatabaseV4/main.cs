using SpectroReadtoDatabaseV4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectroReadToDatabaseV4
{
    public partial class ReadChemical : Form
    {
        Streammanager st = new Streammanager();

        public ReadChemical()
        {
            InitializeComponent();
            //string path = st.Path_Html();
            //MessageBox.Show(path);
            //fileSystemWatcher1.Path = path;
        }

        public SpetroEntities1 db = new SpetroEntities1();
        ReadToDatabase todb = new ReadToDatabase();//read file from html file to Data base
        FilterData filt = new FilterData();//get properties file html

        private void Form1_Load(object sender, EventArgs e)
        {
            tbStatus.Text = "สถานะ :  เริ่มบันทึกอัตโนมัติ  ";
            tbStatus.BackColor = Color.Yellow;
        }

        private void button1_Click(object sender, EventArgs e)//Read from file html and save to data base
        {
            try
            {
                //todb.ToDatabase();
                tbStatus.Text = "สถานะ :  บันทึก " + filt.Kanban_no.Trim() + "  ";
                tbStatus.BackColor = Color.Lime;
            }
            catch
            {
                //Application.Restart();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)//Read from file html and save to data base
        {
            //string check1 = "";
            //string check2 = "";

            //try
            //{
            //    var db_kanban = from k in db.Chems select k.Kanban_NO;
            //    List<string> kanbanList = db_kanban.ToList();
            //    filt.dataalls();

            //    check1 = filt.Kanban_no.Trim();
            //    check2 = kanbanList[kanbanList.Count - 1].Trim();
            //    //MessageBox.Show("check1 : " + check1 + " check2 " + check2);
            //}
            //catch
            //{
            //    timer1.Stop();
            //    timer2.Start();
            //}

            //if (check1 == check2)
            //{
            //    return;
            //}
            //else
            //{
            //    try
            //    {
            //        //todb.ToDatabase();
            //        tbStatus.Text = "สถานะ :  บันทึก " + check1 + "  ";
            //        tbStatus.BackColor = Color.Lime;
            //    }
            //    catch
            //    {
            //        //Application.Restart();
            //    }
            //}
        }

        private void btAuto_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            tbStatus.Text = "สถานะ :  หยุดบันทึกอัตโนมัติ  ";
            tbStatus.BackColor = Color.Red;
        }

        private void ReadChemical_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowDataForm f = new ShowDataForm();
            f.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Application.Restart();
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            //MessageBox.Show(e.FullPath + " change");

            //string check1 = "";
            //var db_kanban = from k in db.Chems
            //                select k.Kanban_NO;
            //string kanban = db_kanban.LastOrDefault();
            //filt.dataalls();
            //check1 = filt.Kanban_no.Trim();

            //if (check1 != kanban)//check kanban No. New kanban not same Last kanban
            //{
            //    try
            //    {
            //        todb.ToDatabase();
            //        tbStatus.Text = "สถานะ :  บันทึก " + check1 + "  ";
            //        tbStatus.BackColor = Color.Lime;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else
            //{
            //    return;
            //}

            FilterData filter = new FilterData();
            filter.GetAllData();
            string message = "";

            message = message + filter.Kanban_no + "\n";
            message = message + filter.Part_name + "\n";
            List<string> st = filter.Chem;

            foreach(var i in st)
            {
                message = message + i + "\n";
            }
            MessageBox.Show(message);
        }
    }
}
