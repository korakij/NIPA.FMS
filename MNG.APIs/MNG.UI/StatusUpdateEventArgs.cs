using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI
{
    public class StatusUpdateEventArgs:EventArgs
    {
        public string Status { get; set; }

        public StatusUpdateEventArgs()
        {
            Status = "อัพเดท";
        }
    }
}
