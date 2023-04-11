using MNG.Models.Productions;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Services
{
    public class TestLogService : ServiceBase<TestLog>
    {
        public TestLogService(AppDb db) : base(db)
        {

        }
    }
}
