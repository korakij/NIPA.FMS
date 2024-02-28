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
    public class PouringService : ServiceBase<Pouring>
    {
        public PouringService(AppDb db) : base(db)
        {
            
        }

        public List<Pouring> FindAllByKanban(string id)
        {
            var pourings = db.Pourings.Where(x => x.KanbanCode == id);

            return pourings.ToList();
        }

        public Pouring FindByKanban(string id)
        {
            var pouring = db.Pourings.Where(x => x.KanbanCode == id).FirstOrDefault();

            return pouring;
        }

        public List <Pouring> FindAllByLotNo(string id) 
        {
            var pourings = db.Pourings.Where(x => x.Code.Contains(id)).ToList();

            return pourings;
        }
    }
}
