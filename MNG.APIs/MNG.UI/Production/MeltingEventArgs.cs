using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNG.UI.Production
{
    public class MeltingEventArgs : EventArgs
    {
        public LotNo LotNos { get; set; }
        public Charging ChargeNo { get; set; }
        public TestChemicalComposition TestNo { get; set; }
        public Kanban KanbanNo { get; set; }
        public Pouring PouringNo { get; set; }

        public bool IsFirstRow { get; set; }
        public bool IsFormCreating { get; set; }
        public FormEditing FormEditing { get; set; }

        public MeltingEventArgs()
        {
            LotNos = new LotNo();
            ChargeNo = new Charging();
            TestNo = new TestChemicalComposition();
            KanbanNo = new Kanban();
            PouringNo = new Pouring();
        }
    }
}
