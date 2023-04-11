using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Models.Productions.Defects
{
    public class MoldingDefect
    {
        public int SandDrop { get; set; }
        public int SandBroken { get; set; }
        public int MissMatch { get; set; }
        public int CoreMismatch { get; set; }
        public int ChillMismatch { get; set; }
        public int Burr { get; set; }
        public int PinHole { get; set; }
        public int BlowHole { get; set; }
        public int Total { get; set; }
    }
}
