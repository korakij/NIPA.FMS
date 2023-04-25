using System;
using System.Drawing;
using System.Windows.Forms;

namespace MNG.UI.Production
{
    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            base.KeyPress += KeyPress;
            base.KeyDown += KeyDown;
            base.MouseClick += MouseClick;

            this.TextAlign = HorizontalAlignment.Center;
        }

        public new void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public new void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || 
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down )
            {
                e.Handled = true;
            }
        }

        public new void MouseClick(object sender, MouseEventArgs e)
        {
            int l = this.Text.Length;
            if (l == 0)
                return;

            this.SelectionStart = l;
        }
    }
}
