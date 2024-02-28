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
    public class ChargingService : ServiceBase<Charging>
    {
        public ChargingService(AppDb db) : base(db)
        {

        }

        public List<Charging> FindAllByLotNo(string id) 
        {
            var Chargins = db.Chargings.Where(x => x.LotNoCode == id).ToList();

            return Chargins;
        }

        public List<Charging> FindAllByChargeNo(string id)
        {
            var chargins = db.Chargings.Where(x => x.ChargeNo == id).ToList();

            return chargins;
        }
    }
}
