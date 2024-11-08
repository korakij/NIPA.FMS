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
    public class PlanDetailService : ServiceBase<PlanDetail>
    {
        public PlanDetailService(AppDb db) : base(db) { }

        public async Task<List<PlanDetail>> FindByPlanId(int planId)
        {
            var planDetails = db.PlanDetails.Where(p => p.PlanId == planId).ToList();

            return planDetails;
        }
    }
}
