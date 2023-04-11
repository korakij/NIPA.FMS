using MNG.Models;
using MNG.Models.Productions;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Services
{
    public class TestNoByLotNoService : QueryServiceBase<TestNoByLotNo>
    {
        public TestNoByLotNoService(AppDb db) : base(db)
        {

        }
    }
}
