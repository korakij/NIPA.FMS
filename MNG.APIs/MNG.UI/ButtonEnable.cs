using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNG.UI
{
    public class ButtonEnable
    {
        public Button ButtonSet { get; set; }
        public int Department { get; set; }
        public int Level { get; set; }
        public ButtonEnable() 
        {
            
        }
        public void Enable()
        {
            ButtonSet.Enabled = true;
        }
        public void Disable()
        {
            ButtonSet.Enabled = false;
        }
    }
}
