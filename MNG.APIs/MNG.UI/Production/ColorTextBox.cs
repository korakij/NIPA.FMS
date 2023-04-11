using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public class ColorTextBox : TextBox
    {
        public string ColorNotOK { get; set; } = "Red";
        public string ColorOK { get; set; } = "green";
        public string ColorNull { get; set; } = "white";

        private bool? _isOK;
        public bool? IsOK
        {
            get { return _isOK; }
            set
            {
                _isOK = value;
                UpdateColor();
            }
        }

        public ColorTextBox()
        {
        }

        private void UpdateColor()
        {
            if (IsOK == null)
            {
                BackColor = Color.FromName(ColorNull);
                ForeColor = Color.FromName("black");
            }
            else if (IsOK.Value == true)
            {
                BackColor = Color.FromName(ColorOK);
                ForeColor = Color.FromName("black");
            }
            else
            {
                BackColor = Color.FromName(ColorNotOK);
                ForeColor = Color.FromName("white");
            }
        }
    }
}