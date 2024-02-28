using Microsoft.EntityFrameworkCore;
using MNG.Models;
using MNG.Models.Productions;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MNG.Services
{
    public class KanbanService : ServiceBase<Kanban>
    {
        public KanbanService(AppDb db) : base(db)
        {

        }

        public IQueryable<Kanban> LoadKanban(string id)
        {
            var kk = db.Kanbans
                    .Include(x => x.TestChemicalComposition)
                        .ThenInclude(y => y.Charging)
                            .ThenInclude(z => z.LotNo)
                            .Where(t => t.TestChemicalComposition.Charging.LotNo.Code == id);

            return kk;
        }

        public List<Kanban> FindAllByCode(string code) 
        {
            var kanbans = db.Kanbans.Where(x => x.Code.Contains(code));

            return kanbans.ToList();
        }

        public List<Kanban> FindAllByTestNo(string id)
        {
            var kanbans = db.Kanbans.Where(x => x.TestChemicalCompositionCode == id);

            return kanbans.ToList();
        }
    }
}
