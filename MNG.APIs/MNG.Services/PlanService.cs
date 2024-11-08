using Microsoft.EntityFrameworkCore;
using MNG.Models;
using MNG.Models.Productions;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MNG.Services
{
    public class PlanService : ServiceBase<Plan>
    {
        public PlanService(AppDb db) : base(db) { }

        public async Task<List<Plan>> FindByDate(DateTime date)
        {
            var plans = db.Plans.Where(p => p.DateCreated.Date == date.Date);

            return plans.ToList();
        }

        public async Task<List<Plan>> FindByMonth(DateTime date) 
        {
            var plans = db.Plans.Where(p => p.DateCreated.Month == date.Month && p.DateCreated.Year == date.Year);

            return plans.ToList();
        }

        public async Task<Plan> FindByCode(string code)
        {
            //code = Date + factory + shift = yyyyMMdd-1-A
            var date = DateTime.ParseExact(code.Substring(0, 8), "yyyyMMdd", null);
            var fac = Convert.ToInt16(code.Substring(code.Length - 3, 1));
            var shift = code.Substring(code.Length - 1, 1);

            var plan = db.Plans.Where(p => p.DateCreated.Date == date.Date && p.Factory == fac && p.Shift == shift).FirstOrDefault();

            return plan;
        }
    }
}
