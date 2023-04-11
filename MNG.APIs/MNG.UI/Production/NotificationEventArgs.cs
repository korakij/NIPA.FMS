using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI.Production
{
    public class NotificationEventArgs : EventArgs
    {
        public Process Process { get; set; }
        public Application Application { get; set; }
        public string Code { get; set; }
    }
}
