using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI
{
    public partial class MillSheetLotNoForm : Form
    {
        public string LotNo;
        public MillSheetLotNoForm()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            LotNo = tbLotNo.Text;
        }

        private void tbLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                LotNo = tbLotNo.Text;

                if(LotNo.Count() > 1)
                {
                    Close();
                }
            }
        }
    }
}
