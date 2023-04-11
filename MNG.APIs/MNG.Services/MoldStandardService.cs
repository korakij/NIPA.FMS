using MNG.Models;
using MNG.Services.Core;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Services
{
    public class MoldStandardService : ServiceBase<MoldStandard>
    {
        public MoldStandardService(AppDb db) : base(db)
        {

        }
    }
}
