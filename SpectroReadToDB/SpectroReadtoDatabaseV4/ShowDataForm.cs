using SpectroReadToDatabaseV4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectroReadtoDatabaseV4
{
    public partial class ShowDataForm : Form
    {
        public ShowDataForm()
        {
            InitializeComponent();
        }

        //SpetroEntities1 db = new SpetroEntities1();
        
        private void ShowDataForm_Load(object sender, EventArgs e)
        {
            ////var data = from dt in db.Chems select dt;
            //FilterData fa = new FilterData();
            //fa.dataalls();

            ////dataGridView1.DataSource = data.ToList();
            //richTextBox1.Text = fa.Datetime() + "  " + fa.Kanban_no + "  " + fa.Part_no() + "  " + fa.Part_name + "  " + fa.stand() + "  " + fa.In() + " :>>> "; 
            
            //for(int i = 0; i < fa.value().Count; i++)
            //{
            //    richTextBox1.Text += fa.value()[i] + "  ";
            //}
        }
    }
}
