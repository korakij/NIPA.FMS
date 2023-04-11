using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Models.Productions.Defects
{
    public class EngineeringDefect
    {
        public int AirPocket { get; set; }
        public int MissedIdentifer { get; set; }
        public int WornTooling { get; set; }
        public int Total { get; set; }
    }
}
