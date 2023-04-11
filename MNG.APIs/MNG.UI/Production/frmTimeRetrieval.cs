using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class frmTimeRetrieval : Form
    {
        public DateTime time { get; set; }

        private DateTime Initialtime;

        public frmTimeRetrieval(DateTime? _initialTime)
        {
            InitializeComponent();
            Initialtime = _initialTime ?? DateTime.Now;

            dateTimePicker1.Value = Initialtime;
        }

        private void btnGetTime_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            time = Initialtime;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            time = dateTimePicker1.Value;
            this.Close();
        }

        private void frmTimeRetrieval_Load(object sender, EventArgs e)
        {

        }
    }
}
