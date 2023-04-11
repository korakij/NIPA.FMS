using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Models.Productions.Defects
{
    public class DefectCause
    {
        public DefectCause()
        {
            MeltDefect = new MeltingDefect();
            MoldDefect = new MoldingDefect();
            PourDefect = new PouringDefect();
            FinDefect = new FinishingDefect();
            EngDefect = new EngineeringDefect();
            CoreDefect = new CoreDefect();
        }

        public MeltingDefect MeltDefect { get; set; }
        public MoldingDefect MoldDefect { get; set; }
        public PouringDefect PourDefect { get; set; }
        public FinishingDefect FinDefect { get; set; }
        public EngineeringDefect EngDefect { get; set; }
        public CoreDefect CoreDefect { get; set; }

        public int TotalNumber { get; set; }
        public int TotalGood { get; set; }
        public int TotalDefect { get; set; }
        public double DefectRate { get; set; }
        public double TotalWeight { get; set; }
        public double TotalGoodWeight { get; set; }
        public double TotalDefectWeight { get; set; }
        public double DefectWeightRate { get; set; }
    }
}
