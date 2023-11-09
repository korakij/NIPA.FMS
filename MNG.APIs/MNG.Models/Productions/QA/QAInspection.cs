using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Models.Productions.QA
{
    public class QAInspection
    {
        public float GraphiteA { get; set; }
        public float Nodularity { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public float Ferrite { get; set; }
        public float Pearlite { get; set; }
        public float Cementite { get; set; }
        public byte[] GraphiteImg { get; set; }
        public byte[] MatrixImg { get; set; }

        public int Hardness { get; set; }
        public int Tensile { get; set; }
        public int Yeild { get; set; }
        public float Elongation { get; set; }
    }
}
