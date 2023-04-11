using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI
{
    public partial class LookupButton : UserControl
    {

        public TextBox InputTextBox { get; set; }
        public string For { get; set; }

        public LookupButton()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (InputTextBox == null || string.IsNullOrWhiteSpace(For))
            {
                return;
            }

            var oh = Activator.CreateInstance(assemblyName: null, typeName: For);

            var fm = oh.Unwrap() as Form;
            if (fm == null)
            {
                MessageBox.Show($"Cannot create the form `{For}`");
                return;
            }

            var lookup = fm as ILookup;
            if (lookup == null)
            {
                MessageBox.Show($"Form `{For}` is not implemented ILookup");
                return;
            }


            fm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            fm.StartPosition = FormStartPosition.Manual;
            fm.Location = new Point(
                Parent.Location.X + Right + 4,
                Parent.Location.Y + Top + 30
                );

            lookup.LookupValue = "..." + InputTextBox.Text;

            if (fm.ShowDialog() == DialogResult.OK)
            {
                InputTextBox.Text = lookup.LookupValue;
                InputTextBox.Focus();
                SendKeys.Send("{TAB}+{TAB}");
            }
            fm.Hide();
        }
    }
}
