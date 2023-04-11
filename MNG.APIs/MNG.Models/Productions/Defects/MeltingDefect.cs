using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Models.Productions.Defects
{
    public class MeltingDefect
    {
        public int Chill { get; set; }
        public int Shrinkage { get; set; }
        public int ChemNG { get; set; }
        public int MicroNG { get; set; }
        public int HardnessNG { get; set; }
        public int PinHole { get; set; }
        public int BlowHole { get; set; }
        public int Total { get; set; }
    }
}
