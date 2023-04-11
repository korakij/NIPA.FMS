using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI.Production
{
    public class MatSummaryEventArgs : EventArgs
    {
        public MaterialSummary MatSum { get; set; }

        public MatSummaryEventArgs()
        {
        }
    }
}
