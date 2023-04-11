using MNG.Models;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Services
{
    public class ChemicalCompositionInLadleService : ServiceBase<ChemicalCompositionInLadle>
    {
        public ChemicalCompositionInLadleService(AppDb db) : base(db)
        {

        }

        public ChemicalCompositionInLadle GetByProductId(int productId)
        {
            var p = db.Products.Find(productId);
            if (p == null) return null;

            var cp = db.ControlPlans.Find(p.ActiveControlPlanId);
            if (cp == null) return null;

            return Find(cp.ChemicalCompositionInFurnaceCode);
        }
    }
}
