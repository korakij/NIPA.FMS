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
    public class TestChemicalCompositionService : ServiceBase<TestChemicalComposition>
    {
        public TestChemicalCompositionService(AppDb db) : base(db)
        {

        }

        public List<TestChemicalComposition> FindAllByLotNo(Charging charge)
        {
            var tests = db.TestChemicalCompositions.Where(x => x.ChargingCode == charge.ChargeNo).ToList();

            return tests;
        }

        public int CountAllByCode(string id)
        {
            var count = db.TestChemicalCompositions.Where(x => x.Code.Contains(id)).ToList().Count();

            return count;
        }

        public List<TestChemicalComposition> FindAllByCode(string id)
        {
            var testChems = db.TestChemicalCompositions.Where(x => x.Code.Contains(id)).ToList();

            return testChems;
        }

        public List<TestChemicalComposition> FindAllByChargingCode(string id)
        {
            var testChems = db.TestChemicalCompositions.Where(x => x.ChargingCode == id).ToList();

            return testChems;
        }
    }
}
