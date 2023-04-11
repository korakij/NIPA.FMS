using MNG.Models;
using MNG.Models.Productions;
using MNG.Services.Core;
using System.Linq;
using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MNG.Services
{
    public class LotNoService : ServiceBase<LotNo>
    {
        public LotNoService(AppDb db) : base(db)
        {

        }
    }
}
