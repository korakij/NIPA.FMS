using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public partial class ucTimePicker : UserControl
    {
        private DateTime _time;
        private DateTime _currentTime;

        public DateTime Time => _time;

        public ucTimePicker(DateTime _t, Point _p)
        {
            InitializeComponent();

            this.Location = new Point(_p.X, _p.Y);
            _currentTime = _t;
            TimePicker.Value = _t;
        }

        private void btnNow_Click_1(object sender, EventArgs e)
        {
            _time = DateTime.Now;
            TimePicker.Value = _time;
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            _time = TimePicker.Value;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            _time = _currentTime;
        }
    }
}
